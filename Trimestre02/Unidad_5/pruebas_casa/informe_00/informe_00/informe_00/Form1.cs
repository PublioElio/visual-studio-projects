using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace informe_00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Class1> list = new List<Class1>();

            list.Add(new Class1{Id=00,Name= "John Carpenter", Description="Director" });
            list.Add(new Class1{Id=01,Name= "Alan Moore", Description="Guionista" });
            list.Add(new Class1{Id=02,Name= "Neil Gaiman", Description="Escritor" });
            list.Add(new Class1{Id=03,Name= "Bruce Campbell", Description="Actor" });

            ReportDataSource dataSource = new ReportDataSource("DataSet1", list);

            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
