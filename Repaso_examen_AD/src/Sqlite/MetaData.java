package Sqlite;

import java.sql.*;

public class MetaData {

	public static void main(String[] args) {

		// Cadena de conexion a la base de datos
		String strConn = "jdbc:sqlite:D:/Github/Sandbox/Repaso_examen_AD/Data/ejemplo.db";

		try {

			// Clase para manejar el sgdb
			Class.forName("org.sqlite.JDBC");

			// Abrimos conexion a la DB
			Connection conn = DriverManager.getConnection(strConn);
			
			// Creamos las metadatas y las enlazamos a la conexion
			DatabaseMetaData dbmt = conn.getMetaData();
			
			System.out.println("Product name: " + dbmt.getDatabaseProductName());
			System.out.println("Driver: " + dbmt.getDriverName());
			System.out.println("URL: " + dbmt.getURL());
			System.out.println("Usuario: " + dbmt.getUserName());

			// Obtiene informacion de las tablas de la base de datos
			ResultSet rSetTablas = dbmt.getTables(null, null, null, null);
			while (rSetTablas.next()){
				System.out.println("=========Tablas===========");
				System.out.println(rSetTablas.getString(1));
				System.out.println(rSetTablas.getString(2));
				System.out.println(rSetTablas.getString(3));
				System.out.println(rSetTablas.getString(4));
			}
			rSetTablas.close();
			
			// Devuelve las columnas de la base de datos
			ResultSet rSetColumns = dbmt.getColumns(null, null, "departamentos", null);
			while (rSetColumns.next()){
				System.out.println("=========Columnas===========");
				System.out.println(rSetColumns.getString(1));
				System.out.println(rSetColumns.getString(2));
				System.out.println(rSetColumns.getString(3));
				System.out.println(rSetColumns.getString(4));
			}
			rSetColumns.close();
			
			// Devuelve las columnas de la base de datos
			ResultSet rSetPks = dbmt.getPrimaryKeys(null, null, "departamentos");
			while (rSetPks.next()){
				System.out.println("=========Pks===========");
				System.out.println(rSetPks.getString("COLUMN_NAME"));
			}
			rSetPks.close();

			// Esto es casi lo mas importante del programa
			conn.close();
		}
		catch (ClassNotFoundException err) { err.printStackTrace(); }
		catch (SQLException err) { err.printStackTrace(); }
	}
}