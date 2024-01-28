using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace comp02_net_fmwk
{
    /// <summary>
    /// Lógica de interacción para CustomProgressBar.xaml
    /// </summary>
    public partial class CustomProgressBar : UserControl
    {
        public CustomProgressBar()
        {
            InitializeComponent();
        }

        [Description("Porcentaje de progreso en la barra"), Category("Mi categoria"), DisplayName("Porcentaje de progreso en la barra")]
        public int Value
        {
            get
            {
                string porcentaje = lbProgress.Content.ToString();
                int valor;
                if (!int.TryParse(new string(porcentaje.Where(char.IsDigit).ToArray()), out valor))
                {
                    valor = 0;
                }
                return valor;
            }
            set
            {
                value = (value < 0) ? 0 : (value > 100) ? 100 : value;
                lbProgress.Content = $"{value}%";
                rProgress.Width = (value * (rBackground.Width - 6)) / 100;
                ChangeColor(value);
            }
        }

        private void ChangeColor(int width)
        {
            if (width >= 25 && width < 50)
            {
                rProgress.Fill = new SolidColorBrush(Colors.CadetBlue);
            }
            else if (width >= 50 && width < 75)
            {
                rProgress.Fill = new SolidColorBrush(Colors.GreenYellow);
            }
            else if (width >= 75)
            {
                rProgress.Fill = new SolidColorBrush(Colors.IndianRed);
            }
            else
            {
                rProgress.Fill = new SolidColorBrush(Colors.CornflowerBlue);
            }
        }


    }
}
