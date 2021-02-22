package Metadata_H2;

import java.sql.*;

public class Main {

	public static void main(String[] args) {

		String strConn = "jdbc:h2:D:/Programs/H2/DB/Repaso/repaso";
		
		try {
			
			Class.forName("org.h2.Driver");
			Connection conn = DriverManager.getConnection(strConn, "sa", "");
			
			DatabaseMetaData dbmd = conn.getMetaData();
			ResultSet rSet = null;
			
			/* ============================================================= */
			/* ========== Datos de la conexion a la base de datos ========== */
			/* ============================================================= */
			System.out.println("Datos de la conexion a la base de datos");
			System.out.println("\tNombre: " + dbmd.getDatabaseProductName());
			System.out.println("\tDriver: " + dbmd.getDriverName());
			System.out.println("\tUrl: " + dbmd.getURL());
			System.out.println("\tUsuario: " + dbmd.getUserName());
			
			/* ============================================================= */
			/* ========== Datos de las tablas de la base de datos ========== */
			/* ============================================================= */
			rSet = dbmd.getTables(null, null, "PRUEBAS", null);
			while (rSet.next()) {
				System.out.println("\nDatos de las tablas de la base de datos");
				System.out.println("\tCatálogo: " + rSet.getString(1));
				System.out.println("\tEsquema: " + rSet.getString(2));
				System.out.println("\tTabla: " + rSet.getString(3));
				System.out.println("\tTipo: " + rSet.getString(4));
			}
			
			/* =============================================================== */
			/* ========== Datos de las columnas de la base de datos ========== */
			/* =============================================================== */
			rSet = dbmd.getColumns(null, null, "PRUEBAS", null);
			while (rSet.next()) {
				System.out.println("\nDatos de las columnas de la base de datos");
				System.out.println("\tNombre: " + rSet.getString("COLUMN_NAME"));
				System.out.println("\tTipo: " + rSet.getString("TYPE_NAME"));
				System.out.println("\tTamaño: " + rSet.getString("COLUMN_SIZE"));
				System.out.println("\tNull: " + rSet.getString("IS_NULLABLE"));
			}
			
			/* ========================================================= */
			/* ========== Datos de las PK de la base de datos ========== */
			/* ========================================================= */
			rSet = dbmd.getPrimaryKeys(null, null, "PRUEBAS");
			while (rSet.next()) {
				System.out.println("\nDatos de las claves primarias de la base de datos");
				System.out.println("\tNombre: " + rSet.getString("COLUMN_NAME"));
			}
			
			conn.close();
			rSet.close();
		}
		catch (ClassNotFoundException err) { err.printStackTrace(); }
		catch (SQLException err) { err.printStackTrace(); }
		catch (Exception err) { err.printStackTrace(); }
	}
}