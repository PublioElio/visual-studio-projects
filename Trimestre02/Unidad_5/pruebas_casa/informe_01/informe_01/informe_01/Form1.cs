using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace informe_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReportDataSource dataSource = new ReportDataSource("DataSet1", lista);
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);

            // Establecer la conexión con la base de datos
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=A123456a;Database=TuViajeFindeCurso";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Agencias", connection);

            // El resultado de reader es un Array (tengo que obtener datos por posiciones)
            NpgsqlDataReader reader = cmd.ExecuteReader();

            // Esta lista es donde guardaré los resultados de la consulta
            List<Agencia> lista2 = new List<Agencia>();

            while (reader.Read())
            {
                Agencia agencia = new Agencia();
                agencia.agencia_id = reader[0].ToString();
                agencia.nombre = reader[1].ToString();
                agencia.direccion = reader[2].ToString();
                agencia.telefono = reader[3].ToString();
                lista2.Add(agencia);
            }

            connection.Close();
            ReportDataSource dataSource1 = new ReportDataSource("ViajesAgencias", lista);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
