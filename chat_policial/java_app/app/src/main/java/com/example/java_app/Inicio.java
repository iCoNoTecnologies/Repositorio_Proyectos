package com.example.java_app;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

public class Inicio extends AppCompatActivity {
    TextView text;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_inicio);
        Bundle datos = this.getIntent().getExtras();
        text=(TextView)findViewById(R.id.Texto1);
        int dato = datos.getInt("Nombre");

 String result =String.valueOf(dato);
      
        text.setVisibility(View.VISIBLE);
        text.setText(result);
    }
}
