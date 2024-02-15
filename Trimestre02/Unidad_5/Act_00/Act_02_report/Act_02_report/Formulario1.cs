
using Nancy.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace Act_02_report
{
    public partial class Formulario1 : Form
    {
        public Formulario1()
        {
            InitializeComponent();
        }

        private void CargarApiRest()
        {
            var client = new RestClient("https://fakestoreapi.com");
            var request = new RestRequest("/products", Method.Get);
            RestResponse response = client.Execute(request);
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(response.Content);
        }

        /*
        private async Task CargarDatosAsincrono()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://fakestoreapi.com/products");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(jsonResponse);

                    DataSet dataSet = new DataSet();

                }
            }
        }*/
    }
}
