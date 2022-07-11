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
using DAO.Model;//
using System.Data;//
using DAO.Implementation;//

namespace TareaDAO
{
    /// <summary>
    /// Lógica de interacción para winActividad.xaml
    /// </summary>
    public partial class winActividad : Window
    {
        ActividadImpl implActividad;
        Actividad actividad;
        byte op;
        public winActividad()
        {
            InitializeComponent();
        }

        void select()
        {
            try
            {
                implActividad = new ActividadImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implActividad.Select().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed; // para ocultar la primera columna

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void EnableButtons()
        {
            btnRegistrar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            txtNombreAc.IsEnabled = true;
            txtDescripcionAc.IsEnabled = true;
            dpFechaAc.IsEnabled = true;
            txtCostoAc.IsEnabled = true;
            txtNombreAc.Focus();
        }

        void DisableButtons()
        {
            btnRegistrar.IsEnabled = true;
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;

            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            txtNombreAc.IsEnabled = false;
            txtDescripcionAc.IsEnabled = false;
            dpFechaAc.IsEnabled = false;
            txtCostoAc.IsEnabled = false;
            limpiar();
        }

        void limpiar()
        {
            txtNombreAc.Text = "";
            txtDescripcionAc.Text = "";
            dpFechaAc.Text = "";
            txtCostoAc.Text = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = "Usuario: " + Session.SessionName;
            select();
            DisableButtons();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            winMenu winm = new winMenu();
            winm.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            limpiar();
            this.op = 1;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.op = 2;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (actividad != null)
            {
                if (MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implActividad = new ActividadImpl();
                        int n = implActividad.Delete(actividad);
                        if (n > 0)
                        {
                            lblEstado.Content = "Registro Eliminado con Éxito";
                            select();
                            limpiar();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    limpiar();
                }
            }
            else
            {
                lblEstado.Content = "Debe seleccionar un registro para eliminar";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            switch (op)
            {
                case 1:
                    //INSERT
                    string hol = dpFechaAc.Text;
                    actividad = new Actividad(txtNombreAc.Text, txtDescripcionAc.Text,DateTime.Parse(hol),float.Parse(txtCostoAc.Text));
                    implActividad = new ActividadImpl();
                    try
                    {
                        int n = implActividad.Insert(actividad);
                        if (n > 0)
                        {
                            lblEstado.Content = "Registro Insertado con Exito";
                            select();
                            DisableButtons();
                        }
                    }
                    catch (Exception)
                    {

                        lblEstado.Content = "Registro Insertado con Exito";
                    }
                    break;
                case 2:
                    //Modificar
                    actividad.NombreActividad = txtNombreAc.Text;
                    actividad.Descripcion = txtDescripcionAc.Text;
                    string fech = dpFechaAc.Text;
                    actividad.FechaActividad = DateTime.Parse(fech);
                    actividad.CostoActividad = float.Parse(txtCostoAc.Text);
                    implActividad = new ActividadImpl();
                    try
                    {
                        int n = implActividad.Update(actividad);
                        if (n > 0)
                        {
                            lblEstado.Content = "Registro Modificado con Exito";
                            select();
                            DisableButtons();
                        }
                    }
                    catch (Exception)
                    {
                        lblEstado.Content = "Transacción no completada \nComuniquese con el Adm. del Sistema";
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.SelectedItem != null && dgvDatos.Items.Count > 0)
            {

                try
                {
                    DataRowView d = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(d.Row.ItemArray[0].ToString());
                    implActividad = new ActividadImpl();
                    actividad = implActividad.Get(id);
                    if (actividad != null)
                    {
                        txtNombreAc.Text = actividad.NombreActividad;
                        txtDescripcionAc.Text = actividad.Descripcion;
                        dpFechaAc.SelectedDate = actividad.FechaActividad;
                        txtCostoAc.Text = actividad.CostoActividad.ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
