package Sqlite;

import java.sql.*;

public class Consulta {

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
			String sql = "SELECT dept_no, dnombre, loc FROM departamentos";
			
			// Ejecutamos la sentencia
			ResultSet rSet = stmt.executeQuery(sql);
			
			// Imprime los datos
			while(rSet.next()) {
				System.out.println("========== DATOS DEL REGISTRO " + rSet.getRow() + " ==========");
				System.out.println("\tNumero departamento: " + rSet.getInt("DEPT_NO"));
				System.out.println("\tNombre: " + rSet.getString("DNOMBRE"));
				System.out.println("\tLocalizacion: " + rSet.getString("LOC") + "\n");
			}
			
			// Esto es casi lo mas importante del programa
			rSet.close(); stmt.close(); conn.close();
		}
		catch (ClassNotFoundException err) { err.printStackTrace(); }
		catch (SQLException err) { err.printStackTrace(); }
	}
}