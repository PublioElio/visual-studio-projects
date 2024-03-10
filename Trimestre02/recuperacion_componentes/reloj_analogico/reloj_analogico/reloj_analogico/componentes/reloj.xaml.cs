using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace reloj_analogico.componentes
{
    /// <summary>
    /// Lógica de interacción para reloj.xaml
    /// </summary>
    public partial class reloj : UserControl
    {
        [Description("Manecilla horas"), Category("Mi categoria"), DisplayName("Hora")]
        public int Hora { get; set; }
        [Description("Manecilla minutos"), Category("Mi categoria"), DisplayName("Minutos")]
        public int Min { get; set; }
        [Description("Manecilla segundos"), Category("Mi categoria"), DisplayName("Segundos")]
        public int Sec { get; set; }
        public reloj()
        {
            InitializeComponent();
        }
        public void ActualizarHora(int valor) {
            anguloHora.Angle = valor / 30;
        }
        public void ActualizarMin(int valor)
        {
            anguloMinutos.Angle = valor / 6;
        }
        public void ActualizarSec(int valor)
        {
            anguloSegundos.Angle = valor / 6;
        }
    }
}
