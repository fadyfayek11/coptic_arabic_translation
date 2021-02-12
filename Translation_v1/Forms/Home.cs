using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translation_v1.database;
using Translation_v1.Pl;

namespace Translation_v1
{
    public partial class Home : Form
    {
        Search s = new Search();
        ArrayList list = new ArrayList();
        bool flag = true;


        public Home()
        {
            InitializeComponent();            
            
        }      
       

        private void arabic_TextChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                copt.Text = " ";
                morewords.Text = " ";
                discription.Text = " ";

                string word = arabic.Text;
                string[] textSplit = word.Split(" ");


                DataTable data = s.S_search(word);
                if (data.Rows.Count > 0)
                {
                    copt.Text += data.Rows[0][0].ToString();

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            morewords.Text += data.Rows[i][j].ToString();
                            morewords.Text += "\n";
                        }
                    }


                }
                else
                {
                    copt.Text = " ";
                    foreach (string item in textSplit)
                    {
                        list.Add(item);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        DataTable dataline = s.S_search(list[i].ToString());
                        if (dataline.Rows.Count > 0)
                        {

                            copt.Text += dataline.Rows[0][0].ToString();
                            copt.Text += "  ";
                            /*for (int v = 0; v < dataline.Rows.Count; v++)
                            {

                                for (int j = 0; j < dataline.Columns.Count; j++)
                                {
                                    copt.Text += dataline.Rows[v][j].ToString();
                                    copt.Text += "  ";
                                }
                            }*/
                        }
                        else
                        {
                            morewords.Text = "غير مسجل";
                            //MessageBox.Show("Not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    list.Clear();
                }

                DataTable datadis = s.Disc(word);
                if (datadis.Rows.Count > 0)
                {
                    discription.Text = datadis.Rows[0][0].ToString();
                }
                else
                {
                    discription.Text = "لا توجد ملاحظات";
                }


            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       

        private void copt_TextChanged(object sender, EventArgs e)
        {
            if (!flag)
            {
                arabic.Text = " ";
                morewords.Text = " ";
                discription.Text = " ";

                string word = copt.Text;
                string[] textSplit = word.Split(" ");


                DataTable data = s.coptsearch(word);
                if (data.Rows.Count > 0)
                {
                    arabic.Text += data.Rows[0][0].ToString();

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            morewords.Text += data.Rows[i][j].ToString();
                            morewords.Text += "\n";
                        }
                    }


                }
                else
                {
                    
                    foreach (string item in textSplit)
                    {
                        list.Add(item);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        DataTable dataline = s.coptsearch(list[i].ToString());
                        if (dataline.Rows.Count > 0)
                        {

                            arabic.Text += dataline.Rows[0][0].ToString();
                            arabic.Text += "  ";
                            /*for (int v = 0; v < dataline.Rows.Count; v++)
                            {

                                for (int j = 0; j < dataline.Columns.Count; j++)
                                {
                                    morewords.Text += dataline.Rows[v][j].ToString();
                                    morewords.Text += "\n";                                
                                }
                            }*/
                        }
                        else
                        {
                            morewords.Text = "غير مسجل";
                            //MessageBox.Show("Not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    list.Clear();
                }

                DataTable datadis = s.Disc(word);
                if (datadis.Rows.Count > 0)
                {
                    discription.Text = datadis.Rows[0][0].ToString();
                }
                else
                {
                    discription.Text = "لا توجد ملاحظات";
                }

            }

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Addword f = new Addword();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Edit f = new Edit();
            f.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
   
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            

            if (flag)
            {
                label1.Visible = false;
                label2.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;                
               


                labelcopt.Visible = true;
                labelAr.Visible = true;
                panelcopt.Visible = true;
                panelAr.Visible = true;


                copt.Location = new Point(509, 0);
                arabic.Location = new Point(0, 0);
                copt.ReadOnly = false;
                arabic.ReadOnly = true;
                copt.TextAlign = HorizontalAlignment.Left;

                copt.Text = " ";
                arabic.Text = " ";

                flag = false;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;

                


                labelcopt.Visible = false;
                labelAr.Visible = false;
                panelcopt.Visible = false;
                panelAr.Visible = false;


                copt.Location = new Point(0, 0);
                arabic.Location = new Point(509, 0);
                copt.ReadOnly = true;                
                arabic.ReadOnly = false;
                copt.Text = " ";
                arabic.Text = " ";
                flag = true;
            }         


        }

        
    }
}
