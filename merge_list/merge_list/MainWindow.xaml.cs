using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace merge_list {

    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window {

        private string _path_JSON1 = Environment.CurrentDirectory + "/data/JSON_1.json";
        private string _path_JSON2 = Environment.CurrentDirectory + "/data/JSON_2.json";

        private List<Guns> _LISTA1 = null;
        private List<Guns> _LISTA2 = null;
        private List<Guns> _LISTA3 = new List<Guns>();

        /// <summary>Carga los componentes de la interfaz</summary>
        public MainWindow() => InitializeComponent();

        /// <summary>Metodo que se ejecuta al cargar la pagina</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            /* ========== ABRE EL FICHERO JSON_1 EN LA LISTA LIST_1 Y CARGA LOS DATOS EN EL GRID_1 ========== */
            load_JSON1();

            /* ========== ABRE EL FICHERO JSON_2 EN LA LISTA LIST_2 Y CARGA LOS DATOS EN EL GRID_2 ========== */
            load_JSON2();
        }

        /// <summary>Carga los datos en la lista LISTA_3</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void merge_list_Click(object sender, RoutedEventArgs e) => list_merge();

        /// <summary>Junta los datos de la lista LISTA_1 y la lista LIST_2 en la lista LIST_3</summary>
        private void list_merge() {

            _LISTA3.AddRange(_LISTA1);
            _LISTA3.AddRange(_LISTA2);
            dg_LIST_3.ItemsSource = _LISTA3;
            dg_LIST_3.Visibility = Visibility.Visible;
        }

        /// <summary>Carga los datos del json JSON_1 en la lista LISTA_1</summary>
        private void load_JSON1() {

            try {
                _LISTA1 = JsonConvert.DeserializeObject<List<Guns>>(File.ReadAllText(_path_JSON1));
                dg_LIST_1.ItemsSource = _LISTA1;
            }
            catch (Exception err) { MessageBox.Show("Error al cargar el fichero. Pongase en contacto con el administrador."); }
        }

        /// <summary>Carga los datos del json JSON_2 en la lista LISTA_2</summary>
        private void load_JSON2() {

            try {
                _LISTA2 = JsonConvert.DeserializeObject<List<Guns>>(File.ReadAllText(_path_JSON2));
                dg_LIST_2.ItemsSource = _LISTA2;
            }
            catch (Exception err) { MessageBox.Show("Error al cargar el fichero. Pongase en contacto con el administrador."); }
        }
    }
}
