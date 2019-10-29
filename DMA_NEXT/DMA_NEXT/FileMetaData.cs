using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DMA_NEXT
{
   public class FileMetaData
    {

        private DataTable _files;

        public DataTable fileList { get { return _files; } set { _files = value; } }


        public FileMetaData(string path)
        {
            _files = GetFiles(path);
        }


        public DataTable GetFiles (string path)
        {


            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles();

            string fileVersion = "0.0";
            string creationDate = string.Empty;

            

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Filename");            
            dt.Columns.Add("Version");
            dt.Columns.Add("Creation Date");
            dt.Columns.Add("Size");
            dt.TableName = "DM_Files_Version";
            

            foreach (FileInfo f in files)
            {

                try
                {
                    fileVersion = FileVersionInfo.GetVersionInfo(f.FullName.ToString()).FileVersion;
                    creationDate = f.CreationTime.ToString();
                   

                    dr = dt.NewRow();

                    dr[0] = f.Name.ToString();
                    dr[1] = fileVersion;
                    dr[2] = creationDate;
                    dr[3] =  (f.Length).ToString();
                    dt.Rows.Add(dr);
                }

                catch (NullReferenceException)
                {
                    fileVersion = "0.0";
                    
                }
            }


            return dt;
        }


    }

}

