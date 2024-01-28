using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
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

namespace comp01_net_fmwk
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            ContarCaracteres();
        }

        [Description("Número máximo de caracteres del Text Box"), Category("Mi categoria"), DisplayName("Número máximo de caracteres del Text Box")]
        public int TextboxMaxlenght 
        {
            get => myTextBox.MaxLength;
            set {
                myTextBox.MaxLength = value;
                ContarCaracteres();
            } 
        }

        [Description("Label junto al progreso"), Category("Mi categoria"), DisplayName("Texto del Label")]
        public string Label
        {
            get => myLabel.Content.ToString();
            set
            {
                if (myLabel != null)
                    myLabel.Content = value;
            }
        }
        [Description("Texto del Text Box"), Category("Mi categoria"), DisplayName("Texto del Text Box")]
        public string TextBoxText
        {
            get => myTextBox.Text.ToString();
            set
            {
                if (myTextBox != null)
                    myTextBox.Text = value;
            }
        }

        [Description("La cantidad de caracteres que hay en el Text Box"), Category("Mi categoria"), DisplayName("Total de caracteres del Text Box")]
        public int TextLength
        {
            get => myTextBox.Text.Length;
        }

        [Description("Informa si hay algún cambio en el texto en el Text Box")]
        public event EventHandler textChanged;

        private void MyTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            ContarCaracteres();
            if (textChanged != null) {
                textChanged(this, new EventArgs());
            }
        }

        private void ContarCaracteres() {
            lbContar.Content = myTextBox.Text.Length.ToString() + "/" + myTextBox.MaxLength.ToString();
        }

    }
}
