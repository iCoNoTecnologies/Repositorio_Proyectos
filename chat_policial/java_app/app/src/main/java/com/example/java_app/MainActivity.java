package com.example.java_app;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;


public class MainActivity extends AppCompatActivity {
     EditText text1;
     EditText text2;
     int saludo;
    int saludo2;
     TextView nom;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        text1 =(EditText)findViewById(R.id.editText);
        nom =(TextView)findViewById(R.id.Nombre);
         text2=(EditText)findViewById(R.id.editText2);


    }

    public void MuestraTexto(View view) {
        saludo = Integer.parseInt(String.valueOf(text1.getText()));
        saludo2 = Integer.parseInt(String.valueOf(text2.getText()));
        saludo=saludo+saludo2;
  nom.setText("hola: "+saludo);

  nom.setVisibility(View.VISIBLE);
  if(saludo==100){
      Intent intent = new Intent(view.getContext(), Inicio.class);
      intent.putExtra("Nombre",saludo);
      startActivityForResult(intent, 0);
  }
    }
}
