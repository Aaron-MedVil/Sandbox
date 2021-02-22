package Sqlite;

import java.sql.*;

public class Insercion {

	public static void main(String[] args) {

		// Cadena de conexion a la base de datos
		String strConn = "jdbc:sqlite:D:/Github/Sandbox/Repaso_examen_AD/Data/ejemplo.db";

		try {

			// Clase para manejar el sgdb
			Class.forName("org.sqlite.JDBC");

			// Abrimos conexion a la DB
			Connection conn = DriverManager.getConnection(strConn);

			// Controlador de la DB
			Statement stmt = conn.createStatement();

			// Sentencia que vamos a ejecutar
			String sql = "INSERT INTO departamentos VALUES(70, 'RECURSOS HUMANOS', 'BURGOS')";

			// Ejecutamos la sentencia
			ResultSet rSet = stmt.executeQuery(sql);

			// Esto es casi lo mas importante del programa
			rSet.close(); stmt.close(); conn.close();
		}
		catch (ClassNotFoundException err) { err.printStackTrace(); }
		catch (SQLException err) { err.printStackTrace(); }
	}
}