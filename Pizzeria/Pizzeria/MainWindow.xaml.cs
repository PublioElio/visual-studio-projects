using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void pedir_Click(object sender, RoutedEventArgs e)
        {
            procesarElementos(spBebidas.Children);
            procesarElementos(spTipoMasa.Children);
            procesarElementos(spIngredientes.Children);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            desmarcar(spBebidas.Children);
            desmarcar(spTipoMasa.Children);
            desmarcar(spIngredientes.Children);
            miListado.Items.Clear();
        }

        private void desmarcar(UIElementCollection elementos)
        {
            foreach (UIElement element in elementos)
                if (element is ToggleButton toggleButton)             
                    if (toggleButton.IsChecked == true)
                        toggleButton.IsChecked = false;
        }

        private void procesarElementos(UIElementCollection elementos)
        {
            foreach (UIElement element in elementos)
                if (element is ToggleButton toggleButton)
                    if (toggleButton.IsChecked == true)
                        miListado.Items.Add(toggleButton.Content);
        }

        private void rbCola_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImagenBebida("cola");
        }

        private void rb7up_Checked(object sender, RoutedEventArgs e)
        {

            cambiarImagenBebida("7up");
        }

        private void cambiarImagenBebida(string nombreImagen)
        {
            string rutaImagen = $"/{nombreImagen}.png";
            
            BitmapImage nuevaImagen = new BitmapImage(new Uri(rutaImagen, UriKind.Relative));
            
            imgBebida.Source = nuevaImagen;
        }


    }
}
