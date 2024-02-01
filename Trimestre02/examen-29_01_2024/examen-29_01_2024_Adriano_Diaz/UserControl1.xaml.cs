using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace examen_29_01_2024_Adriano_Diaz
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private int ListBoxMaxItems = 0;
        public UserControl1()
        {
            InitializeComponent();
            ComprobarCapacidadListBox();
        }

        [Description("Número máximo de elementos del List Box"), Category("Mi categoria"), DisplayName("Número máximo de elementos")]
        public int ListBoxMaxElements
        {
            get => ListBoxMaxItems;
            set
            {
                if (value >= 0)
                {
                    ListBoxMaxItems = value;
                    miSlider.Maximum = value;
                    ComprobarCapacidadListBox();
                }
            }
        }

        [Description("Número máximo de caracteres del Text Box"), Category("Mi categoria"), DisplayName("Número máximo de caracteres del Text Box")]
        public int TextboxMaxlenght
        {

            get => miTextBox.MaxLength;
            set
            {
                if (value >= 0) { miTextBox.MaxLength = value; }
            }
        }

        // Poner en las búsquedas WPF
        [Description("Color de fondo del Slider"), Category("Mi categoria"), DisplayName("Color de fondo del Slider")]
        public Brush SliderBackground
        {
            get => miSlider.Background;
            set => miSlider.Background = value;

        }
         
        public ItemCollection ObtenerElementosListBox()
        {
            return miListBox.Items;
        }

        [Description("Informa si se introduce algún elemento en el List Box")]
        public event EventHandler ListBoxModificado;

        private void PulsarEnter(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (miListBox.Items.Count < ListBoxMaxItems))
            {
                miListBox.Items.Add(miTextBox.Text);
                miTextBox.Text = string.Empty;
                ModificarSlider();
                ComprobarCapacidadListBox();
                if (ListBoxModificado != null) { ListBoxModificado(this, new EventArgs()); }
            }
        }

        private void ModificarSlider()
        {
            miSlider.Value = miListBox.Items.Count;
        }

        private void ComprobarCapacidadListBox()
        {
            if (miListBox.Items.Count == ListBoxMaxItems)
            {
                miTextBox.Background = new SolidColorBrush(Colors.Red);
                miTextBox.IsEnabled = false;
            }
            else
            {
                miTextBox.IsEnabled = true;
                miTextBox.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void BorrarElementoListBox(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Delete) || (e.Key == Key.Back))
            {
                if (miListBox.SelectedIndex != -1)
                {
                    // miListBox.Items.RemoveAt(miListBox.SelectedIndex);
                    miListBox.Items.Remove(miListBox.SelectedItem);
                    ComprobarCapacidadListBox();
                    ModificarSlider();
                }
            }
        }

        private void ListBoxChanged(object sender, SizeChangedEventArgs e)
        {
            //if (ListBoxModificado != null) { ListBoxModificado(this, new EventArgs()); }
        }
    }
}
