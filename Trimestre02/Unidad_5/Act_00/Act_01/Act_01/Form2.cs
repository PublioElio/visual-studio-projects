using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act_01
{
    public partial class Form2 : Form
    {
        private string datos;

        public string DatosTabla { get => datos; set => datos = value; }

        public Form2()
        {
            InitializeComponent();
            //List<Class1> lista = datos;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Class1> lista = new List<Class1>();
            StreamReader sr = new StreamReader(datos);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                foreach (Class1 registro in lista)
                {
                    registro.levelType = fields[0];
                    registro.code = fields[1];
                    registro.name = fields[2];
                    registro.description = fields[3];
                    registro.sourceLink = fields[4];

                }
                line = sr.ReadLine();
            }
            ReportDataSource dataSource = new ReportDataSource("DataSet1", lista);
            this.reportViewer1.RefreshReport();
        }
    }
}