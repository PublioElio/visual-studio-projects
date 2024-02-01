using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace comp04_net_fmwk
{
    /// <summary>
    /// Lógica de interacción para imgLeyenda.xaml
    /// </summary>
    public partial class imgLeyenda : UserControl
    {
        public imgLeyenda()
        {
            InitializeComponent();
        }

        [Description("Texto de la leyenda"), Category("Mi categoria"), DisplayName("Leyenda")]
        public string TextoLeyenda { get => TextBoxLeyenda.Text; set => TextBoxLeyenda.Text = value; }

        [Description("Contenido imagen"), Category("Mi categoria"), DisplayName("Contenido imagen")]
        public ImageSource RecursoImagen
        {
            get => ImgCentral.Source;
            set
            {
                if (value != null)
                {
                    ImgCentral.Source = value;
                    BorderImg.BorderBrush = new SolidColorBrush(Colors.Transparent);
                }
            }
        }

        private void Img_MouseWeel(object sender, MouseWheelEventArgs e)
        {

        }
    }
}
