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

namespace examen_camionero_AdrianoDiaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> paradas;

        private void destinoBarna() {
            paradas = new List<string> { "Granada", "Jaén", "Ciudad Real", "Toledo", "Madrid", "Guadalajara", "Zaragoza", "Lérida", "Barcelona" };
        }

        private void destinoCorunya()
        {
            paradas = new List<string> { "Sevilla", "Mérida", "Cáceres", "Salamanca", "Zamora", "Orense", "Pontevedra", "Santiago", "Coruña" };
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void seleccionarDestino(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbDestino.SelectedItem;
            lbListaParadas.Items.Clear();
            if (selectedItem.Content.Equals("Barcelona"))
            {
                destinoBarna();
            }
            else if (selectedItem.Content.Equals("Coruña")) 
            {
                destinoCorunya();
            }

            foreach (string element in paradas)
            {
                lbListaParadas.Items.Add(element);
            }
            
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lbListaParadas.Items.Clear();
            lbDesglose.Items.Clear();
            checkBoxNocturnidad.IsChecked = false;
            checkBoxRemolque.IsChecked = false;
            rbAceite.IsChecked = false;
            rbFruta.IsChecked = false;
            rbPeligrosas.IsChecked = false;
            lblErrors.Content = string.Empty;
            
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            int numParadas = lbListaParadas.SelectedItems.Count, totalTarifa = 0;
            lbDesglose.Items.Clear();
            if (numParadas > 0) {
                if (!(rbAceite.IsChecked == false && rbFruta.IsChecked == false && rbPeligrosas.IsChecked == false))
                {
                    totalTarifa = calcularTarifa(numParadas);
                    mostrar_desglose(totalTarifa);
                }
                else 
                {
                    lblErrors.Content = "Debe escoger un\ntipo de mercancía";
                }     
            }
            else
            {
                lblErrors.Content = "Debe escojer al\nmenos una parada";
            }
        }

        private int calcularTarifa(int totalParadas) {
            int tarifaMercancia, totalTarifa = 0;
            if (rbAceite.IsChecked == true)
            {
                tarifaMercancia = 1000;

            }
            else if (rbFruta.IsChecked == true)
            {
                tarifaMercancia = 1200;
            }
            else
            {
                tarifaMercancia = 1200;
            }
            totalTarifa = tarifaMercancia + (totalParadas * 100);

            if (checkBoxNocturnidad.IsChecked == true)
            {
                totalTarifa += 500;
            }
            if (checkBoxRemolque.IsChecked == true)
            {
                totalTarifa += totalTarifa / 2;
            }
            return totalTarifa;
        }

        private void mostrar_desglose(int totalTarifa) {

            foreach (var listBoxItem in lbListaParadas.SelectedItems)

            {
                lbDesglose.Items.Add("Parada: " + listBoxItem + " 100€");
            }

            if (rbAceite.IsChecked == true)
            {
                lbDesglose.Items.Add("Mercancía aceite: +1000€");

            }
            else if (rbFruta.IsChecked == true)
            {
                lbDesglose.Items.Add("Mercancía fruta: +1200€");
            }
            else
            {
                lbDesglose.Items.Add("Mercancías peligrosas: +2000€");
            }

            if (checkBoxNocturnidad.IsChecked == true)
            {
                lbDesglose.Items.Add("Plus nocturnidad: +500€");
            }
            if (checkBoxRemolque.IsChecked == true)
            {
                lbDesglose.Items.Add("Plus remolque: +50% del total");
            }

            lbDesglose.Items.Add("Total tarifa: " + totalTarifa);
        }

    }
}
