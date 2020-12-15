package com.example.pruebas_android;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.util.SparseArray;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

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

    public void loadArrayData(View view) {

        SparseArray<String> myStringArray = parseStringArray(R.array.arrayPruebas);

        for (int i = 0; i < myStringArray.size(); i++) {
            Log.d("item", myStringArray.get(myStringArray.keyAt(i)));
        }
    }
}