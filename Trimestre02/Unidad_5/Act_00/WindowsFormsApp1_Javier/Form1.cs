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

namespace WindowsFormsApp1_Javier
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

            list.Add(new Class1 {id=1,nombre="Antonio",apellidos="Díaz" });
            ReportDataSource report = new ReportDataSource("DataSet1", list);
            this.reportViewer1.LocalReport.DataSources.Add(report);
            this.reportViewer1.RefreshReport();
        }
    }
}
