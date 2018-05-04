using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TorneoDeportes.BIZ;
using TorneoDeportes.COMMON.Entidades;
using TorneoDeportes.COMMON.Interfacez;
using TorneoDeportes.DAL;

namespace Usuario.GUI
{
    /// <summary>
    /// Lógica de interacción para Estadisticos.xaml
    /// </summary>
    public partial class Estadisticos : Window
    {
        Generadora generadora;
        Random ran = new Random();
       

        
        IManejadorDeportes manejadorDeporte;
        IManejadorEquipos manejadorEquipo;
        IManejadorTorneo manejadorTorneo;
        public Estadisticos()
        {
            InitializeComponent();
           
            manejadorDeporte = new ManejadorDeportes(new RepositorioGenerico<Deportes>());
            manejadorEquipo = new ManejadorEquipos(new RepositorioGenerico<Equipos>());
            manejadorTorneo = new ManejadorTorneo(new RepositorioGenerico<Torneos>());
            CargarTablas();
            btnCalcularEstadisticos.Click += btnCalcularEstadisticos_Click;
            generadora = new Generadora();
        }

        private void CargarTablas()
        {
            

            cmbEstadisticosEquipos.ItemsSource = null;
            cmbEstadisticosEquipos.ItemsSource = manejadorDeporte.Lista;
        }

        


        private void GenerarEstadisticos(int valor, string Deporte, string Fecha)
        {
            int contador = 1, contador1 = 1;
            List<NombreDeportes> nombre = new List<NombreDeportes>();
            foreach (var item in manejadorEquipo.Lista)
            {
                if (item.Tipo_Deporte == cmbEstadisticosEquipos.Text)
                {
                    NombreDeportes a = new NombreDeportes();
                    a.Numerador = contador1++;
                    a.Nombre = item.Nombre;
                    nombre.Add(a);
                }
            }

            List<TorneoLista> listatorneo = new List<TorneoLista>();

            foreach (var item in nombre)
            {
                int valores1 = 0;
                foreach (var item2 in manejadorTorneo.Lista)
                {
                    if (item2.F_Programado == clcFechaEstadisticos.Text)
                    {
                        if (item.Nombre == item2.Equipo1)
                        {
                            valores1 = valores1 + item2.Marcador1;
                        }
                        if (item.Nombre == item2.Equipo2)
                        {
                            valores1 = valores1 + item2.Marcador2;
                        }
                    }
                }
                TorneoLista a = new TorneoLista();
                a.X = contador++;
                a.Equipo = item.Nombre;
                a.Puntaje = valores1;
                listatorneo.Add(a);
            }


            int valores = 0;
            valores = listatorneo.Count;
            generadora.GeneradorDatos(listatorneo, 1, valores, 1);
            dtgTablaEstadisticos.ItemsSource = null;
            dtgTablaEstadisticos.ItemsSource = listatorneo;
            PlotModel model = new PlotModel();
            LinearAxis ejeX = new LinearAxis();
            ejeX.Minimum = 1;
            ejeX.Maximum = valores;
            ejeX.Position = AxisPosition.Bottom;

            LinearAxis ejeY = new LinearAxis();
            ejeY.Minimum = generadora.Puntos.Min(p => p.Y);
            ejeY.Maximum = generadora.Puntos.Max(p => p.Y);
            ejeY.Position = AxisPosition.Left;

            model.Axes.Add(ejeX);
            model.Axes.Add(ejeY);
            model.Title = "Datos generados";
            LineSeries linea = new LineSeries();
            foreach (var item in generadora.Puntos)
            {
                linea.Points.Add(new DataPoint(item.X, item.Y));
            }
            linea.Title = "Valores generados";
            linea.Color = OxyColor.FromRgb(byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()));
            model.Series.Add(linea);
            Grafica.Model = model;
        }

        private void btnCalcularEstadisticos_Click(object sender, RoutedEventArgs e)
        {
            int valor = 0;
            if (string.IsNullOrEmpty(clcFechaEstadisticos.Text) || string.IsNullOrEmpty(cmbEstadisticosEquipos.Text))
            {
                MessageBox.Show("Favor de llenar datos\n*Fecha\n*Tipo de Deporte", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorTorneo.Lista)
            {
                if (item.Deporte == cmbEstadisticosEquipos.Text && item.F_Programado == clcFechaEstadisticos.Text)
                {
                    valor++;
                }
            }
            if (valor <= 0)
            {
                MessageBox.Show("No se encontro ningun Torneo con esa fecha o Deporte", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GenerarEstadisticos(valor, cmbEstadisticosEquipos.Text, clcFechaEstadisticos.Text);
        }

        
    }
}
