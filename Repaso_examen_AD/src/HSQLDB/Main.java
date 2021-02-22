package HSQLDB;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Main {

	public static void main(String[] args) {
		
		String strConn = "jdbc:hsqldb:file:D:/Programs/hsqldb/data/Repaso/Repaso";
		int cont = 0;

		try {
			
			Class.forName("org.hsqldb.jdbcDriver");
			Connection conn = DriverManager.getConnection(strConn);
			
			Statement stmt = conn.createStatement();
			String sql = "SELECT id, nombre, descripcion FROM pruebas";
			ResultSet rSet = stmt.executeQuery(sql);
			
			while (rSet.next()) {
				System.out.println("Datos del registro " + cont);
				System.out.println("\tID: " + rSet.getInt("id"));
				System.out.println("\tNombre: " + rSet.getString("nombre"));
				System.out.println("\tDescripción: " + rSet.getString("descripcion"));
				System.out.println("=======================================================");
				
				cont++;
			}
			
			conn.close();
			stmt.close();
			rSet.close();
		}
		catch (ClassNotFoundException err) { err.printStackTrace(); }
		catch(SQLException err) { err.printStackTrace(); }
	}
}