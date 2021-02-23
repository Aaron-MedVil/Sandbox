package TCP;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.InetAddress;
import java.net.Socket;
import java.util.Scanner;

public class Cliente {

	public static void main(String[] args) throws IOException {
		
		int puerto = 123;
		InetAddress ip = InetAddress.getByName("localhost");
		Scanner teclado = new Scanner(System.in);
		
		Socket cliente = new Socket(ip, puerto);
		
		DataInputStream dis = new DataInputStream(cliente.getInputStream()); // Recibe
		DataOutputStream dos = new DataOutputStream(cliente.getOutputStream()); // Envia
		
		System.out.println(dis.readUTF());
		System.out.println("Mensaje hacia el servidor");
		String msg = teclado.nextLine();
		dos.writeUTF(msg);
		
		dis.close();
		dos.close();
		cliente.close();
		teclado.close();
	}
}