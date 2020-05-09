import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:chat_policial/main.dart';
import 'package:chat_policial/pages/listarUsuarios.dart';

TextEditingController user=new TextEditingController();
TextEditingController pass=new TextEditingController();

TextFormField boton1 =new TextFormField(

  controller: user,

  style: TextStyle(
    color: Colors.green, //color de la letra dentro del input
  ),

  decoration: new InputDecoration(
    labelText: "USUARIO",
    labelStyle: new TextStyle(
        color: const Color(0xFF424242)

    ),

    icon: new Icon(Icons.email),

    fillColor: Colors.grey.withOpacity(0.1),
    filled: true,
    focusedBorder: OutlineInputBorder(

      borderRadius: const BorderRadius.all(

        const Radius.circular(40.0),
      ),
      borderSide: new BorderSide(
        color: Colors.green,
        width: 1.0,
      ),

    ),
    enabledBorder: OutlineInputBorder(
      borderRadius: const BorderRadius.all(

        const Radius.circular(40.0),
      ),
      borderSide: BorderSide(color: Colors.white, width: 1.0),
    ),
    hintText: 'ejemplo : Carlitos1@7475.com',
    hintStyle: TextStyle(color: Colors.green),//color de la letra de ejemplo dentro del input
  ),

  keyboardType: TextInputType.emailAddress,
);
//*********************************************************************************************BOTON2*******************************************************************************
TextFormField boton2=new TextFormField(
  controller: pass,
  style: TextStyle(
    color: Colors.green, //color de la letra dentro del input
  ),
  decoration: new InputDecoration(
    labelStyle: new TextStyle(
        color: const Color(0xFF424242)

    ),
    fillColor: Colors.grey.withOpacity(0.1),
    filled: true,
    icon: new Icon(Icons.vpn_key),
    labelText: "INGRESA CONTRASEÑA",
    focusedBorder: new OutlineInputBorder(


      borderRadius: const BorderRadius.all(

        const Radius.circular(40.0),
      ),
      borderSide: new BorderSide(
        color: Colors.green,

        width: 1.0,
      ),
    ),
    enabledBorder: OutlineInputBorder(
      borderRadius: const BorderRadius.all(

        const Radius.circular(40.0),
      ),
      borderSide: BorderSide(color: Colors.white, width: 1.0),
    ),

    hintText: '********',
    hintStyle: TextStyle(color: Colors.green),
  ),

  keyboardType: TextInputType.text,

  obscureText: true,

);

