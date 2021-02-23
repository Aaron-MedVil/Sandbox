package UDP;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class Recibe {

	public static void main(String[] args) throws IOException {
		
		int puerto = 123;
		byte[] recibo = new byte[1024], envio = new byte[1024];
		String msg;
		
		DatagramSocket dgSocket = new DatagramSocket(puerto);
		
		/* ========== RECIBO DATAGRAMAS ========== */
		DatagramPacket dgPacket = new DatagramPacket(recibo, recibo.length);
		dgSocket.receive(dgPacket);
		recibo = dgPacket.getData();
		msg = new String(recibo).trim();
		System.out.println("Mensaje recibido por la clase Recibe: " + msg);
		
		/* ========== ENVIO DATAGRAMAS ========== */
		msg = msg + " Enviado de vuelta";
		envio = msg.trim().getBytes();
		DatagramPacket dgPacketEnvio = new DatagramPacket(envio, envio.length, dgPacket.getAddress(), dgPacket.getPort());
		dgSocket.send(dgPacketEnvio);
		
		dgSocket.close();
	}
}