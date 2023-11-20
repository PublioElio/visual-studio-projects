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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cambio_divisas
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

        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true; // Sólo permite introducir valores numéricos
        }

        private void cbDivisa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbDivisa.SelectedItem;

            if (selectedItem != null)
            {
                if (selectedItem.Name == "euro")
                {
                    checkEuro.IsEnabled = false;
                    checkEuro.IsChecked = false;
                    checkDolar.IsEnabled = true;
                }
                else if (selectedItem.Name == "dolar")
                {
                    checkDolar.IsEnabled = false;
                    checkDolar.IsChecked = false;
                    checkEuro.IsEnabled = true;
                }
            }
        }


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbDivisa.SelectedItem;
            double porcentaje = 0;
            double resultado = 0;
            string cantidad = textBoxCantidad.Text;

            if (selectedItem != null) // compruebo que ha seleccionado una divisa origen
            {
                lblErrors.Content = string.Empty;

                if (!string.IsNullOrEmpty(cantidad)) // compruebo que ha introducido una cantidad
                {
                    lblErrors.Content = string.Empty;

                    if ((Boolean)rbEfectivo.IsChecked)
                    {
                        porcentaje = 1;
                    }
                    else if ((Boolean)rbTransferencia.IsChecked)
                    {
                        porcentaje = 2;
                    }
                    else if ((Boolean)rbTransferencia.IsChecked)
                    {
                        porcentaje = 3;
                    }
                    if (porcentaje > 0) // compruebo que ha seleccionado una forma de pago
                    {
                        lblErrors.Content = string.Empty;
                        if (HayCheckboxMarcado()) // compruebo que ha marcado alguna divisa destino
                        {
                            lblErrors.Content = string.Empty;
                            if ((Boolean)checkBoxClienteHab.IsChecked)
                            {
                                porcentaje -= 0.25;
                            }

                            if ((Boolean)checkEuro.IsChecked)
                            {
                                if (selectedItem.Equals(dolar))
                                {
                                    resultado = Double.Parse(cantidad) * 1.09;
                                }
                                listBoxResult.Items.Add("Euros: " + resultado);
                            }
                            if ((Boolean)checkDolar.IsChecked)
                            {
                                if (selectedItem.Equals(euro))
                                {
                                    resultado = Double.Parse(cantidad) * 0.92;
                                }
                                listBoxResult.Items.Add("Dólares: " + resultado);
                            }
                            if ((Boolean)checkLibra.IsChecked)
                            {
                                if (selectedItem.Equals(euro))
                                {
                                    resultado = Double.Parse(cantidad) * 1.14;
                                }
                                else if (selectedItem.Equals(dolar))
                                {
                                    resultado = Double.Parse(cantidad) * 1.25;
                                }
                                listBoxResult.Items.Add("Libras: " + resultado);
                            }
                            if ((Boolean)checkYen.IsChecked)
                            {
                                if (selectedItem.Equals(euro))
                                {
                                    resultado = Double.Parse(cantidad) * 162.68;
                                }
                                else if (selectedItem.Equals(dolar))
                                {
                                    resultado = Double.Parse(cantidad) * 148.95;
                                }
                                listBoxResult.Items.Add("Yenes: " + resultado);
                            }
                            if ((Boolean)checkFranco.IsChecked)
                            {
                                if (selectedItem.Equals(euro))
                                {
                                    resultado = Double.Parse(cantidad) * 0.97;
                                }
                                else if (selectedItem.Equals(dolar))
                                {
                                    resultado = Double.Parse(cantidad) * 0.88;
                                }
                                listBoxResult.Items.Add("Francos suizos: " + resultado);
                            }
                        }
                        else
                        {
                            lblErrors.Content = "Escoja una divisa destino";
                        }
                    }
                    else
                    {
                        lblErrors.Content = "Escoja un método de pago";
                    }
                }
                else
                {
                    lblErrors.Content = "Debe insertar una cantidad";
                }
            }
            else
            {
                lblErrors.Content = "Debe escoger una divisa de origen";
            }
        }


        public bool HayCheckboxMarcado()
        {
            {
                foreach (var child in spDivisaDest.Children)
                {
                    if (child is CheckBox checkBox && checkBox.IsChecked == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}

