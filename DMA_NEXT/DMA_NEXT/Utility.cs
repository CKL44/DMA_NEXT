using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;

namespace DMA_NEXT
{
    class Utility
    {


        public static Dictionary<string, string> GetWindowsProfileList()
        {
            string profileReg = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";
            Dictionary<string, string> profList = new Dictionary<string, string>();

            try
            {

                RegistryKey key = Registry.LocalMachine.OpenSubKey(profileReg);
                foreach (var subkey in key.GetSubKeyNames())
                {
                    string account = ConvertSID(subkey.ToString());

                    if (!account.Contains("NT AUTHORITY"))
                    {
                        profList.Add(account, subkey.ToString()); // Key = account  value= SID
                    }
                }

            }
            catch
            {
                profList.Add(string.Empty, string.Empty);

            }

            return profList;
        }

        public static string ConvertSID(string sid)
        {
            string account = string.Empty;

            try
            {
                account = new System.Security.Principal.SecurityIdentifier(sid).Translate(typeof(System.Security.Principal.NTAccount)).ToString();
            }

            catch
            {

                account = " ";
            }
            return account;

        }

        //Compare two DataTables and return a DataTable with DifferentRecords
        public static DataTable CompareDataTables(DataTable FirstDataTable, DataTable SecondDataTable)
        {
            //Create Empty Table   
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            //use a Dataset to make use of a DataRelation object   
            using (DataSet ds = new DataSet())
            {
                //Add tables   
                ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy() });

                //Get Columns for DataRelation   
                DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstColumns.Length; i++)
                {
                    firstColumns[i] = ds.Tables[0].Columns[i];
                }

                DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondColumns.Length; i++)
                {
                    secondColumns[i] = ds.Tables[1].Columns[i];
                }

                //Create DataRelation   
                DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                ds.Relations.Add(r1);

                DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                ds.Relations.Add(r2);

                //Create columns for return table   
                for (int i = 0; i < FirstDataTable.Columns.Count; i++)
                {
                    ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                }

                //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable.   
                ResultDataTable.BeginLoadData();
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }

                //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable.   
                foreach (DataRow parentrow in ds.Tables[1].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }
                ResultDataTable.EndLoadData();
            }

            return ResultDataTable;
        }



        public static ArrayList GetInformation2(string query)
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            ArrayList arrayListInformationCollactor = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("SELECT * FROM" + query);
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (PropertyData sp in searcherProperties)
                    {
                        arrayListInformationCollactor.Add(sp);
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }

            arrayListInformationCollactor = GetInformation2("Win32_OperatingSystem");



            return arrayListInformationCollactor;
        }



        //public static DataTable GetInformation(string qry)
        //{

        //    DataTable dt = new DataTable();
        //    ManagementObjectSearcher searcher= new ManagementObjectSearcher("SELECT * FROM " + qry);
        //    int i = 0;
        //    foreach (ManagementObject mo in searcher.Get())
        //    {
        //        i++;
        //        PropertyDataCollection searcherProperties = mo.Properties;
        //        foreach (PropertyData sp in searcherProperties)
        //        {
        //            dt.Columns.Add(sp.Name);

        //        }


        //        foreach (PropertyData item in sea)
        //        {

        //        }
           


        public static ArrayList GetInformation(string qry)
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            ArrayList arrayListInformationCollactor = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("SELECT * FROM " + qry);
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (PropertyData sp in searcherProperties)
                    {
                        arrayListInformationCollactor.Add(sp);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            return arrayListInformationCollactor;
        }

        ////Win32_ComputerSystem

        //b.Win32_DiskDrive

        //c.Win32_OperatingSystem
        

        //d.Win32_Processor

        //e. Win32_ProgramGroup

        //f. Win32_SystemDevices

        //g. Win32_StartupCommand



        public static void WriteDataTablesXML(List<DataTable> dtL, string location)
        {
            foreach(DataTable dt in dtL)
            {
                dt.WriteXml(location+"\\DMA_Export_"+dt.TableName+".xml",XmlWriteMode.WriteSchema);

            }



        }
        
         

        

    }
}