using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Translation_v1.Pl;

namespace Translation_v1
{
    public partial class Edit : Form
    {
        Search s = new Search();
    
        public Edit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ar_TextChanged(object sender, EventArgs e)
        {
            Cop.Text = " ";
            note.Text = " ";

            string word = Ar.Text;           


            DataTable data = s.S_search(word);
            if (data.Rows.Count > 0)
            {
                Cop.Text = data.Rows[0][0].ToString();              
            }
            
            DataTable datadis = s.Disc(word);
            if (datadis.Rows.Count > 0)
            {
                note.Text = datadis.Rows[0][0].ToString();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string word = Ar.Text;
            DataTable data = s.GetID(word);
            if (data.Rows.Count > 0)
            {
                string sid= data.Rows[0][0].ToString();
                int id = Int32.Parse(sid);
                s.uppdate(Cop.Text, Ar.Text, note.Text, id);
                MessageBox.Show("تم التعديل بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cop.Text = " ";
                Ar.Text = " ";
                note.Text = " ";
            }
            else
            {
                MessageBox.Show("الكلمه غير مسجله", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string word = Ar.Text;
            DataTable data = s.GetID(word);
            if (data.Rows.Count > 0)
            {
                string sid = data.Rows[0][0].ToString();
                int id = Int32.Parse(sid);
                s.delword(id);
                MessageBox.Show("تم الحذف بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cop.Text = " ";
                Ar.Text = " ";
                note.Text = " ";
            }
            else
            {
                MessageBox.Show("الكلمه غير مسجله", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }
    }
}
