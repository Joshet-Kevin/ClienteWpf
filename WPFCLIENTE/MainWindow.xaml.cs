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

namespace WPFCLIENTE
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ServiceReference1.WebService4Soap servicio = new ServiceReference1.WebService4SoapClient();

        private void Listar()
        {
            dgContenido.DataContext = servicio.ListarRegion().Tables[0];
        }
        
        public MainWindow()
        {
            InitializeComponent();
            //Listar();

        }

        private static string Seleccionado = "";
        private static string combo;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRegion_Click(object sender, RoutedEventArgs e)
        {
            Ocultar();
            Mostar();
            Seleccionado = "Region";
        }

        private void btnShippers_Click(object sender, RoutedEventArgs e)
        {
            Ocultar();
            Mostar();
            txtTercero.Visibility = Visibility.Visible;
            Seleccionado = "Shippers";
        }

        private void btnCustomerDemo_Click(object sender, RoutedEventArgs e)
        {
            Ocultar();
            Mostar();
            Seleccionado = "CustomerDemo";
        }




        private void Ocultar()
        {
            txtPrimero.Visibility = Visibility.Hidden;
            txtSegundo.Visibility = Visibility.Hidden;
            txtTercero.Visibility = Visibility.Hidden;
        }


        private void Mostar()
        {
            txtPrimero.Visibility = Visibility.Visible;
            txtSegundo.Visibility = Visibility.Visible;
        }
        private void change_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //combo = cbShippers.SelectionBoxItem.ToString();
            //titulo.Text = "";
            //titulo.Text = combo;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            if (Seleccionado == "Region")
            {
                int primero = int.Parse(txtBuscar.Text.Trim());
                dgContenido.DataContext = servicio.BuscarRegion(primero).Tables[0];
            }

            else if (Seleccionado == "Shippers")
            {
                string primero = txtBuscar.Text.Trim();
                dgContenido.DataContext = servicio.BuscarShippers(primero, cbShippers.SelectionBoxItem.ToString()).Tables[0];
                
            }

            else if (Seleccionado == "CustomerDemo")
            {
                string primero = txtBuscar.Text.Trim();
                dgContenido.DataContext = servicio.BuscarCustomerDemographics(primero).Tables[0];
            }

        }
        

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if(Seleccionado == "Region")
            {
                int primero = int.Parse(txtPrimero.Text.Trim());
                string segundo = txtSegundo.Text.Trim();
                string[] rsta = servicio.AgregarRegion(primero, segundo).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarRegion().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }
            // No se puede agregar
            else if (Seleccionado == "Shippers")
            {
                int primero = int.Parse(txtPrimero.Text.Trim());
                string segundo = txtSegundo.Text.Trim();
                string tercero = txtTercero.Text.Trim();
                string[] rsta = servicio.AgregarShippers(primero,segundo,tercero).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarShippers().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }
            //-------------
            else if (Seleccionado == "CustomerDemo")
            {
                string primero = txtPrimero.Text.Trim();
                string segundo = txtSegundo.Text.Trim();
                string[] rsta = servicio.AgregarCustomerDemographics(primero, segundo).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarCustomerDemographics().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }



        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (Seleccionado == "Region")
            {
                int primero = int.Parse(txtPrimero.Text.Trim());
                string segundo = txtSegundo.Text.Trim();
                string[] rsta = servicio.ActualizarRegion(primero, segundo).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarRegion().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }
            
            else if (Seleccionado == "Shippers")
            {
                int primero = int.Parse(txtPrimero.Text.Trim());
                string segundo = txtSegundo.Text.Trim();
                string tercero = txtTercero.Text.Trim();
                string[] rsta = servicio.ActualizarShippers(primero, segundo, tercero).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarShippers().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }
            
            else if (Seleccionado == "CustomerDemo")
            {
                string primero = txtPrimero.Text.Trim();
                string segundo = txtSegundo.Text.Trim();
                string[] rsta = servicio.ActualizarCustomerDemographics(primero, segundo).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarCustomerDemographics().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }



        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            if (Seleccionado == "Region")
            {
                int primero = int.Parse(txtPrimero.Text.Trim());
               
                string[] rsta = servicio.EliminarRegion(primero).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarRegion().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }

            else if (Seleccionado == "Shippers")
            {
                int primero = int.Parse(txtPrimero.Text.Trim());
                
                string[] rsta = servicio.EliminarShippers(primero).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarShippers().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }

            else if (Seleccionado == "CustomerDemo")
            {
                string primero = txtPrimero.Text.Trim();
                
                string[] rsta = servicio.EliminarCustomerDemographics(primero).ToArray();
                if (rsta[0] == "0")
                {
                    dgContenido.DataContext = servicio.ListarCustomerDemographics().Tables[0];
                }
                MessageBox.Show(rsta[1]);
            }

        }

        private void btnListarRegion_Click(object sender, RoutedEventArgs e)
        {
            dgContenido.DataContext = servicio.ListarRegion().Tables[0];
        }

        private void btnListarShippers_Click(object sender, RoutedEventArgs e)
        {
            dgContenido.DataContext = servicio.ListarShippers().Tables[0];
        }

        private void btnListarCustomerDemo_Click(object sender, RoutedEventArgs e)
        {
            dgContenido.DataContext = servicio.ListarCustomerDemographics().Tables[0];
        }

        
    }
}
