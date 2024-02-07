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
using System.Xml.Linq;

namespace Act_01
{
    public partial class Form2 : Form
    {
        private string datos;

        public string DatosTabla { get => datos; set => datos = value; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Class1> lista = new List<Class1>();
            if (!string.IsNullOrEmpty(datos) && File.Exists(datos))
            {
                using (StreamReader sr = new StreamReader(datos))
                {
                    string line = sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        Class1 registro = new Class1();
                        registro.levelType = fields[0];
                        registro.code = fields[1];
                        registro.catalogType = fields[2];
                        registro.name = fields[3];
                        registro.description = fields[4];
                        registro.sourceLink = fields[5];
                        lista.Add(registro);
                    }
                }
            }
            ReportDataSource dataSource = new ReportDataSource("DataSet1", lista);
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }

    }
}