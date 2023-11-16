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
using System.Windows.Shapes;

namespace formulario_calculo_salario2.View
{
    /// <summary>
    /// Lógica de interacción para calculo_salario.xaml
    /// </summary>
    public partial class calculo_salario : Window
    {
        private int MAX_SALARIO = 250000;
        private int MIN_SALARIO = 15120;
        private int MIN_EDAD = 18;
        private int MAX_EDAD = 67;
        public calculo_salario()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true; // Sólo permite introducir valores numéricos
        }

        private void txtBoxSalarioBruto_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            try
            {
                if (!int.TryParse(textBox.Text, out int number) || !(number >= MIN_SALARIO && number <= MAX_SALARIO))
                {
                    textBox.Text = string.Empty;

                    // Crear un tooltip
                    ToolTip toolTip = new ToolTip();
                    toolTip.ToolTipTitle = "Error";
                    toolTip.ToolTipIcon = ToolTipIcon.Error;
                    toolTip.IsBalloon = true;
                    toolTip.Show($"SALARIO NO VÁLIDO. Debe introducir un número entre {MIN_SALARIO} y {MAX_SALARIO}", textBox, 0, -30, 2000);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones si el valor no es un número
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }


}
