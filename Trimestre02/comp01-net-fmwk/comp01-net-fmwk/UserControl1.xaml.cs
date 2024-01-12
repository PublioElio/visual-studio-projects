using System;
using System.Collections.Generic;
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
        }

        public string Label
        {
            get => myLabel.Content.ToString();
            set => myLabel.Content = value;
        }
        public string TextBox
        {
            get => myTextBox.Text.ToString();
            set => myTextBox.Text = value;
        }

        private void MyTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            int numChar = myTextBox.Text.Length;
            string maxLentgh = "/" + myTextBox.MaxLength.ToString();
            lbCount.Content = numChar < 10 ? "0" + numChar + maxLentgh : numChar + maxLentgh;
        }
    }
}
