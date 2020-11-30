using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Database_Connector {

    public partial class MainWindow : Window {

        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        public MainWindow() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) {

            try {

                /* conn.Open();
                MySqlCommand cdm = new MySqlCommand("SELECT * FROM testtable", conn);
                MySqlDataReader myReader;
                myReader = cdm.ExecuteReader();
                while (myReader.Read()) { MessageBox.Show(myReader.GetString(0)); }
                myReader.Close(); */

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
    }
}