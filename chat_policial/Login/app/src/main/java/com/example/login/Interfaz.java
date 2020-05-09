package com.example.login;

import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import android.graphics.drawable.DrawableContainer;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import static com.example.login.R.drawable.image1;

public class Interfaz extends AppCompatActivity {
CardView visualizar,visualizar2,visualiza3,visualizar4,visualizar5,visualizar6,visualizar7,visualiza8,visualizar9,visualizar11,visualizar12,visualizar13;
ImageView imagen1;
    ImageView imagecard;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_interfaz);
        visualizar=(CardView)findViewById(R.id.tarjeta);
        visualizar2=(CardView)findViewById(R.id.tarjeta2);
        visualiza3=(CardView)findViewById(R.id.tarjeta3);
        visualizar4=(CardView)findViewById(R.id.tarjeta4);
        visualizar5=(CardView)findViewById(R.id.tarjeta5);
        visualizar6=(CardView)findViewById(R.id.tarjeta6);
        visualizar7=(CardView)findViewById(R.id.tarjeta7);
        visualiza8=(CardView)findViewById(R.id.tarjeta8);
        visualizar9=(CardView)findViewById(R.id.tarjeta9);
        visualizar11=(CardView)findViewById(R.id.tarjeta10);
        visualizar12=(CardView)findViewById(R.id.tarjeta11);
        visualizar13=(CardView)findViewById(R.id.tarjeta12);
        imagen1=(ImageView) findViewById(R.id.imagen1);
        imagecard=(ImageView) findViewById(R.id.imageView15);

    }

    public void Muestra(View view) {
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar2.setVisibility(View.INVISIBLE);
        visualizar.setVisibility(View.VISIBLE);

    }

    public void ocultaimagen(View view) {
        visualizar4.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar.setVisibility(View.INVISIBLE);
        visualizar2.setVisibility(View.INVISIBLE);
    }

    public void Muestra2(View view) {
        visualizar4.setVisibility(View.INVISIBLE);
        visualizar.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar2.setVisibility(View.VISIBLE);

    }

    public void Muestra3(View view) {
        visualizar.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.INVISIBLE);
        visualizar2.setVisibility(View.INVISIBLE);
        visualizar7.setVisibility(View.INVISIBLE);

        visualiza8.setVisibility(View.INVISIBLE);
        visualizar9.setVisibility(View.INVISIBLE);
        visualizar11.setVisibility(View.INVISIBLE);
        visualizar12.setVisibility(View.INVISIBLE);
        visualizar13.setVisibility(View.INVISIBLE);
        visualizar6.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.VISIBLE);

    }
    public void Muestra4(View view) {

        visualizar.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar2.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar7.setVisibility(View.INVISIBLE);

        visualiza8.setVisibility(View.INVISIBLE);
        visualizar9.setVisibility(View.INVISIBLE);
        visualizar11.setVisibility(View.INVISIBLE);
        visualizar12.setVisibility(View.INVISIBLE);
        visualizar13.setVisibility(View.INVISIBLE);
        visualizar6.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.VISIBLE);


    }
    public void Muestra5(View view) {

        visualizar.setVisibility(View.INVISIBLE);

        visualizar2.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.INVISIBLE);
        visualizar7.setVisibility(View.INVISIBLE);

        visualiza8.setVisibility(View.INVISIBLE);
        visualizar9.setVisibility(View.INVISIBLE);
        visualizar11.setVisibility(View.INVISIBLE);
        visualizar12.setVisibility(View.INVISIBLE);
        visualizar13.setVisibility(View.INVISIBLE);
        visualizar6.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.VISIBLE);

    }
    public void Muestra6(View view) {

        visualizar.setVisibility(View.INVISIBLE);

        visualizar2.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar7.setVisibility(View.INVISIBLE);

        visualiza8.setVisibility(View.INVISIBLE);
        visualizar9.setVisibility(View.INVISIBLE);
        visualizar11.setVisibility(View.INVISIBLE);
        visualizar12.setVisibility(View.INVISIBLE);
        visualizar13.setVisibility(View.INVISIBLE);
        visualizar6.setVisibility(View.VISIBLE);
    }
    public void Muestra7(View view) {

        visualizar.setVisibility(View.INVISIBLE);

        visualizar2.setVisibility(View.INVISIBLE);
        visualiza3.setVisibility(View.INVISIBLE);
        visualizar4.setVisibility(View.INVISIBLE);
        visualizar5.setVisibility(View.INVISIBLE);
        visualizar7.setVisibility(View.VISIBLE);

        visualiza8.setVisibility(View.INVISIBLE);
        visualizar9.setVisibility(View.INVISIBLE);
        visualizar11.setVisibility(View.INVISIBLE);
        visualizar12.setVisibility(View.INVISIBLE);
        visualizar13.setVisibility(View.INVISIBLE);
        visualizar6.setVisibility(View.INVISIBLE);
    }
}
