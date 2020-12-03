using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Database_Connector {

    public partial class MainWindow : Window {

        private MySqlData msqd = null;
        private Dictionary<string, string> par = null;

        /// <summary>Funcion que carga los componentes</summary>
        public MainWindow() => InitializeComponent();

        /// <summary>Carga los datos iniciales de la aplicacion</summary>
        /// <param name="sender">Objeto que ejecuta la accion</param>
        /// <param name="e">Argumentos de la accion</param>
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            // Cargar datos de la base de datos
            msqd = new MySqlData();
            if (msqd.checkConn() == true) {

                par = new Dictionary<string, string>();
                par.Add("id", "1");

                List<Usuario> users = msqd.getUserData(par);

                if (users != null) {

                    var u = users[0];

                    tb_id.Text = u._id.ToString();
                    tb_nombre.Text = u._nombre;
                    tb_usuario.Text = u._usuario;
                    tb_password.Password = u._password;
                    tb_hash.Password = u._hash;
                    tb_fecha_alta.Text = u._fecha_alta;
                    tb_fecha_baja.Text = u._fecha_baja;
                }
                else { MessageBox.Show("Sin registros"); }
            }
            else { MessageBox.Show("Error de conexion"); }
        }

        /// <summary>Eventos para desplazarse por los registros</summary>
        /// <param name="sender">Objeto que ejecuta la accion</param>
        /// <param name="e">Argumentos de la accion</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e) {

            MenuItem mi = (MenuItem)sender;
            string opt = mi.Tag.ToString();
        }

        private void btnNewReg_Click(object sender, RoutedEventArgs e) {}

        private void btnRemoveReg_Click(object sender, RoutedEventArgs e) {}

        private void btnEditReg_Click(object sender, RoutedEventArgs e) {

        }
    }
}