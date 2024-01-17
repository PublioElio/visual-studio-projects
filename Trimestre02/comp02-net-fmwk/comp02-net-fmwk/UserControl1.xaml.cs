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

        private void Increase(int lenght) 
        {
            if (rProgress.Width > (rBackground.Width - 3)) {
                rProgress.Width = lenght;
            }
            else {
            }
        }
    }
}
