using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act_01
{
    public partial class Form1 : Form
    {
        private string ruta;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "csv files | *.csv;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialog.FileName;
            }
        }


        public void button2_Click(object sender, EventArgs e)
        {
            Form2 formulario2 = new Form2();
            formulario2.DatosTabla = ruta;
            formulario2.Show();
        }
    }
}

