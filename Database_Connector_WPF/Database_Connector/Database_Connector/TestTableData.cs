using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Connector {

    class TestTableData {

        private int id;
        private string nombre;

        /// <summary>Constructor</summary>
        /// <param name="id">Identificador del registro</param>
        /// <param name="nombre">Nombre del registro</param>
        public TestTableData(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
        }

        /// <summary>Getter/Setter id</summary>
        public int Id { get => id; set => id = value; }

        /// <summary>Getter/Setter nombre</summary>
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
