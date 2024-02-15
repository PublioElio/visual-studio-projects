using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Npgsql;
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
        public List<string> ListaElementos { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.destinosTableAdapter.Fill(this.tuViajeFindeCursoDataSet.destinos);
            this.clientesTableAdapter.Fill(this.tuViajeFindeCursoDataSet.clientes);
            this.agenciasTableAdapter.Fill(this.tuViajeFindeCursoDataSet.agencias);

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
            
            // Establecer la conexión con la base de datos
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=A123456a;Database=TuViajeFindeCurso";
            // Le paso el string a un nuevo objeto NpgsqlConnection
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            // Abro la conexión
            connection.Open();

            // Creo la sentencia SQL para la consulta
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Agencias", connection);

            // El resultado de reader es un Array
            NpgsqlDataReader reader = cmd.ExecuteReader();

            // Esta lista es donde guardaré los resultados de la consulta
            List<Agencia> lista2 = new List<Agencia>();
            
            // Itero por el readeader y guardo los resultados en la lista
            while (reader.Read())
            {
                Agencia agencia = new Agencia();
                agencia.agencia_id = reader[0].ToString();
                agencia.nombre = reader[1].ToString();
                agencia.direccion = reader[2].ToString();
                agencia.telefono = reader[3].ToString();
                lista2.Add(agencia);
            }

            // Ya tengo la lista, cierro conexión y creo un objeto ReportDataSource, pasándole un string (nombre) y la lista
            connection.Close();
            ReportDataSource dataSource1 = new ReportDataSource("AgenciasSQL", lista2);
            this.reportViewer1.RefreshReport();
            
        }
    }
}