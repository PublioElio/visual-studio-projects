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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void pedir_Click(object sender, RoutedEventArgs e)
        {
            miListado.Items.Clear();

            if ((bool)rbQueso.IsChecked) 
                miListado.Items.Add(rbQueso.Content);
            else if ((bool)rbFina.IsChecked)
                miListado.Items.Add(rbFina.Content);
            else if ((bool)rbClasica.IsChecked)
                miListado.Items.Add(rbClasica.Content);

            if ((bool)rbCola.IsChecked)
                miListado.Items.Add(rbCola.Content);
            else if ((bool)rb7up.IsChecked)
                miListado.Items.Add(rb7up.Content);
            else if ((bool)rbFanta.IsChecked)
                miListado.Items.Add(rbFanta.Content);
            else if ((bool)rbAgua.IsChecked)
                miListado.Items.Add(rbAgua.Content);

            if ((bool)cbMozzarella.IsChecked)
                miListado.Items.Add(cbMozzarella.Content);
            if ((bool)cbJamon.IsChecked)
                miListado.Items.Add(cbJamon.Content);
            if ((bool)cbChamp.IsChecked)
                miListado.Items.Add(cbChamp.Content);
            if ((bool)rbAgua.IsChecked)
                miListado.Items.Add(rbAgua.Content);

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in containerCanvas.Children)
            {
                if (ctl.GetType() == typeof(CheckBox))
                    ((CheckBox)ctl).IsChecked = false;
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
        }
    }
}
