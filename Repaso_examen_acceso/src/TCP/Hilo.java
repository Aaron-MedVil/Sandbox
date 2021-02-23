package TCP;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

public class Hilo extends Thread {
	
	private Socket cliente;

	public Hilo(Socket cliente) {
		this.cliente = cliente;
	}
	
	public void run() {
		
		try {
			
			DataInputStream dis = new DataInputStream(cliente.getInputStream());
			DataOutputStream dos = new DataOutputStream(cliente.getOutputStream());
			
			dos.writeUTF("Bienvenido al servidor cliente " + this.getName());
			
			String result = dis.readUTF();
			System.out.println(result);
			
			dis.close();
			dos.close();
			cliente.close();
		}
		catch (IOException e) { e.printStackTrace(); }
	}
}