using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.WebRequestMethods;

namespace comp04_net_fmwk
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Se puede elegir el directorio donde se abre por defecto la ventana del explorador
            // openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "Image files | *.jpg; *.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName; // Guardo el path del archivo
                // Para indicar al IDE que un string es una ruta tenemos que indicarlo con una arroba delante del string @"c:\users\user1\img.bmp"
                compImgLeyenda.RecursoImagen = new BitmapImage(new Uri(path));
                // string[] strings = openFileDialog.FileName.Split('\\');
                // compImgLeyenda.TextoLeyenda = System.IO.Path.GetFileNameWithoutExtension(strings[strings.Length - 1]);
                compImgLeyenda.TextoLeyenda = System.IO.Path.GetFileNameWithoutExtension(path);
            }
        }
    }
}
