package TCP;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Servidor {

	public static void main(String[] args) throws IOException {
		
		int puerto = 123, cont = 0;

		// Conexion cliente-servidor
		ServerSocket server = new ServerSocket(puerto);
		
		while(cont <= 3) {
			
			Socket cliente = null;
			cliente = server.accept();
			System.out.println("Cliente conectado");
			
			Hilo h = new Hilo(cliente);
			h.start();
			
			cont++;
		}
		
		server.close();
	}
}