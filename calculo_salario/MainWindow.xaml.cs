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
using static System.Net.Mime.MediaTypeNames;

namespace calculo_salario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int MAX_SALARIO = 250000;
        private int MIN_SALARIO = 15120;
        private int MIN_EDAD = 18;
        private int MAX_EDAD = 67;

        public MainWindow()
        {
            InitializeComponent();
            comboBoxSitFamiliar.SelectedIndex = 0;
        }

        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Sólo permite introducir valores numéricos
            }
        }

        private void txtBoxSalarioBruto_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox textBox = sender as TextBox;
            int.TryParse(textBox.Text, out int number);
            if (!(number >= MIN_SALARIO && number <= MAX_SALARIO))
            {
                textBox.Text = string.Empty;
                MessageBox.Show("SALARIO NO VÁLIDO. Debe introducir un número entre " + MIN_SALARIO + " y " + MAX_SALARIO);
            }
        }

        private void txtBoxEdad_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int.TryParse(textBox.Text, out int number);
            if (!(number >= MIN_EDAD && number <= MAX_EDAD))
            {
                textBox.Text = string.Empty;
                MessageBox.Show("EDAD NO VÁLIDA. Debe introducir un número entre " + MIN_EDAD + " y " + MAX_EDAD);
            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxEdad.Text) || string.IsNullOrEmpty(txtBoxSalarioBruto.Text))
                MessageBox.Show("Debe cumplimentar los campos EDAD y SALARIO BRUTO");
            else
            {

                int.TryParse(txtBoxSalarioBruto.Text, out int salario);
                double porcentaje = calcularPorcentaje(salario);

                // Pagas
                int numeroPagas = radio12.IsChecked == true ? 12 : 14;

                double salarioFinal = salario * (1 + porcentaje) / numeroPagas;
                txtBoxResultado.Text = salarioFinal.ToString();
            }
        }

        private double calcularPorcentaje(int salario)
        {
            double porcentaje = 0;

            // Edad
            if (int.TryParse(txtBoxEdad.Text, out int edad))
            {
                if (edad >= 50)
                    porcentaje -= 0.02;
                else if (edad >= 20 && edad < 50)
                    porcentaje += 0.01;
            }

            // Salario Bruto
            if (salario <= 15000)
                porcentaje += 0.08;
            else if (salario <= 30000)
                porcentaje += 0.15;
            else if (salario > 30000)
                porcentaje += 0.20;


            // Estado civil
            ComboBoxItem estadoCivil = comboBoxSitFamiliar.SelectedItem as ComboBoxItem;
            if (estadoCivil != null)
            {
                switch (estadoCivil.Content.ToString())
                {
                    case "Soltero":
                        porcentaje += 0.02;
                        break;
                    case "Viudo":
                        porcentaje -= 0.02;
                        break;
                    case "Divorciado":
                        porcentaje -= 0.01;
                        break;
                }
            }

            // Discapacidad
            if (toggleBtnDiscapacidad.IsChecked == true)
                porcentaje -= 0.05;

            // Movilidad geográfica
            if (cbMovGeografica.IsChecked == true)
                porcentaje -= 0.01;

            return porcentaje;
        }
    }
}
