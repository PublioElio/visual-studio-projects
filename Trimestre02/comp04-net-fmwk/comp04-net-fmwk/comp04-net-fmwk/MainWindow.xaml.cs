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
            openFileDialog.Filter = "Image files | *.jpg; *.png;";
            if (openFileDialog.ShowDialog() == true) {
                compImgLeyenda.RecursoImagen = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                string[] strings = openFileDialog.FileName.Split('\\');
                compImgLeyenda.TextoLeyenda = System.IO.Path.GetFileNameWithoutExtension(strings[strings.Length - 1]);
            }
                
        }



    }
}
