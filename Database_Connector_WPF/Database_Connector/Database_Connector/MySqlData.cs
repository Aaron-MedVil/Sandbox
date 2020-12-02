using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using CryptSharp;
using System.Windows.Documents;

namespace Database_Connector {

    class MySqlData {

        private MySqlConnection conn = null;
        private MySqlDataReader reader = null;
        private MySqlDataAdapter adp = null;
        private MySqlCommand cmd = null;
        private string connString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        /// <summary>Comprueba la conexion a la base de datos</summary>
        /// <returns type="Boolean">True si la base de datos esta disponible</returns>
        public bool checkConn() {

            bool isConn = false;

            try {

                conn = new MySqlConnection(connString);
                conn.Open();
                isConn = true;
            }
            catch (ArgumentException a_ex) {}
            catch (MySqlException ex) {}
            finally { if (conn.State == ConnectionState.Open) {conn.Close();} }

            return isConn;
        }

        /// <summary>Obtiene los datos de la tabla usuario</summary>
        /// <param name="args">Argumentos para la sentencia</param>
        public List<Usuario> getUserData(Dictionary<string, string>? args) {

            List<Usuario> usuarios = null;

            try {

                conn.Open();
                cmd = new MySqlCommand();
                cmd.CommandText = "SELECT id, nombre, usuario, password, fecha_alta, fecha_baja, hash FROM usuarios";

                // Implementa las variables si existe alguna
                if (args != null) {

                    cmd.CommandText += " WHERE 1 = @def";

                    foreach (var param in args) {

                        cmd.CommandText += " AND " + param.Key + " = @" + param.Key;
                        cmd.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }

                    cmd.Parameters.AddWithValue("@def", 1);
                }

                cmd.Connection = conn;
                reader = cmd.ExecuteReader();

                // Comprueba si la sentencia retorna datos
                if (reader.HasRows) {

                    usuarios = new List<Usuario>();

                    while (reader.Read()) {

                        int id = (int)reader["id"];
                        String nombre = reader["nombre"].ToString();
                        String usuario = reader["usuario"].ToString();
                        String password = reader["password"].ToString();
                        String fecha_alta = reader["fecha_alta"].ToString();
                        String fecha_baja = reader["fecha_baja"].ToString();
                        String hash = reader["hash"].ToString();

                        Usuario user = new Usuario(id, nombre, usuario, password, fecha_alta, fecha_baja, hash);
                        usuarios.Add(user);
                    }
                }
            }
            catch (MySqlException ex) {}
            finally { conn.Close(); }

            return usuarios;
        }

        /// <summary>Encripta una cadena en blowfish</summary>
        /// <param name="str">Cadena para encriptar</param>
        /// <returns type="String">Cadena encriptada</returns>
        public string cipherCryptBlowfish(String str) => Crypter.Blowfish.Crypt(str);

        /// <summary>Compara una cadena con una cadena encriptada en blowfish</summary>
        /// <param name="str">Cadena para comparar</param>
        /// <param name="cryptStr">Cadena encriptada en blowfish</param>
        /// <returns type="Boolean">True si las cadenas coinciden</returns>
        public Boolean cipherMatchBlowfish(String str, String cryptStr) => Crypter.CheckPassword(str, cryptStr);
    }
}