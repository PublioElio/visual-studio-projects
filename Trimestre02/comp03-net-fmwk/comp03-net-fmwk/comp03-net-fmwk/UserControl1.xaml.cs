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


namespace comp03_net_fmwk
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private int hora;
        private int minutos;
        public UserControl1()
        {
            InitializeComponent();
            MostrarTiempo(hora, minutos);
        }

        private void MostrarTiempo(int hora, int minutos) {
            if (hora < 10)
            {
                PintarHora("0" + hora);
            }
            else if (hora > 9 && hora < 24)
            {
                PintarHora(hora + "");
            }
            else {
                PintarHora("00");
            }

        }

        private void PintarHora(string hora) {

            if (!string.IsNullOrEmpty(hora))
            {
                char decenas = hora[0];
                char unidades = hora[1];
            }
        }

        private void PintarDigito(char digito, int posicion) {

            
        }
    }
}
