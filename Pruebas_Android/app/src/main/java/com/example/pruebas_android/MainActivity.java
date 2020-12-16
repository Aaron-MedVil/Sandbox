package com.example.pruebas_android;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.util.SparseArray;
import android.view.View;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    /**
     * Obtiene los datos de un array-string del arrays.xml y lo retorna como un SparseArray
     * @param stringArrayResourceId
     * @return
     */
    public SparseArray<String> parseStringArray(int stringArrayResourceId) {

        // Obtiene la lista de elementos del string-array que hemos especificado
        String[] stringArray = getResources().getStringArray(stringArrayResourceId);

        // Crea un objeto SparseArray en el que almacenaremos los datos del array
        SparseArray<String> outputArray = new SparseArray<String>(stringArray.length);

        int i = -1;

        // Recorre el array que hemos recuperado
        for (String entry : stringArray) { outputArray.put(i++, entry); }

        // Devuelve el SparseArray
        return outputArray;
    }

    /**
     * Carga los datos del array
     * @param view
     */
    public void loadArrayData(View view) {

        String message = "";

        // Obtiene los datos del array
        SparseArray<String> myStringArray = parseStringArray(R.array.arrayPruebas);

        // Guarda el contenido delarray en una cadena de texto
        for (int i = 0; i < myStringArray.size(); i++) { message += "\n" + myStringArray.get(myStringArray.keyAt(i)); }

        // Comprueba que la cadena de texto no es vacia
        message = (message.isEmpty()) ? getResources().getString(R.string.emptyData) : message;

        AlertDialog.Builder arrDial = new AlertDialog.Builder(this);
        arrDial.setTitle(R.string.dialArrayTitle);
        arrDial.setMessage(message);
        arrDial.setPositiveButton(getResources().getString(R.string.btnAceptar), new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) { dialog.cancel(); }
        });
        arrDial.show();
    }

    /**
     * Carga los datos del json
     * @param view
     */
    public void loadJsonData(View view) {

        try {

            // Recuperamos los datos del JSON
            InputStream is = getResources().openRawResource(R.raw.datos);

            // Creamos un array de caracteres para guardar los datos
            byte[] buffer = new byte[is.available()];

            // Guardamos los datos del fichero en el array de caracteres
            is.read(buffer);

            // Asignamos codificacion de caracteres al json
            String strJson = new String(buffer,"UTF-8");

            // Cerramos el flujo de datos
            is.close();

            // Creamos una instancia JSONObject de la cadena del fichero que hemos recuperado
            JSONObject jsonRootObject = new JSONObject(strJson);

            // Creamos un JSONArray de la instancia de JSONObject
            JSONArray jsonArray = jsonRootObject.optJSONArray("personas");

            Log.d("cosa", jsonArray.toString());
        } catch (JSONException | IOException e) {e.printStackTrace();}
    }
}