using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Database_Connector {

    public partial class MainWindow : Window {

        private MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        private MySqlDataReader myReader = null;

        /// <summary>Funcion que carga los componentes</summary>
        public MainWindow() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            /*try {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM testtable", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                dgPruebas.DataContext = ds;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }*/
        }

        private void btnReloadData_Click(object sender, RoutedEventArgs e) {

        }
    }
}