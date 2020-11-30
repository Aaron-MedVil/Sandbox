using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Database_Connector {

    public partial class MainWindow : Window {

        private MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        private MySqlConnection conn2 = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString2"].ConnectionString);

        private MySqlDataReader myReader = null;

        private List<Test> testList = new List<Test>();

        public MainWindow() => InitializeComponent();

        /// <summary>Carga los datos de la base de datos en el DataGrid</summary>
        /// <param name="sender">Objeto que realiza la accion</param>
        /// <param name="e">Argumentos de la accion</param>
        private void Button_Click(object sender, RoutedEventArgs e) {

            try {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM testtable", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                dgPruebas.DataContext = ds;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
        }

        /// <summary>Carga los datos de la base de datos en una lista</summary>
        /// <param name="sender">Objeto que realiza la accion</param>
        /// <param name="e">Argumentos de la accion</param>
        private void Button_Click_1(object sender, RoutedEventArgs e) {

            try {

                conn2.Open();
                MySqlCommand cdm2 = new MySqlCommand("SELECT Host, Db, User FROM db", conn2);
                myReader = cdm2.ExecuteReader();

                while (myReader.Read()) {

                    Test t = new Test();
                    t.Host = myReader["Host"].ToString();
                    t.Db = myReader["Db"].ToString();
                    t.User = myReader["User"].ToString();

                    testList.Add(t);
                }

                myReader.Close();

                foreach (var item in testList) {
                    MessageBox.Show("User: " + item.User.ToString() + "\nHost: " + item.Host.ToString() + " \nDb: " + item.Db.ToString());
                }
            }
            catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
            finally { conn2.Close(); }
        }
    }
}