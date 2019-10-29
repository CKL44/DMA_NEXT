using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace DMA_NEXT
{
    public partial class Form1 : Form
    {

        string XMLRegValues = System.AppDomain.CurrentDomain.BaseDirectory + "\\RegistryKeys.xml";
        TabControl tab;
        List<DataTable> TableList = new List<DataTable>();
    
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when form is closed

            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.MainTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MainTabControl_DrawItem);
            //Analyze(MainTabControl);
            Analyze2(MainTabControl);
            int tabCount = MainTabControl.TabPages.Count;
            MainTabControl.TabPages.Remove(FileData);
            MainTabControl.TabPages.Add(FileData);
            MainTabControl.TabPages.Remove(LogTab);
            MainTabControl.TabPages.Add(LogTab);
            MainTabControl.TabPages.Remove(SysInfoTab);
            MainTabControl.TabPages.Add(SysInfoTab);
          
           

        }

        private void Analyze2(TabControl TC)
        {
            tab = TC;
            TC.TabPages.Clear();
            string pairVal = string.Empty;
            string pairKey = string.Empty;
            ListView LV = new ListView();
            DataGridView dGV = new DataGridView();
            string[] columHeaders = { "Item", "Value", "Recommended", "Path", "Key", "Component" };
            Dictionary<string, string> proflist = Utility.GetWindowsProfileList();
            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(XMLRegValues);
           LV.Items.Clear();

            foreach (KeyValuePair<string, string> pair in proflist)
            {
                TabPage tabPage = new TabPage();
                tabPage.BackColor = Color.White;
                tabPage.ForeColor = Color.Black;
                tabPage.Font = new Font("Nirmala UI", 12);

                pairKey = pair.Key;

                TC.TabPages.Add(tabPage);
                tabPage.Text = pair.Key;  //Create Tab with User Name 


            } //proflist for each 

            foreach (TabPage tItem in TC.TabPages)
            {
                string user = tItem.Text;

                if (proflist.ContainsKey(user))
                {
                    proflist.TryGetValue(user, out pairVal);

                    dGV = new DataGridView();
                    dGV.Size = new System.Drawing.Size(tItem.Width, tItem.Height);
                    dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dGV.BackgroundColor = Color.White;
                    dGV.GridColor = Color.Black;
                    dGV.AllowUserToAddRows = false;
                    dGV.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                    dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    ContextMenuStrip mnu = new ContextMenuStrip();
                    ToolStripMenuItem mnuCopy = new ToolStripMenuItem("Copy");
                    ToolStripMenuItem mnuCut = new ToolStripMenuItem("Cut");
                    ToolStripMenuItem mnuPaste = new ToolStripMenuItem("Paste");
                    //Assign event handlers
                    //mnuCopy.Click += new EventHandler(mnuCopy_Click);
                    //mnuCut.Click += new EventHandler(mnuCut_Click);
                    //mnuPaste.Click += new EventHandler(mnuPaste_Click);
                    //Add to main context menu
                    mnu.Items.AddRange(new ToolStripItem[] { mnuCopy, mnuCut, mnuPaste });
                    //Assign to datagridview
                    dGV.ContextMenuStrip = mnu;



                    tItem.Controls.Add(dGV); //Add Datagrid to tab object 


                    //populate the datatable 
                    DataTable User_Data = new DataTable();                    
                    User_Data= RegItemsXMLDT(xdoc, pairVal, dGV);

                    dGV.DataSource = User_Data; //populate datagridViews 
                    User_Data.TableName = user.Replace('\\', '_');   // Must have a table name for conversion to xml 

                    if (!String.IsNullOrEmpty(User_Data.TableName))
                    {
                        TableList.Add(User_Data); //add to Master Table list to export data 
                    }
                  
                                      

                }
            }   //for eaCH END    



            //Report Local DM files 
            FileMetaData localfiles = new FileMetaData("C:\\Program Files (x86)\\Open Text\\DM Extensions");
            DataTable Installedfiles = localfiles.fileList;
            dataGridView1.DataSource = Installedfiles;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;

            for (int i = 0; i < TC.TabCount; i++) //The row.DefaultCellStyle.ForeColor does not get changed until the form loads so select the tab and run the scan 
            {
                TC.SelectedIndex = i;
                Analyze();
            }

            TableList.Add(Installedfiles);

            //Get Local System info 
            sysdatagridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            sysdatagridView.DataSource = Utility.GetInformation("Win32_OperatingSystem");
            //DataTable sysInfo = (DataTable)sysdatagridView.DataSource;
            //TableList.Add(sysInfo);
            Utility.WriteDataTablesXML(TableList, @"C:\\Codetest");
        }




        

       

        private void button2_Click(object sender, EventArgs e)
        {
           // Analyze2(tab);
            Analyze();
            

        }

        private void Analyze()
        {

            foreach (TabPage tItem in tab.TabPages)
            {



                foreach (Control control in tItem.Controls)
                {
                    //MessageBox.Show(control.GetType().ToString());

                    if (control.GetType().ToString() == "System.Windows.Forms.DataGridView")
                    {
                        DataGridView dGV = (DataGridView)control;

                        foreach (DataGridViewRow row in dGV.Rows)
                        {
                            if (dGV.Columns.Contains("Flagged"))
                            {



                                if (row.Cells["Flagged"].Value.ToString() == "Y")
                                {
                                    row.DefaultCellStyle.ForeColor = Color.Red;
                                }

                            }

                        }


                    }


                }

            }


          




        }

        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }



        private void MainTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = MainTabControl.TabPages[e.Index];
            //Font fnt = new Font(tp.Font.FontFamily,12);
            //MainTabControl.Font = fnt;
            MainTabControl.Font = new Font("Nirmala UI", 12);

           StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;  //optional


            // This is the rectangle to draw "over" the tabpage title
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);

            // This is the default colour to use for the non-selected tabs
            SolidBrush sb = new SolidBrush(Color.White);

            // This changes the colour if we're trying to draw the selected tabpage
            if (MainTabControl.SelectedIndex == e.Index)
                sb.Color = Color.White;

            // Colour the header of the current tabpage based on what we did above
            g.FillRectangle(sb, e.Bounds);

            //Remember to redraw the text - I'm always using black for title text
            g.DrawString(tp.Text, MainTabControl.Font, new SolidBrush(Color.Black), headerRect, sf);

        }

        private DataTable RegItemsXMLDT(XmlDocument xdoc, string value, DataGridView dGV)
        {

            DataTable DT = new DataTable();
            //values from XMLdocument 
            string name = string.Empty;
            string path = string.Empty;
            string bestPracticeValue = string.Empty;
            string compon = string.Empty;
            string status = string.Empty;
            string entity = string.Empty;
            XmlNodeList propList = null;

            string attributeVal = string.Empty;
            object regValue = string.Empty;

            List<Items> nonBPList = new List<Items>();

            DT.Columns.Add("Name");
            DT.Columns.Add("Value");
            DT.Columns.Add("Recommended");
            DT.Columns.Add("Path");
            DT.Columns.Add("Flagged");

            XmlNodeList entityList = xdoc.GetElementsByTagName("Entity");
            foreach (XmlNode ent in entityList)
            {
                entity = ent.Attributes["Name"].InnerText;
                if (entity == "HKCU")
                {
                    propList = xdoc.GetElementsByTagName("Property");
                }
            }

            //XmlNodeList propList = xdoc.GetElementsByTagName("Property");

            foreach (XmlNode att in propList)
            {
                name = att.Attributes["Name"].InnerText;
                path = att.Attributes["Path"].InnerText;
                bestPracticeValue = att.Attributes["BestPracticeValue"].Value;
                status = att.Attributes["Status"].InnerText;
                compon = att.Attributes["Component"].InnerText;
                bestPracticeValue = bestPracticeValue.Trim(new char[] { '"' });


                regValue = GetRegistryValue(@"HKEY_USERS\" + value + @"\" + path + @"\" + name, string.Empty);
                if (regValue == null)
                {
                    regValue = "No Value";
                }

                Items i = new Items(name, regValue.ToString(), bestPracticeValue, @"HKEY_USERS\" + value + @"\" + path + @"\" + name, name, compon);

                DataRow row = DT.NewRow();
                row["Name"] = i.Item;
                row["Value"] = i.Value;
                row["Recommended"] = i.Recommended;
                row["Path"] = i.Path;

                if (bestPracticeValue != "None")
                {


                    if (regValue.ToString() != bestPracticeValue.ToString() | !string.IsNullOrEmpty(regValue.ToString()))
                    {
                        row["Flagged"] = "Y";

                        
                        // LB.Items.Add(Utility.ConvertSID(value) + "\t" + i.Key);


                        //ListViewItem fixVI = new ListViewItem();
                        //fixVI.Content = i;
                        //FixLV.Items.Add(fixVI);



                    }
                }


                DT.Rows.Add(row);
               


            }//end of for each

            return DT;
        }


        private void RegItemsXMLHKCU(XmlDocument xdoc, string value, ListView LV)
        {

            //values from XMLdocument 
            string name = string.Empty;
            string path = string.Empty;
            string bestPracticeValue = string.Empty;
            string compon = string.Empty;
            string status = string.Empty;
            string entity = string.Empty;
            XmlNodeList propList = null;

            string attributeVal = string.Empty;
            object regValue = string.Empty;

            List<Items> nonBPList = new List<Items>();

            //Style Critical = new Style();
            //Critical.TargetType = typeof(Items);
            //Critical.Setters.Add(new Setter(Items


            XmlNodeList entityList = xdoc.GetElementsByTagName("Entity");
            foreach (XmlNode ent in entityList)
            {
                entity = ent.Attributes["Name"].InnerText;
                if (entity == "HKCU")
                {
                    propList = xdoc.GetElementsByTagName("Property");
                }
            }

            //XmlNodeList propList = xdoc.GetElementsByTagName("Property");

            foreach (XmlNode att in propList)
            {
                name = att.Attributes["Name"].InnerText;
                path = att.Attributes["Path"].InnerText;
                bestPracticeValue = att.Attributes["BestPracticeValue"].Value;
                status = att.Attributes["Status"].InnerText;
                compon = att.Attributes["Component"].InnerText;
                bestPracticeValue = bestPracticeValue.Trim(new char[] { '"' });


                regValue = GetRegistryValue(@"HKEY_USERS\" + value + @"\" + path + @"\" + name, string.Empty);
                if (regValue == null)
                {
                    regValue = "No Value";
                }

                Items i = new Items(name, regValue.ToString(), bestPracticeValue, @"HKEY_USERS\" + value + @"\" + path + @"\" + name, name, compon);

               // string[] columHeaders = { "Item", "Value", "Recommended", "Path", "Key", "Component" };
                ListViewItem lvi = new ListViewItem( new[] { i.Item, i.Value, i.Recommended,i.Path, i.Key, i.Status });
                
                LV.Items.Add(lvi);
                

                if (bestPracticeValue != "None")
                {


                    if (regValue.ToString() != bestPracticeValue.ToString() | !string.IsNullOrEmpty(regValue.ToString()))
                    {
                        // MessageBox.Show(regValue + " " + bestPracticeValue);

                        lvi.ForeColor = Color.Red;
                       // LB.Items.Add(Utility.ConvertSID(value) + "\t" + i.Key);


                        //ListViewItem fixVI = new ListViewItem();
                        //fixVI.Content = i;
                        //FixLV.Items.Add(fixVI);



                    }
                }




            }//end of for each


        }


        static object GetRegistryValue(string fullPath, object defaultValue)
        {
            string keyName = System.IO.Path.GetDirectoryName(fullPath);
            string valueName = System.IO.Path.GetFileName(fullPath);

            return Registry.GetValue(keyName, valueName, defaultValue);


       
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
             

            GetLocalFiles import = new GetLocalFiles("c:\\CodeTest", "xml");  //constructor written specificaly to only pull files that have been exported from this app 
           

            foreach (string file in import.importFilesList)             
                          
            {
                
                if (!String.IsNullOrEmpty(file))
                {
                    string fileName = Path.GetFileName(file);
                    DataGridView dGV = new DataGridView();


                    TabPage tabPage = new TabPage();
                    tabPage.BackColor = Color.White;
                    tabPage.ForeColor = Color.Black;
                    tabPage.Font = new Font("Nirmala UI", 12);
                    tabPage.Text = fileName;
                    

                    tab.TabPages.Add(tabPage);


                    dGV = new DataGridView();
                    dGV.Size = new System.Drawing.Size(tabPage.Width, tabPage.Height);
                    dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dGV.BackgroundColor = Color.White;
                    dGV.GridColor = Color.Blue;
                    dGV.AllowUserToAddRows = false;
                    dGV.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;



                    tabPage.Controls.Add(dGV); //Add Datagrid to tab object 

                    DataTable importTable = new DataTable();                    
                    importTable.ReadXmlSchema(file);
                    importTable.ReadXml(file);

                    dGV.DataSource = importTable;
                    tab.Select();
                    Analyze(); // analyze the the imported values 

                }


              
            }


            



        }


        
    }
}
