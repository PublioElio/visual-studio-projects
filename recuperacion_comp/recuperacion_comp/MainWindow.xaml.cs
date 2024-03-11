using System;
using System.Collections.Generic;
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

namespace recuperacion_comp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SliderGolesEquipo1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Marcador.GolesEquipo1 = (int)SliderGolesEquipo1.Value;
        }

        private void SliderGolesEquipo2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Marcador.GolesEquipo2 = (int)SliderGolesEquipo2.Value;
        }

        private void ComboBoxTiempoPartido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTiempoPartido.SelectedItem.Equals(primer_tiempo))
            {
                Marcador.MinutosActuales = 0;
                Marcador.SegundosActuales = 0;
                TextBoxAnyadirTiempo.Text = "0";
            }
            else { 
                Marcador.MinutosActuales = 45;
                Marcador.SegundosActuales = 0;
                TextBoxAnyadirTiempo.Text = "0";
            }
        }

        private void ButtoRestarMin_Click(object sender, RoutedEventArgs e)
        {
            int minutos = int.Parse(TextBoxAnyadirTiempo.Text);
            if (minutos > 0)
            {
                minutos--;
                TextBoxAnyadirTiempo.Text = minutos.ToString();
            }
        }

        private void ButtoSumarMin_Click(object sender, RoutedEventArgs e)
        {
            int minutos = int.Parse(TextBoxAnyadirTiempo.Text);
            if (minutos < 20)
            {
                minutos++;
                TextBoxAnyadirTiempo.Text = minutos.ToString();
            }
        }
    }
}
