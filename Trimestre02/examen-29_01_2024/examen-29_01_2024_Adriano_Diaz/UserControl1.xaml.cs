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
        }

        [Description("Número máximo de elementos del List Box"), Category("Mi categoria"), DisplayName("Número máximo de elementos")]
        public int ListBoxMaxElements
        {
            get => ListBoxMaxItems;
            set
            {
                ListBoxMaxItems = value;
                modificarSlider(ListBoxMaxItems);
            }
        }
        private void modificarSlider(int listBoxMaxItems)
        {
            miSlider.Value = listBoxMaxItems;
        }

        [Description("Número máximo de caracteres del Text Box"), Category("Mi categoria"), DisplayName("Número máximo de caracteres del Text Box")]
        public int TextboxMaxlenght
        {
            get => miTextBox.MaxLength;
            set => miTextBox.MaxLength = value;
        }

        /*
        [Description("Color de fondo del Slider"), Category("Mi categoria"), DisplayName("Color de fondo del Slider")]
        public Brush SliderBackground {
            get => miSlider.Brush
            set => miSlider.Background.

        }*/
        private void PulsarEnter(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (miListBox.Items.Count < ListBoxMaxItems))
            {
                miListBox.Items.Add(miTextBox.Text);
                miTextBox.Text = string.Empty;
                ComprobarCapacidadListBox();
            }
        }
        private void ComprobarCapacidadListBox()
        {
            if (miListBox.Items.Count == ListBoxMaxItems)
            {
                miTextBox.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {

            }
        }

        // 3. Cada vez que los elementos del listbox cambian se actualiza el slider,
        // cuyo máximo coincidirá con el número máximo de elementos del listbox.
        // El usuario no puede modificar el slider manualmente. (1 pto.)

        // 4. Cuando el listbox llega al límite de su capacidad,
        // el color del textbox se cambia a rojo y ya no se pueden
        // seguir introduciendo datos. (1 pto.)
    }
}
