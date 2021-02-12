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
    public partial class Addword : Form
    {
        readonly
        Search s = new Search();
        public Addword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Cop.Text !="" && Ar.Text != "" && note.Text != "")
            {
                s.addword(Cop.Text, Ar.Text, note.Text);
                MessageBox.Show("تمت الاضافه بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("قم بملئ جميع الحقول", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Addword_Load(object sender, EventArgs e)
        {

        }
    }
}
