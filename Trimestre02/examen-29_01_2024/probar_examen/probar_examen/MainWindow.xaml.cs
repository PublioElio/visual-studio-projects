using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace probar_examen
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //compExamen.ListBoxModificado += parpadeoImg();
        }
        
        private EventHandler parpadeoImg(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer;  //Declared in your 'Form.Designer.cs'
            timer.Interval = 1000; //Equals the 1 second
            timer.Start(); //Always use 'Timer.Stop', when you need stoping the Timer
            timer.Enabled = true;
        }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            imgAviso.Visibility = imgAviso.IsVisible ? Visibility.Hidden : Visibility.Visible;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ItemCollection elementos = compExamen.ElementosListBox;
            if (elementos != null && !elementos.IsEmpty)
            {
                int max = 0;
                string elementoMayor = "";
                foreach (ListItem elemento in elementos) // Problema con los tipos
                {
                    if (elemento.ToString().Length >= max)
                    {
                        elementoMayor = elemento.ToString();
                        max = elementoMayor.Length;
                    }
                }
                tbElementoMayorTam.Text = elementoMayor;
            }
        }

    }
}
