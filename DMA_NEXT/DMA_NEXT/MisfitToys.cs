using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DMA_NEXT
{
    class MisfitToys
    {



        //private void Analyze(TabControl TC)
        //{
        //    //TC.TabPages.Clear();

        //    string pairVal = string.Empty;
        //    string pairKey = string.Empty;
        //    ListView LV = new ListView();
        //    string[] columHeaders = { "Item", "Value", "Recommended", "Path", "Key", "Component" };
        //    Dictionary<string, string> proflist = Utility.GetWindowsProfileList();
        //    XmlDocument xdoc = new XmlDocument();

        //    xdoc.Load(XMLRegValues);
        //    LV.Items.Clear();

        //    foreach (KeyValuePair<string, string> pair in proflist)
        //    {
        //        TabPage tabPage = new TabPage();
        //        tabPage.BackColor = Color.White;

        //        pairKey = pair.Key;

        //        TC.TabPages.Add(tabPage);
        //        tabPage.Text = pair.Key;  //Create Tab with User Name 


        //    } //proflist for each 

        //    foreach (TabPage tItem in TC.TabPages)
        //    {
        //        string user = tItem.Text;

        //        if (proflist.ContainsKey(user))
        //        {
        //            proflist.TryGetValue(user, out pairVal);

        //            LV = new ListView();
        //            LV.Size = new System.Drawing.Size(tItem.Width, tItem.Height);
        //            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


        //            //LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


        //            tItem.Controls.Add(LV);


        //            for (int i = 0; i < columHeaders.Length; i++)
        //            {
        //                LV.Columns.Add(new ColumnHeader());
        //                LV.Columns[i].Text = columHeaders[i].ToString();
        //                LV.Columns[i].Width = -1;
        //                LV.View = View.Details;
        //            }



        //            //RegItemsXMLHKCU(xdoc, pairVal, LV);

        //        }





        //        //Compare columns





        //    }   //for eaCH tab  END    



        //    //Report Local files 
        //    FileMetaData localfiles = new FileMetaData("C:\\Program Files (x86)\\Open Text\\DM Extensions");
        //    DataTable Installedfiles = localfiles.fileList;
        //    dataGridView1.DataSource = Installedfiles;

        //}


        //private void button2_Click(object sender, EventArgs e)
        //{

        //    foreach (TabPage tItem in tab.TabPages)
        //    {

        //        foreach (Control control in tItem.Controls)
        //        {
        //            //MessageBox.Show(control.GetType().ToString());

        //            if (control.GetType().ToString() == "System.Windows.Forms.DataGridView")
        //            {
        //                DataGridView dGV = (DataGridView)control;

        //                foreach (DataGridViewRow row in dGV.Rows)
        //                {
        //                    if (dGV.Columns.Contains("Flagged"))
        //                    {



        //                        if (row.Cells["Flagged"].Value.ToString() == "Y")
        //                        {
        //                            row.DefaultCellStyle.ForeColor = Color.Red;
        //                        }

        //                    }

        //                }


        //            }


        //        }

        //    }


        //    // MSIQuery query = new MSIQuery(@"C:\CodeTest\165p1.msi");
        //    // FileMetaData localfiles = new FileMetaData("C:\\Program Files (x86)\\Open Text\\DM Extensions");

        //    // DataTable Installedfiles = localfiles.fileList;
        //    // DataTable MSIFiles = query.FileVersions;

        //    // //shit
        //    //// DataTable Result = Utility.CompareDataTables(Installedfiles, MSIFiles);


        //    // dataGridView1.DataSource = Installedfiles;
        //    // //dataGridView2.DataSource = MSIFiles;




        //}





    }
}
