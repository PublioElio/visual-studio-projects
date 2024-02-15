using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace informe_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ReportDataSource dataSource = new ReportDataSource("DataSet1", CargarApiRest());
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private List<Producto> CargarApiRest()
        {
            var client = new RestClient("https://fakestoreapi.com");
            var request = new RestRequest("/products", Method.Get);
            RestResponse response = client.Execute(request);
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(response.Content);
            return productos;
        }
    }
}