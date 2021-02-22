package HSQLDB;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

public class Insert {

	public static void main(String[] args) {

		String strConn = "jdbc:hsqldb:file:D:/Programs/hsqldb/data/Repaso/Repaso";
		String nombre, desc;
		Scanner teclado = new Scanner(System.in);
		
		try {

			Class.forName("org.hsqldb.jdbcDriver");
			Connection conn = DriverManager.getConnection(strConn);
			
			while (true) {
				
				System.out.println("Inserte un nombre:");
				nombre = teclado.nextLine();
				
				System.out.println("Inserte una descripción:");
				desc = teclado.nextLine();
				
				Statement stmt = conn.createStatement();
				String sql = "INSERT INTO pruebas VALUES((SELECT Max(id) FROM pruebas) + 1, '" + nombre + "', '" + desc + "')";
				ResultSet rSet = stmt.executeQuery(sql);
				
				stmt.close();
				rSet.close();
				
				System.out.println("¿Desea seguir insertando registros? (exit para salir)");
				if (teclado.nextLine().equals("exit")) break;
			}

			conn.close();
		}
		catch (ClassNotFoundException err) { err.printStackTrace(); }
		catch (SQLException err) { err.printStackTrace(); }
	}
}