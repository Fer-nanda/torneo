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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TorneoDeportes.BIZ;
using TorneoDeportes.COMMON.Entidades;
using TorneoDeportes.COMMON.Interfacez;
using TorneoDeportes.DAL;

namespace Torneo.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            nuevo,
            editar
        }
        accion operacion;
        IManejadorUsuarios manejadorUsuarios;
        IManejadorDeportes manejadorDeporte;
        IManejadorEquipos manejadorEquipos;
        IManejadorTorneo manejadorTorneo;

        List<VistaDeporteEspecifco> vista = new List<VistaDeporteEspecifco>();
        List<VistaDeporteEspecifco> nueva = new List<VistaDeporteEspecifco>();
        List<Naleatorios> lista = new List<Naleatorios>();
        List<Naleatorios> lista2 = new List<Naleatorios>();
        List<Torneos> tor = new List<Torneos>();
        string equipo1;
        string equipo2;
        public MainWindow()
        {
            InitializeComponent();
            manejadorUsuarios = new ManejadorUsuarios(new RepositorioGenerico<Usuarios>());
            manejadorDeporte = new ManejadorDeportes(new RepositorioGenerico<Deportes>());
            manejadorEquipos = new ManejadorEquipos(new RepositorioGenerico<Equipos>());
            manejadorTorneo = new ManejadorTorneo(new RepositorioGenerico<Torneos>());

            CargarTablas();
            LimpiarEditarTablasDeporte(false);
            LimpiarTablasEquipos(false);
            HabilitarBotones(false);
            LimpiarTablasTorneo(false);
        }
        private void LimpiarTablasTorneo(bool a)
        {
            cmbTipoDeporteTorneo.ItemsSource = "";
            clFechaTorneo.Text = "";

            cmbTipoDeporteTorneo.IsEnabled = a;
            clFechaTorneo.IsEnabled = a;
            CargarTablas();
            btnOrdenarTorneo.IsEnabled = a;
            btnCancelarTorneo.IsEnabled = a;
            btnEliminarTorneo.IsEnabled = !a;
            btnNuevoTorneo.IsEnabled = !a;
        }

        private void LimpiarTablasEquipos(bool a)
        {

            txtNombreEquipo.Clear();
            txtTipoDeporteEquipo.IsEnabled = a;
            txtNombreEquipo.IsEnabled = a;

            btnCancelarEquipo.IsEnabled = a;
            btnAgregarEquipo.IsEnabled = a;
            btnEditarEquipo.IsEnabled = !a;
            btnEliminarEquipo.IsEnabled = !a;
            btnNuevoEquipo.IsEnabled = !a;
        }

        private void CargarTablas()
        {
            dtgUsuarios.ItemsSource = null;
            dtgUsuarios.ItemsSource = manejadorUsuarios.Lista;

            dtgDeporte.ItemsSource = null;
            dtgDeporte.ItemsSource = manejadorDeporte.Lista;

            dtgEquipo.ItemsSource = null;
            dtgEquipo.ItemsSource = manejadorEquipos.Lista;

            txtTipoDeporteEquipo.ItemsSource = null;
            txtTipoDeporteEquipo.ItemsSource = manejadorDeporte.Lista;

            dtgPrueba.ItemsSource = null;
            dtgPrueba.ItemsSource = manejadorTorneo.Lista;

            cmbTipoDeporteTorneo.ItemsSource = null;
            cmbTipoDeporteTorneo.ItemsSource = manejadorDeporte.Lista;

            dtgPuntos.ItemsSource = null;
            dtgPuntos.ItemsSource = manejadorTorneo.Lista;

            cmbDeportePuntosEquipos.ItemsSource = null;
            cmbDeportePuntosEquipos.ItemsSource = manejadorDeporte.Lista;

        }

        private void LimpiarEditarTablasDeporte(bool a)
        {
            txtDeportesDeportes.Clear();
            txtDeportesDeportes.IsEnabled = a;

            btnAgregarDeporte.IsEnabled = a;
            btnCancelarDeporte.IsEnabled = a;
            btnEditarDeporte.IsEnabled = !a;
            btnEliminarDeporte.IsEnabled = !a;
            btnNuevoDeporte.IsEnabled = !a;
        }

        private void HabilitarBotones(bool a)
        {
            txtNombreUsuario.IsEnabled = a;
            txtApellidoUsuario.IsEnabled = a;

            txtDomicilioUsuario.IsEnabled = a;
            txtNombreDeUsuario.IsEnabled = a;
            txtContrasenaUsuario.IsEnabled = a;

            btnNuevoUsuario.IsEnabled = !a;
            btnEliminarUusraios.IsEnabled = !a;
            btnAgregar.IsEnabled = a;
            btnCancelarUsuario.IsEnabled = a;
            btnEditarUsuario.IsEnabled = !a;
        }



        private void btnNuevoDeporte_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasDeporte(true);
            operacion = accion.nuevo;
        }

        private void btnAgregarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeportesDeportes.Text))
            {
                MessageBox.Show("Error!!!...No ha ingresado el Deporte", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (operacion == accion.nuevo)
            {
                Deportes a = new Deportes();
                a.tipo_deporte = txtDeportesDeportes.Text;

                if (manejadorDeporte.Agregar(a))
                {
                    MessageBox.Show("Deporte ingresado correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasDeporte(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                Deportes a = dtgDeporte.SelectedItem as Deportes;
                a.tipo_deporte = txtDeportesDeportes.Text;
                if (manejadorDeporte.Modificar(a))
                {
                    MessageBox.Show("Deporte Actualizado correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasDeporte(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar Editar correctamente el Deporte", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDeporte.SelectedItem != null)
            {
                operacion = accion.editar;
                LimpiarEditarTablasDeporte(true);
                Deportes a = dtgDeporte.SelectedItem as Deportes;
                txtDeportesDeportes.Text = a.tipo_deporte;
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDeporte.SelectedItem != null)
            {
                Deportes a = dtgDeporte.SelectedItem as Deportes;
                if (MessageBox.Show("Realmente esta seguro de eliminar a " + a.tipo_deporte, "Deportes", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorDeporte.Eliminar(a.Id);
                    CargarTablas();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente esta seguro de cancelar la operación", "Deporte", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LimpiarEditarTablasDeporte(false);
            }
        }

        private void btnAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoDeporteEquipo.Text) || string.IsNullOrEmpty(txtNombreEquipo.Text))
            {
                MessageBox.Show("No ha llenado la información básica del equipo", "Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (operacion == accion.nuevo)
            {

                Equipos a = new Equipos();

                a.Tipo_Deporte = txtTipoDeporteEquipo.Text;
                a.Nombre = txtNombreEquipo.Text;

                if (manejadorEquipos.Agregar(a))
                {
                    MessageBox.Show("Equipo ingresado correctamente", "Equipo", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarTablasEquipos(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar correctamente el equipo", "Equipo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Equipos a = dtgEquipo.SelectedItem as Equipos;

                a.Nombre = txtNombreEquipo.Text;
                a.Tipo_Deporte = txtTipoDeporteEquipo.Text;
                if (manejadorEquipos.Modificar(a))
                {
                    MessageBox.Show("Equipo Editado Correctamente", "Equipo", MessageBoxButton.OK, MessageBoxImage.Information);

                    CargarTablas();
                    LimpiarTablasEquipos(false);
                }

                else
                {
                    MessageBox.Show("Equipo Editado Inorrectamente", "Equipo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnNuevoEquipo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTablasEquipos(true);
            operacion = accion.nuevo;
        }

        private void btnEditarEquipo_Click(object sender, RoutedEventArgs e)
        {
            Equipos a = dtgEquipo.SelectedItem as Equipos;
            if (a != null)
            {
                LimpiarTablasEquipos(true);

                txtTipoDeporteEquipo.Text = a.Tipo_Deporte;
                txtNombreEquipo.Text = a.Nombre;
                operacion = accion.editar;
            }
            else
            {
                MessageBox.Show("No ha seleccionado la tabla de Equipo\nSeleccione un elemento para editarlo", "Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (dtgEquipo.SelectedItem != null)
            {
                Equipos a = dtgEquipo.SelectedItem as Equipos;
                if (MessageBox.Show("Realmente esta seguro de eliminar a " + a.Nombre, "Equipos", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEquipos.Eliminar(a.Id))
                    {
                        MessageBox.Show("Equipo eliminado sadisfactoriamente", "Equipos", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarTablas();
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente esta seguro de cancelar la operación", "Equipo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LimpiarTablasEquipos(false);

            }
        }



        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposTablasUsuario();
            HabilitarBotones(true);
            operacion = accion.nuevo;
        }

        private void LimpiarCamposTablasUsuario()
        {


            txtNombreUsuario.Clear();
            txtDomicilioUsuario.Clear();
            txtContrasenaUsuario.Clear();
            txtApellidoUsuario.Clear();


            txtNombreDeUsuario.Clear();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtApellidoUsuario.Text))
            {
                MessageBox.Show("No ha ingresado los datos del nombre completo de Usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtDomicilioUsuario.Text))
            {
                MessageBox.Show("No ha ingresado todos los datos personales del Usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtNombreDeUsuario.Text) || string.IsNullOrEmpty(txtContrasenaUsuario.Password))
            {
                MessageBox.Show("No ha ingresado todos los datos del Usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            int contrasena = txtContrasenaUsuario.Password.Count();
            if (contrasena <= 8)
            {
                MessageBox.Show("La contraseña debe de ser mayor o igual a 8 caracteres para mayor seguridad", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (operacion == accion.nuevo)
            {
                Usuarios a = new Usuarios()
                {
                    Nombre = txtNombreUsuario.Text,
                    Apellido = txtApellidoUsuario.Text,

                    Domicilio = txtDomicilioUsuario.Text,
                    Nom_Usuario = txtNombreDeUsuario.Text,
                    Contraseña = txtContrasenaUsuario.Password,


                };
                manejadorUsuarios.Agregar(a);
                CargarTablas();
                LimpiarCamposTablasUsuario();
                HabilitarBotones(false);
            }
            else
            {
                Usuarios usuario = dtgUsuarios.SelectedItem as Usuarios;
                usuario.Nombre = txtNombreUsuario.Text;
                usuario.Apellido = txtApellidoUsuario.Text;

                usuario.Domicilio = txtDomicilioUsuario.Text;

                usuario.Nom_Usuario = txtNombreDeUsuario.Text;
                usuario.Contraseña = txtContrasenaUsuario.Password;


                if (manejadorUsuarios.Modificar(usuario))
                {
                    CargarTablas();
                    LimpiarCamposTablasUsuario();
                    HabilitarBotones(false);
                    MessageBox.Show("Usuario editado correctamente", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se puedo editar correctamente el usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsuarios.SelectedItem != null)
            {
                Usuarios a = dtgUsuarios.SelectedItem as Usuarios;
                txtNombreUsuario.Text = a.Nombre;
                txtApellidoUsuario.Text = a.Apellido;

                txtDomicilioUsuario.Text = a.Domicilio;
                txtNombreDeUsuario.Text = a.Nom_Usuario;
                txtContrasenaUsuario.Password = a.Contraseña;


                operacion = accion.editar;
                HabilitarBotones(true);

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminarUusraios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios a = dtgUsuarios.SelectedItem as Usuarios;
            if (a != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar el usuario: " + a.Nombre, "Eliminación Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorUsuarios.Eliminar(a.Id);
                    CargarTablas();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Usuarios", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotones(false);
                LimpiarCamposTablasUsuario();
            }
        }

        private void btnNuevoTorneo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarTablasTorneo(true);
            tor = new List<Torneos>();

        }

        public void PrimerEquipoTorneo()
        {
            int contador = 0;
            Naleatorios a = new Naleatorios();
            foreach (var item in lista)
            {
                contador++;
                if (contador == 1)
                {
                    equipo1 = item.dato;
                    a.dato = item.dato;
                    lista.Remove(item);
                    lista2.Add(a);
                    break;
                }
            }

        }

        private void SegundoEquipotorneoImpar()
        {
            if (lista.Count >= 1)
            {
                Random r = new Random();
                int val = r.Next(1, lista.Count);
                int contador = 0;

                foreach (var item2 in lista)
                {
                    contador++;

                    if (contador == val)
                    {
                        equipo2 = item2.dato;
                        lista.Remove(item2);
                        break;
                    }
                }
            }
        }

        private void AgregarListaNumerosImpares(string palabra)
        {
            PrimerEquipoTorneo();
            SegundoEquipotorneoImpar();
            Torneos a = new Torneos()
            {
                Equipo1 = equipo1,
                Equipo2 = equipo2,
                Marcador1 = 0,
                Marcador2 = 0,
                Deporte = palabra,
                F_Programado = clFechaTorneo.Text,
            };
            tor.Add(a);
            manejadorTorneo.Agregar(a);
            dtgPrueba.ItemsSource = null;
            dtgPrueba.ItemsSource = manejadorTorneo.Lista;
        }


        private void btnOrdenarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoDeporteTorneo.SelectedItem == null)
            {
                MessageBox.Show("Error...No ha seleccionado ningun deporte!!!", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string palabra = cmbTipoDeporteTorneo.Text;
            if (manejadorEquipos.ContadorDeBuscarEquipo(palabra) <= 1)
            {
                MessageBox.Show("No se puede realizar los torneos con un solo equipo\nAgregue más equipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(clFechaTorneo.Text))
            {
                MessageBox.Show("Agregue la fecha programada del torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorEquipos.Lista)
            {
                if (item.Tipo_Deporte == palabra)
                {
                    Naleatorios equipos = new Naleatorios();
                    equipos.dato = item.Nombre;
                    lista.Add(equipos);
                }
            }


            if (lista.Count % 2 == 0)
            {
                while (((lista.Count) / 2) > 0)
                {
                    AgregarListaNumerosImpares(palabra);
                }
            }
            else
            {
                while (((lista.Count) / 2) > 0)
                {
                    AgregarListaNumerosImpares(palabra);
                }
                UltimoElemntoRestante(palabra);
            }


            LimpiarTorneo(false);

        }

        private void LimpiarTorneo(bool a)
        {
            cmbTipoDeporteTorneo.ItemsSource = "";
            clFechaTorneo.Text = "";
            cmbTipoDeporteTorneo.IsEnabled = a;
            clFechaTorneo.IsEnabled = a;
            btnOrdenarTorneo.IsEnabled = a;
            btnCancelarTorneo.IsEnabled = a;
            btnEliminarTorneo.IsEnabled = !a;
            btnNuevoTorneo.IsEnabled = !a;
            btnOrdenarTorneo.IsEnabled = a;

            btnCancelarTorneo.IsEnabled = a;
            btnEliminarTorneo.IsEnabled = !a;
            btnNuevoTorneo.IsEnabled = !a;
        }

        private void UltimoElemntoRestante(string palabra)
        {
            PrimerEquipoTorneo();
            if (lista.Count >= 1)
            {
                Random r = new Random();
                int val = r.Next(2, lista2.Count);
                int contador = 0;

                foreach (var item2 in lista2)
                {
                    contador++;

                    if (contador == val)
                    {
                        equipo2 = item2.dato;
                        break;
                    }
                }
            }
            Torneos a = new Torneos()
            {
                Equipo1 = equipo1,
                Equipo2 = equipo2,
                Deporte = palabra.ToUpper(),
                Marcador1 = 0,
                Marcador2 = 0,
                F_Programado = clFechaTorneo.Text,
            };
            tor.Add(a);
            manejadorTorneo.Agregar(a);
            dtgPrueba.ItemsSource = null;
            dtgPrueba.ItemsSource = manejadorTorneo.Lista;

        }

        private void btnEliminarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPrueba.SelectedItem != null)
            {
                Torneos a = dtgPrueba.SelectedItem as Torneos;
                if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + a.Equipo1 + " & " + a.Equipo2, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorTorneo.Eliminar(a.Id))
                    {
                        MessageBox.Show("Equipos eliminados", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla para eliminar\nSeleccione uno", "Torneo Eliminación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación?", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                CargarTablas();
                LimpiarTorneo(false);
            }
        }

        private void btnPuntosBuscador_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDeportePuntosEquipos.Text))
            {
                MessageBox.Show("Seleccione un Deporte", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(clcFechaPuntosEquipos.Text))
            {
                MessageBox.Show("Seleccione la fecha de programación del torneo", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<DeporteTemporal> tipo = new List<DeporteTemporal>();
            if (cmbDeportePuntosEquipos.SelectedItem != null)
            {
                foreach (var item in manejadorTorneo.Lista)
                {
                    if (item.Deporte == cmbDeportePuntosEquipos.Text && item.F_Programado == clcFechaPuntosEquipos.Text)
                    {
                        DeporteTemporal TipoDeporteTemporal = new DeporteTemporal()
                        {
                            Equipo1 = item.Equipo1,
                            Equipo2 = item.Equipo2,
                            Deporte = item.Deporte,
                            F_aProgramado = item.F_Programado,
                            Id = item.Id.ToString(),
                            Marcador_1 = item.Marcador1,
                            Marcador_2 = item.Marcador2,
                        };
                        tipo.Add(TipoDeporteTemporal);
                    }
                }
                dtgPuntos.ItemsSource = null;
                dtgPuntos.ItemsSource = tipo;
            }
            else
            {
                MessageBox.Show("Algo salio mal :(\nIntentalo de nuevo", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPuntosRegresar_Click(object sender, RoutedEventArgs e)
        {
            dtgPuntos.ItemsSource = null;
            dtgPuntos.ItemsSource = manejadorTorneo.Lista;
        }

        private void btnEditarPuntos_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPuntosId.Text))
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla para actualizar", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (manejadorTorneo.VerificarSiEsNumero(txtPuntosMarcador1.Text) == 1)
            {
                MessageBox.Show("No se aceptan letras, solo numeros en Marcador 1 ", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (manejadorTorneo.VerificarSiEsNumero(txtPuntosMarcador2.Text) == 1)
            {
                MessageBox.Show("No se aceptan letras, solo numeros en Marcador 2", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int eq1 = 0;
            int eq2 = 0;
            if (int.Parse(txtPuntosMarcador1.Text) > int.Parse(txtPuntosMarcador2.Text))
            {
                eq1 = 3;
                eq2 = 1;
            }
            if (int.Parse(txtPuntosMarcador1.Text) < int.Parse(txtPuntosMarcador2.Text))
            {
                eq1 = 1;
                eq2 = 3;
            }
            if (int.Parse(txtPuntosMarcador1.Text) == int.Parse(txtPuntosMarcador2.Text))
            {
                eq1 = 2;
                eq2 = 2;
            }

            foreach (var item in manejadorTorneo.Lista)
            {
                if (item.Id.ToString() == txtPuntosId.Text.ToString())
                {
                    item.Equipo1 = txtPuntosEquipo1.Text;
                    item.Equipo2 = txtPuntosEquipo2.Text;
                    item.Marcador1 = eq1;
                    item.Marcador2 = eq2;
                    if (manejadorTorneo.Modificar(item))
                    {
                        CargarTablas();
                        LimpiarPuntosTorneo();
                        MessageBox.Show("Torneo editado correctamente", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se puedo editar correctamente el Torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void LimpiarPuntosTorneo()
        {
            txtPuntosEquipo1.Clear();
            txtPuntosEquipo2.Clear();
            txtPuntosMarcador1.Clear();
            txtPuntosMarcador2.Clear();
            txtPuntosId.Clear();
        }

        private void btnEliminarPuntosEquipos_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPuntos.SelectedItem != null)
            {
                Torneos a = dtgPuntos.SelectedItem as Torneos;
                if (a != null)
                {
                    if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + a.Equipo1 + " & " + a.Equipo2, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (manejadorTorneo.Eliminar(a.Id))
                        {
                            MessageBox.Show("Equipos eliminados", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                            CargarTablas();
                            LimpiarPuntosTorneo();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    DeporteTemporal b = dtgPuntos.SelectedItem as DeporteTemporal;
                    foreach (var item in manejadorTorneo.Lista)
                    {
                        if (b.Id.ToString() == item.Id.ToString())
                        {
                            if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + item.Equipo1 + " & " + item.Equipo2, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (manejadorTorneo.Eliminar(item.Id))
                                {
                                    MessageBox.Show("Equipos eliminados", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                                    CargarTablas();
                                    LimpiarPuntosTorneo();
                                }
                                else
                                {
                                    MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarPuntos_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación?", "Puntos Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                CargarTablas();
                LimpiarPuntosTorneo();
            }
        }

        private void dtgPuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgPuntos.SelectedItem != null)
            {
                Torneos a = dtgPuntos.SelectedItem as Torneos;
                if (a != null)
                {
                    txtPuntosId.Text = a.Id.ToString();
                    txtPuntosEquipo1.Text = a.Equipo1;
                    txtPuntosEquipo2.Text = a.Equipo2;
                    txtPuntosMarcador1.Text = a.Marcador1.ToString();
                    txtPuntosMarcador2.Text = a.Marcador2.ToString();
                }
                else
                {
                    DeporteTemporal b = dtgPuntos.SelectedItem as DeporteTemporal;
                    foreach (var item in manejadorTorneo.Lista)
                    {
                        if (b.Id == item.Id.ToString())
                        {
                            txtPuntosId.Text = item.Id.ToString();
                            txtPuntosEquipo1.Text = item.Equipo1;
                            txtPuntosEquipo2.Text = item.Equipo2;
                            txtPuntosMarcador1.Text = item.Marcador1.ToString();
                            txtPuntosMarcador2.Text = item.Marcador2.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
