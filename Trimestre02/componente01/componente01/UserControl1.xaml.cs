using System.Text;
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

namespace componente01
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public string Label { 
            get => miLabel.Content.ToString();
            set => miLabel.Content = value;
        }        
        public string TextBox { 
            get => miTextBox.Text.ToString();
            set => miTextBox.Text = value;
        }

        /*
        public string GetLabel() => miLabel.Content.ToString();

        public void SetLabel(string content) => miLabel.Content = content;        
        
        public string GetTextBox() => miTextBox.Text.ToString();

        public void SetTextBox(string text) => miTextBox.Text = text;
        */
    }

}
