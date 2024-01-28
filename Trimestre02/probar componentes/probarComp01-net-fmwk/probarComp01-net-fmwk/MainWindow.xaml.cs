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

namespace probarComp01_net_fmwk
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            componenteTexto.textChanged += ComponenteTexto_textChanged;
        }

        private void btnIncrementar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            int.TryParse(tbValorIncremento.Text, out valor);
            progressBar.Value = Math.Min(100, progressBar.Value + valor);
        }

        private void tbValorIncremento_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbValorIncremento.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                tbValorIncremento.Text = tbValorIncremento.Text.Remove(tbValorIncremento.Text.Length - 1);
            }
        }

        private void btnDecrementar_Click(object sender, RoutedEventArgs e)
        {
            int valor;
            int.TryParse(tbValorIncremento.Text, out valor);
            progressBar.Value = Math.Max(0, progressBar.Value - valor);
        }

        private void ComponenteTexto_textChanged(object sender, EventArgs e)
        {
            progressBar.Value = CalcularProgreso(componenteTexto.TextLength, componenteTexto.TextboxMaxlenght);
        }

        private int CalcularProgreso(int valorActual, int valorMaximo){
            return (valorActual * 100) / valorMaximo;
        }
    }

}
