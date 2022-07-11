using DAO.Model;
using System.Windows;
using System.Windows.Input;

namespace TareaDAO
{
    /// <summary>
    /// Lógica de interacción para winMenu.xaml
    /// </summary>
    public partial class winMenu : Window
    {
        public winMenu()
        {
            InitializeComponent();
        }

        private void btnSalirLog_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            btnAbrirMenu.Visibility = Visibility.Collapsed;
            btnCerrarMenu.Visibility = Visibility.Visible;
            img1.Visibility = Visibility.Visible;
        }

        private void btnCerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            btnAbrirMenu.Visibility = Visibility.Visible;
            btnCerrarMenu.Visibility = Visibility.Collapsed;
            img1.Visibility = Visibility.Collapsed;
        }

        private void btnSalirL_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            winActividad wina = new winActividad();
            wina.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void ListViewItem_PreviewMouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            winSocio wins = new winSocio();
            wins.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = "Usuario: " + Session.SessionName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            winLoguin winl = new winLoguin();
            winl.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
