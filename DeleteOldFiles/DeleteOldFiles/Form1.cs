using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeleteOldFiles
{
    public partial class Form1 : Form
    {
        DeleteOldFiles deleteOldFiles = null;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteOldFiles.endThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteOldFiles = new DeleteOldFiles(tbxDir.Text,Convert.ToInt32(tbxDays.Text));
            button1.Text = "running";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
