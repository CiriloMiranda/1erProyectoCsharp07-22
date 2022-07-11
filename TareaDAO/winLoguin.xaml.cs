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
using DAO.Model;
using DAO.Implementation;
using System.Data;

namespace TareaDAO
{
    /// <summary>
    /// Lógica de interacción para winLoguin.xaml
    /// </summary>
    public partial class winLoguin : Window
    {
        public winLoguin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                UsuarioImpl implUsuario = new UsuarioImpl();
                dt = implUsuario.Login(txtUsuario.Text, txtContrasenia.Password);
                if (dt.Rows.Count>0)
                {
                    //ingreso correcto
                    //Ingreso a sesion
                    Session.SessionID = int.Parse(dt.Rows[0][0].ToString());
                    Session.SessionName = dt.Rows[0][1].ToString();
                    Session.SessionUserName = dt.Rows[0][2].ToString();

                    winMenu winm = new winMenu();
                    winm.Show();
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblEstado.Content = "Usuario y/o Contraseña Incorrectos";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
