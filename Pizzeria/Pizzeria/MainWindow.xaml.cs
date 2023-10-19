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
            ProcesarElementos(spBebidas.Children);
            ProcesarElementos(spTipoMasa.Children);
            ProcesarElementos(spIngredientes.Children);
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
            {
                if (element is ToggleButton toggleButton)
                {

                    if (toggleButton.IsChecked == true)
                    {
                        toggleButton.IsChecked = false;
                    }
                }
            }
        }

        private void ProcesarElementos(UIElementCollection elementos)
        {
            foreach (UIElement element in elementos)
            {
                if (element is ToggleButton toggleButton)
                {
                    
                    if (toggleButton.IsChecked == true)
                    {
                        miListado.Items.Add(toggleButton.Content);
                    }
                }
            }
        }

    }
}
