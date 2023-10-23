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

        // Aquí debajo empiezan los botones y sus eventos

        private void pedir_Click(object sender, RoutedEventArgs e)
        {
            processElements(spBebidas.Children);
            processElements(spTipoMasa.Children);
            processElements(spIngredientes.Children);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            uncheck(spBebidas.Children);
            uncheck(spTipoMasa.Children);
            uncheck(spIngredientes.Children);
            miListado.Items.Clear();
        }

        private void uncheck(UIElementCollection elements)
        {
            foreach (UIElement element in elements)
                if (element is ToggleButton toggleButton && toggleButton.IsChecked == true)
                    toggleButton.IsChecked = false;

            limpiarImagenesEnGrid(ventanaPrincipal); // este método limpia todas las imágenes en la ventana principal, menos la de Mario
        }

        private void limpiarImagenesEnGrid(Grid grid)
        {
            foreach (UIElement element in grid.Children)
                if (element is Image image && image.Name != "mario")
                    image.Source = null;
            
        }

        private void processElements(UIElementCollection elements)
        {
            foreach (UIElement element in elements)
                if (element is ToggleButton toggleButton && toggleButton.IsChecked == true)
                    miListado.Items.Add(toggleButton.Content);
        }

        // Aquí los RadioButton de las bebidas y su método para cambiar la imagen

        private void rbCola_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgBebida("cola");
        }

        private void rb7up_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgBebida("sevenup");

        }

        private void rbFanta_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgBebida("fanta");
        }

        private void rbAgua_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgBebida("agua");
        }

        private void cambiarImgBebida(string imageSrc) {

            Uri uri = new Uri($"/{imageSrc}.png", UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage(uri);
            imgBebida.Source = bitmapImage;

        }

        // Aquí los RadioButton de la masa y su método para cambiar la imagen

        private void rbQueso_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgMasa("queso");
        }

        private void rbFina_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgMasa("fina");
        }

        private void rbClasica_Checked(object sender, RoutedEventArgs e)
        {
            cambiarImgMasa("clasica");
        }

        private void cambiarImgMasa(string imageSrc)
        {

            Uri uri = new Uri($"/{imageSrc}.png", UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage(uri);
            imgMasa.Source = bitmapImage;

        }
    }
}
