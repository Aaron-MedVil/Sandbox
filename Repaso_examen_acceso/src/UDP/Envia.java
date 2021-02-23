package UDP;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Scanner;

public class Envia {

	public static void main(String[] args) throws IOException {
		
		int puerto = 123;
		InetAddress ip = InetAddress.getByName("localhost");
		Scanner teclado = new Scanner(System.in);
		byte[] envio = new byte[1024], recibo = new byte[1024];
		String msg, msgRecibo;
		
		DatagramSocket dgSocket = new DatagramSocket();
		
		/* ========== ENVIO DATAGRAMA ========== */
		System.out.println("Inserte un mensaje para enviar...");
		msg = teclado.nextLine();
		envio = msg.getBytes();
		DatagramPacket dgPacket = new DatagramPacket(envio, envio.length, ip, puerto);
		dgSocket.send(dgPacket);		
		
		/* ========== RECIBO DATAGRAMA ========== */
		DatagramPacket dgPacketRecibo = new DatagramPacket(recibo, recibo.length);
		dgSocket.receive(dgPacketRecibo);
		recibo = dgPacketRecibo.getData();
		msgRecibo = new String(recibo);
		System.out.println("Mensaje recibido por la clase Envia: " + msgRecibo.trim());
		
		dgSocket.close();
		teclado.close();
	}
}