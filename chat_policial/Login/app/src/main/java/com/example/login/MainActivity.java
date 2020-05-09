package com.example.login;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    EditText campo1;

    EditText campo2;
    Button btn_ingresa;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
     campo1=(EditText)findViewById(R.id.correo);
     campo2=(EditText)findViewById(R.id.contraseña);
     btn_ingresa=(Button)findViewById(R.id.ingresar);


    }




    public void ingreso(View view) {


        System.out.println("entro el boton");







 if(campo1.getText().toString().equals("ivan@hotmail.com")&& campo2.getText().toString().equals("1234")){


     System.out.println("entro el if");

     Intent intent=new Intent(view.getContext(),Interfaz.class);
     startActivityForResult(intent,0);


 }





    }
}
