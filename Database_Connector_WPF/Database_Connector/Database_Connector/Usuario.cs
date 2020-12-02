namespace Database_Connector {

    class Usuario {

        private int id;
        private string nombre, usuario, password, fecha_alta, fecha_baja, hash;

        /// <summary>Constructor del usuario</summary>
        /// <param name="id">Identificador del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="usuario">Alias del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="fecha_alta">Fecha de alta del usuario</param>
        /// <param name="fecha_baja">Fecha de baja del usuario</param>
        /// <param name="hash">Token del usuario</param>
        public Usuario(int id, string nombre, string usuario, string password, string fecha_alta, string fecha_baja, string hash) {
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.password = password;
            this.fecha_alta = fecha_alta;
            this.fecha_baja = fecha_baja;
            this.hash = hash;
        }

        /// <summary>Getter/Setter id usuario</summary>
        public int _id { get => id; set => id = value; }

        /// <summary>Getter/Setter nombre usuario</summary>
        public string _nombre { get => nombre; set => nombre = value; }

        /// <summary>Getter/Setter nick usuario</summary>
        public string _usuario { get => usuario; set => usuario = value; }

        /// <summary>Getter/Setter contraseña usuario</summary>
        public string _password { get => password; set => password = value; }

        /// <summary>Getter/Setter fecha alta usuario</summary>
        public string _fecha_alta { get => fecha_alta; set => fecha_alta = value; }

        /// <summary>Getter/Setter fecha baja usuario</summary>
        public string _fecha_baja { get => fecha_baja; set => fecha_baja = value; }

        /// <summary>Getter/Setter token usuario</summary>
        public string _hash { get => hash; set => hash = value; }
    }
}
