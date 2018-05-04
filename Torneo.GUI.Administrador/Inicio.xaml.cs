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

namespace Torneo.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        IManejadorUsuarios manejadorUsuarios;
        public Inicio()
        {
            InitializeComponent();
            manejadorUsuarios = new ManejadorUsuarios(new RepositorioGenerico<Usuarios>());
            ActualizarUsuarios();
        }

        private void ActualizarUsuarios()
        {
            cmbUsuario.ItemsSource = null;
            cmbUsuario.ItemsSource = manejadorUsuarios.Lista;
        }

        private void btnIniciarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuario.Text == "")
            {
                MessageBox.Show("No ha colocado el usuario al que corresponde\nSelecciones uno", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(pasword.Password))
            {
                MessageBox.Show("No ha ingresado la contraseña", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbUsuario.SelectedItem != null)
            {
                Usuarios b = cmbUsuario.SelectedItem as Usuarios;
                if (pasword.Password == b.Contraseña)
                {
                    MainWindow a = new MainWindow();
                    a.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña Inconrrecta", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación", "Inicio", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
