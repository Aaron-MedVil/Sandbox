using System;
using System.Data;
using System.Data.SqlClient;

namespace merge_list.Modelo {

    class GunsDb {

        private SqlConnection conn = null;
        private SqlDataAdapter adp = null;
        private SqlCommand cmd = null;
        private string aDbFilename = @Environment.CurrentDirectory + "\\data\\DbGuns.mdf";

        /// <summary>Comprueba que hay conexion con la base de datos</summary>
        /// <returns></returns>
        public bool dbConn() {

            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + aDbFilename + ";Integrated Security=True;Connect Timeout=30";
            bool isCorrect = false;

            conn = new SqlConnection(connString);

            try {
                conn.Open();
                isCorrect = true;
            }
            catch (Exception err) { isCorrect = false; }
            finally { if (conn.State == ConnectionState.Open) { conn.Close(); } }

            return isCorrect;
        }

        /// <summary>Comprueba que exista un registro</summary>
        /// <param name="nombre">Nombre del registro</param>
        /// <returns></returns>
        public int existeRegistro(string nombre) {

            conn.Open();

            // Crea la sentencia
            cmd = new SqlCommand("SELECT Count(nombre) As cont FROM Guns WHERE nombre = @nombre", conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);

            // Ejecuta la sentencia
            adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;

            // Guarda los datos en un datatable para poder utilizarlos
            DataTable dt = new DataTable();
            adp.Fill(dt);

            // Cierra la conexion
            if (conn.State == ConnectionState.Open) { conn.Close(); }

            return (int)dt.Rows[0]["cont"];
        }

        /// <summary>Inserta un registro en la base de datos</summary>
        /// <param name="nombre">Nombre del registro</param>
        /// <param name="tipo">Tipo del registro</param>
        /// <param name="precio">Precio del registro</param>
        public void crearRegistro(string nombre, string tipo, int precio) {

            conn.Open();

            #region Otro metodo para crear la sentencia
            /*
            cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Guns (Nombre, Tipo, Precio) VALUES (@nombre, @tipo, @precio)";
            cmd.Connection = conn;
            */
            #endregion

            // Crea la sentencia de insertar en la base de datos
            cmd = new SqlCommand("INSERT INTO Guns (Nombre, Tipo, Precio) VALUES (@nombre, @tipo, @precio)", conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }

        /// <summary>Edita un registro de la base de datos</summary>
        /// <param name="nombre">Nombre del registro</param>
        /// <param name="tipo">Tipo del registro</param>
        /// <param name="precio">Precio del registro</param>
        public void editaRegistro(string nombre, string tipo, int precio) {

            conn.Open();

            // Crea la sentencia de editarun registro en la base de datos
            cmd = new SqlCommand("UPDATE Guns SET Nombre = @nombre, Tipo = @tipo, Precio = @precio WHERE Nombre = @nombre", conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }
    }
}