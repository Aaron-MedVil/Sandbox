﻿using System;
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

                    foreach (var item in users) {

                        tb_id.Text = item._id.ToString();
                        tb_nombre.Text = item._nombre.ToString();
                        tb_usuario.Text = item._usuario.ToString();
                        tb_password.Text = item._password.ToString();
                        tb_hash.Text = item._hash.ToString();
                        tb_fecha_alta.Text = item._fecha_alta.ToString();
                        tb_fecha_baja.Text = item._fecha_baja.ToString();
                    }
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

        private void btnReloadData_Click(object sender, RoutedEventArgs e) { }

        private void btnNewReg_Click(object sender, RoutedEventArgs e) {}

        private void btnRemoveReg_Click(object sender, RoutedEventArgs e) {}
    }
}