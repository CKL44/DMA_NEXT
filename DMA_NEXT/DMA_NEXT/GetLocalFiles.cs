using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMA_NEXT
{
  public class GetLocalFiles
    {
        private DataTable _localFiles;
        private DataTable files { get { return _localFiles; } set { _localFiles = value; } }
        public List<string> importFilesList;



        public GetLocalFiles(string SourceFolder)
        {
            DataTable LocalFileTable = new DataTable();
            string fileName;
            string version = "0.0";
            LocalFileTable.Columns.Add("FileName", typeof(string));
            LocalFileTable.Columns.Add("Version", typeof(string));

            TraverseTreeParallelDMFiles(SourceFolder, (f) =>
            {

                try
                {
                    //byte[] data = File.ReadAllBytes(f); // eats memory 

                }
                catch (FileNotFoundException) { }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }

                  fileName = Path.GetFileName(f);

                //not all files in the Extensions folders have version numbers 

                try
                {
                    version = FileVersionInfo.GetVersionInfo(f).FileVersion.ToString();

                }

                catch(NullReferenceException)
                {
                    
                }
                DataRow row = LocalFileTable.NewRow();
                row["FileName"] = fileName;
                row["Version"] = version;
                LocalFileTable.Rows.Add(row);
                   
                    //LocalFileTable.Rows.Add(fileName, version);

                _localFiles = LocalFileTable;
                
                //Thread th = new Thread(() => this.ThreadSafe());
                //th.Start();



            });
        }



        public GetLocalFiles(string sourceFolder, string extension ) //gets files with a specifc extension and adds them to a list - Used only for imports of xml 
        {

            string path = string.Empty;
            List<string> fullPath = new List<string>();

            TraverseTreeParallelDMFiles(sourceFolder, (f) =>
            {

                try
                {
                    //byte[] data = File.ReadAllBytes(f); // eats memory 

                }
                catch (FileNotFoundException) { }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }

                

                //not all files in the Extensions folders have version numbers 

                try
                {

                    string ext = Path.GetExtension(f);
                    string fileName = Path.GetFileName(f);
                    if (ext == "." + extension) 
                    {

                        if (fileName.Contains("DMA_Export_"))
                        {
                            path = Path.GetFullPath(f); 
                            fullPath.Add(path);
                        }

                       

                    }

                }

                catch (NullReferenceException)
                {

                }


                //Thread th = new Thread(() => this.ThreadSafe());
                //th.Start();


                importFilesList = fullPath;
            });



        }


        public DataTable LocalFiles { get => _localFiles; set => _localFiles = value; }
        public DataTable Files { get => files; set => files = value; }

        public static void TraverseTreeParallelDMFiles(string root, Action<string> action)
        {
            //Count of files traversed and timer for diagnostic output
            int fileCount = 0;
            var sw = Stopwatch.StartNew();

            // Determine whether to parallelize file processing on each folder based on processor count.
            int procCount = System.Environment.ProcessorCount;

            // Data structure to hold names of subfolders to be examined for files.
            Stack<string> dirs = new Stack<string>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = { };
                string[] files = { };

                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                // Thrown if we do not have discovery permission on the directory.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Thrown if another process has deleted the directory after we retrieved its name.
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                // Execute in parallel if there are enough files in the directory.
                // Otherwise, execute sequentially.Files are opened and processed
                // synchronously but this could be modified to perform async I/O.
                try
                {
                    if (files.Length < procCount)
                    {
                        foreach (var file in files)
                        {
                            action(file);
                            fileCount++;
                        }
                    }
                    else
                    {
                        Parallel.ForEach(files, () => 0, (file, loopState, localCount) =>
                        {
                            action(file);
                            return (int)++localCount;
                        },
                                         (c) =>
                                         {
                                             Interlocked.Add(ref fileCount, c);
                                         });
                    }
                }
                catch (AggregateException ae)
                {
                    ae.Handle((ex) =>
                    {
                        if (ex is UnauthorizedAccessException)
                        {
                            // Here we just output a message and go on.
                            Console.WriteLine(ex.Message);
                            return true;
                        }
                        // Handle other exceptions here if necessary...

                        return false;
                    });
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }





        }


    }
}
