using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            string rutaOriginal = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory());
            string nuevaRuta = rutaOriginal.Replace(@"\Act_01\Act_01\bin\Debug", @"\Act_01\Resources");
            openFileDialog.InitialDirectory = nuevaRuta;
            openFileDialog.Filter = "csv files | *.csv;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialog.FileName;
                Leer_Archivo(ruta);
                if (ruta.ToString().EndsWith(".csv"))
                {
                    button2.Enabled = true;
                }
            }
        }


        public void button2_Click(object sender, EventArgs e)
        {
            Form2 formulario2 = new Form2();
            formulario2.DatosTabla = ruta;
            formulario2.Show();
        }

        private void Leer_Archivo(string ruta)
        {
            if (ruta != null)
            {
                int totalLines = 0;
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        totalLines++;
                        line = sr.ReadLine();
                    }
                }

                progressBar1.Step = 7;
                while (totalLines-- > 0) {
                    Thread.Sleep(10);
                    progressBar1.PerformStep();
                }
            }
        }
    }
}

