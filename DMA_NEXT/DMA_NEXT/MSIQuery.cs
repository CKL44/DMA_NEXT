using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using WindowsInstaller;
using System.Windows.Forms;
using System.Data;
//Dont forget to add the MSi.dll ref from windows system dir 
namespace DMA_NEXT
{
    [System.Runtime.InteropServices.ComImport(),
    System.Runtime.InteropServices.Guid
    ("000C1090-0000-0000-C000-000000000046")]
    class Installer { }

    public class MSIQuery
    {
        //properties 
        private string _mSIfileLocation; //location of MSI 
        private Dictionary<string, string> _filesandVersions;
        private string _outputFilename; //textfile output name 
        private string _version;//DM Product Version 
        private Dictionary<string, string> _features;
        private DataTable _fileVersions;
        
        public string MSIFileLocation { get { return _mSIfileLocation; } set { _mSIfileLocation = value; } }
        public Dictionary<string, string> FilesandVersions { get { return _filesandVersions; } }
        public Dictionary<string, string> Features { get { return _features ; } }
        public DataTable FileVersions { get { return _fileVersions; } }

        //Contructors    
        public MSIQuery( string fileLocation)
        {
            _version = QueryMSI(fileLocation, "SELECT `Value` FROM `Property` WHERE `Property`='ProductVersion'");
            _mSIfileLocation = fileLocation;
            _outputFilename = @"C:\CodeTest\" + _version + "_fileVersions.txt";
           _filesandVersions = QueryMSI(@"Select File, Version FROM File");
            //_features = QueryMSI(@"Select feature, featureName FROM FEATURE");
            _fileVersions = QueryMSIFileandVersions(@"Select File, Version FROM File");
            //WriteToFile(_filesandVersions, _outputFilename);
          

        }

         private DataTable QueryMSIFileandVersions(string query)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Filename");            
            dt.Columns.Add("Version");



            FileInfo msiFile = new FileInfo(_mSIfileLocation);
            //Hashtable msiData = new Hashtable();
            WindowsInstaller.Installer inst = (WindowsInstaller.Installer)new Installer();
            try
            {
                Database instDb = inst.OpenDatabase(msiFile.FullName, WindowsInstaller.MsiOpenDatabaseMode.msiOpenDatabaseModeReadOnly);
                WindowsInstaller.View view = instDb.OpenView(query);
                view.Execute(null);
                Record record = view.Fetch();


                while (record != null)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = record.get_StringData(1);
                    dr[1] = record.get_StringData(2);


                    dt.Rows.Add(dr);



                    record = view.Fetch();
                   

                }

                // close the database


                view.Close();
            }
            catch (Exception ex)
            {


            }

            return dt;

        }

        private Dictionary<string, string> QueryMSI( string query)
       {
            Dictionary<string, string> FilesAndVersion = new Dictionary<string, string>();        
            FileInfo msiFile = new FileInfo(_mSIfileLocation);
            //Hashtable msiData = new Hashtable();
            WindowsInstaller.Installer inst = (WindowsInstaller.Installer)new Installer();
            try
            {
                Database instDb = inst.OpenDatabase(msiFile.FullName, WindowsInstaller.MsiOpenDatabaseMode.msiOpenDatabaseModeReadOnly);
                WindowsInstaller.View view = instDb.OpenView(query);
                view.Execute(null);
                Record record = view.Fetch();
               
                
                while (record != null)
                {
                    //string fileName = record.get_StringData(1);
                    


                    record = view.Fetch();
                    FilesAndVersion.Add(record.get_StringData(1), record.get_StringData(2));
                    
                }

                // close the database
                

                view.Close();
            }

           

            catch(Exception ex)
            {

                
            }

            return FilesAndVersion;
        }


        public string QueryMSI(string fileLocation, string query)
        {
            string result = string.Empty;
            FileInfo msiFile = new FileInfo(fileLocation);
            //Hashtable msiData = new Hashtable();
            WindowsInstaller.Installer inst = (WindowsInstaller.Installer)new Installer();
            try
            {
                Database instDb = inst.OpenDatabase(msiFile.FullName, WindowsInstaller.MsiOpenDatabaseMode.msiOpenDatabaseModeReadOnly);
                WindowsInstaller.View view = instDb.OpenView(query);
                view.Execute(null);
                Record record = view.Fetch();


                
                    //string fileName = record.get_StringData(1);



                   // record = view.Fetch();

                
                result = record.get_StringData(1);
                view.Close();
                
            }
             
            catch(Exception ex)
            { }

            return result;
        }

        private void WriteToFile(Dictionary <string, string> dic, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            try
            {
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    string fileName = kvp.Key;
                    
                    string ext = Path.GetExtension(fileName);
                    if (kvp.Value.Length > 0) // do not write files listed w/o a version 
                    {
                        if (ext == ".x86" || ext == "x64" || ext.Length > 5) //Clean file names 
                        {
                            fileName = fileName.Replace(ext, "");


                            sw.WriteLine(fileName + " " + kvp.Value);

                        }
                        else
                        {
                            sw.WriteLine(kvp.Key + " " + kvp.Value);
                        }


                        // sw.WriteLine(kvp.Key +" " + kvp.Value);
                    }
                }
                sw.Close();
            }

            catch (IOException ex)
            {
                sw.Close();
            }
        }

        

           
        }
    }

    


