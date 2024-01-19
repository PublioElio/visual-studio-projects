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
using System.Windows.Threading;

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
        [Description("Porcentaje de progreso en la barra")]
        public int Value
        {
            get => (int)lbProgress.Content;
            set 
            {
                value = (value < 0) ? 0 : (value > 100) ? 100 : value;
                lbProgress.Content = $"{value}%";
                rProgress.Width = (value * (rBackground.Width - 6)) / 100;
                ChangeColor(value);
            } 
        }

        private void ChangeColor(int width) {
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
