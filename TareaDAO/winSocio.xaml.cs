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
    /// Lógica de interacción para winSocio.xaml
    /// </summary>
    public partial class winSocio : Window
    {
        SocioImpl implSocio;
        Socio socio;
        byte op;
        public winSocio()
        {
            InitializeComponent();
        }

        void select()
        {
            try
            {
                implSocio = new SocioImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implSocio.Select().DefaultView;
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
            txtCi.IsEnabled = true;
            txtNombres.IsEnabled = true;
            txtPriemerApellido.IsEnabled = true;
            txtSegundoApellido.IsEnabled = true;
            dpFechaNacimiento.IsEnabled = true;
            txtMatricula.IsEnabled = true;
            txtLugar.IsEnabled = true;
            txtFuente.IsEnabled = true;
            txtCelular.IsEnabled = true;
            txtCi.Focus();
        }

        void DisableButtons()
        {
            btnRegistrar.IsEnabled = true;
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;

            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            txtCi.IsEnabled = false;
            txtNombres.IsEnabled = false;
            txtPriemerApellido.IsEnabled = false;
            txtSegundoApellido.IsEnabled = false;
            dpFechaNacimiento.IsEnabled = false;
            txtMatricula.IsEnabled = false;
            txtLugar.IsEnabled = false;
            txtFuente.IsEnabled = false;
            txtCelular.IsEnabled = false;
            limpiar();
        }

        void limpiar()
        {
            txtCi.Text = "";
            txtNombres.Text = "";
            txtPriemerApellido.Text = "";
            txtSegundoApellido.Text = "";
            dpFechaNacimiento.Text = "";
            txtMatricula.Text = "";
            txtLugar.Text = "";
            txtFuente.Text = ""; ;
            txtCelular.Text = "";
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
            if (socio != null)
            {
                if (MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implSocio = new SocioImpl();
                        int n = implSocio.Delete(socio);
                        if (n>0)
                        {
                            lblEstado.Content = "Registro Eliminado con Éxito";
                            select();
                            limpiar();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show( ex.Message);
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
                    string hol = dpFechaNacimiento.Text;
                    socio = new Socio(txtCi.Text, txtNombres.Text, txtPriemerApellido.Text,txtSegundoApellido.Text, DateTime.Parse(hol),txtMatricula.Text, txtLugar.Text, txtFuente.Text, int.Parse(txtCelular.Text));
                    implSocio = new SocioImpl();
                    try
                    {
                        int n = implSocio.Insert(socio);
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
                    socio.Ci = txtCi.Text;
                    socio.Nombres = txtNombres.Text;
                    socio.PrimerApellido = txtPriemerApellido.Text;
                    socio.SegundoApellido = txtSegundoApellido.Text;
                        string fech = dpFechaNacimiento.Text;
                    socio.FechaNacimiento = DateTime.Parse(fech);
                    socio.MatriculaProfesional = txtMatricula.Text;
                    socio.LugarTrabajo = txtLugar.Text;
                    socio.FuenteFinanciacion = txtFuente.Text;
                    socio.Celular = int.Parse(txtCelular.Text.ToString());
                    implSocio = new SocioImpl();
                    try
                    {
                        int n = implSocio.Update(socio);
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
                    implSocio = new SocioImpl();
                    socio = implSocio.Get(id);
                    if (socio != null)
                    { 
                        txtCi.Text = socio.Ci;
                        txtNombres.Text = socio.Nombres;
                        txtPriemerApellido.Text = socio.PrimerApellido;
                        txtSegundoApellido.Text = socio.SegundoApellido;
                        dpFechaNacimiento.SelectedDate = socio.FechaNacimiento;
                        txtMatricula.Text = socio.MatriculaProfesional;
                        txtLugar.Text = socio.LugarTrabajo;
                        txtFuente.Text = socio.FuenteFinanciacion; ;
                        txtCelular.Text = socio.Celular.ToString();
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
