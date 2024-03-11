using System;
using System.CodeDom;
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

namespace recuperacion_comp.componentes
{
    /// <summary>
    /// Lógica de interacción para marcador.xaml
    /// </summary>
    public partial class marcador : UserControl
    {
        private String PRIMER_TIEMPO = "Primer Tiempo";
        private String SEGUNDO_TIEMPO = "Segundo Tiempo";

        [Description("Nombre equipo 1"), Category("Mi categoria"), DisplayName("Nombre equipo 1")]
        public String TeamName1 { get => LabelTeamName1.Content.ToString(); set => LabelTeamName1.Content = value; }

        [Description("Nombre equipo 2"), Category("Mi categoria"), DisplayName("Nombre equipo 2")]
        public String TeamName2 { get => LabelTeamName2.Content.ToString(); set => LabelTeamName2.Content = value; }

        [Description("Goles equipo 1"), Category("Mi categoria"), DisplayName("Goles equipo 1")]
        public int GolesEquipo1
        {
            get => int.Parse(LabelGolesTeam1.Content.ToString());
            set => LabelGolesTeam1.Content = value;
        }

        [Description("Goles equipo 2"), Category("Mi categoria"), DisplayName("Goles equipo 2")]
        public int GolesEquipo2
        {
            get => int.Parse(LabelGolesTeam2.Content.ToString());
            set => LabelGolesTeam2.Content = value;
        }

        [Description("Minutos actuales"), Category("Mi categoria"), DisplayName("Minutos actuales")]
        public int MinutosActuales
        {
            get => int.Parse(LabelMinutosTranscurridos.Content.ToString());
            set
            {
                LabelMinutosTranscurridos.Content = value;
                ActualizarTiempoPartido(value);
            }
        }

        [Description("Segundos actuales"), Category("Mi categoria"), DisplayName("Segundos actuales")]
        public int SegundosActuales
        {
            get => int.Parse(LabelSegundosTranscurridos.Content.ToString());
            set
            {
                if (value >= 0 && value <= 60)
                {
                    LabelSegundosTranscurridos.Content = value;
                }
                else if (value > 60)
                {
                    LabelSegundosTranscurridos.Content = 59;
                }
                else {
                    LabelSegundosTranscurridos.Content = 0;
                }
                
            } 
        }

        [Description("Minutos añadidos"), Category("Mi categoria"), DisplayName("Minutos añadidos")]
        public int AddedMinunes
        {
            get => int.Parse(LabelAddedMin.Content.ToString());
            set => LabelAddedMin.Content.ToString();
        }

        [Description("Segundos añadidos"), Category("Mi categoria"), DisplayName("Segundos añadidos")]
        public int AddedSeconds
        {
            get => int.Parse(LabelAddedSeconds.Content.ToString());
            set => LabelAddedSeconds.Content.ToString();
        }

        public marcador()
        {
            InitializeComponent();
            ActualizarTiempoPartido(int.Parse(LabelMinutosTranscurridos.Content.ToString()));
        }

        private void ActualizarTiempoPartido(int minutos)
        {
            LabelParte.Content = minutos < 45 ? PRIMER_TIEMPO : SEGUNDO_TIEMPO;
        }
    }
}
