import 'dart:convert';
import 'package:permission_handler/permission_handler.dart';
import 'package:not_one_less/pages/PrincipalPage.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:imei_plugin/imei_plugin.dart';
import 'dart:async';

class Home extends StatefulWidget {

  Home({this.username,this.NumEmpleado});
  final String username;
  final String NumEmpleado;


  bool ayuda=false;
  @override
  _HomeState createState() => new _HomeState();

}

String linkavatar="https://notoneless.000webhostapp.com/notoneless/Logos/LogoNotOneLess.png";
 String nicknamecontroller="Nombre de usuario";
TextStyle nicknametextcolor= TextStyle(color: Colors.green);
TextEditingController name=new TextEditingController();
TextEditingController sexo=new TextEditingController();
TextEditingController nickname=new TextEditingController();
TextEditingController edad=new TextEditingController();
TextEditingController telefono=new TextEditingController();
bool monVal = false;
bool masculino=false;
bool Femenino=false;

class _HomeState extends State<Home> {
  String imei ;

  var refreshKey = GlobalKey<RefreshIndicatorState>();
  @override
  Widget build(BuildContext context) {





    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Not One Less',
      routes: <String,WidgetBuilder>{

        '/pages/PrincipalPage': (BuildContext context)=> new PrincipalPage(),

      },
      theme: ThemeData(

        primarySwatch: Colors.purple,
      ),

      home:  result(),                 //aqui se llama al formulario

    );


  }





  result() {
    //aqui va la consulta a la base de datos para verificar si el usuario ya se registro si no se registro se le mostrara un pequeño formulario para que se registre
    //si ya se a registrado se mostrara la interfaz principal

   return    Scaffold(

     resizeToAvoidBottomPadding: false,
     appBar: new AppBar(title: new Text("Registro de usuario")),
     body: new Container(
       height: 590.0,
       padding: const EdgeInsets.all(20.0),
       child: new Card(
         child: new Center(
           child: new Column(
             children: <Widget>[

               new Padding(padding: const EdgeInsets.only(top: 5.0),),
               new Image.network('${linkavatar}',width: 70,  //
                 height: 70,),
               new Text('Registro', style: new TextStyle(fontSize: 20.0),),

               Divider(),
               new Text("Datos Personales", style: new TextStyle(fontSize: 18.0),),
               new Padding(padding: const EdgeInsets.only(top: 20.0),),
               new TextFormField(

                 controller: name,

                 style: TextStyle(
                   color: Colors.green, //color de la letra dentro del input
                 ),

                 decoration: new InputDecoration(
                   icon: new Icon(Icons.account_circle),
                   contentPadding: const EdgeInsets.symmetric(vertical: 10.0, horizontal: 30.0),
                   labelText: "Nombre Completo",
                   labelStyle: new TextStyle(
                       color: const Color(0xFF424242)

                   ),



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
                   hintText: 'Nombre Apellidos ',
                   hintStyle: TextStyle(color: Colors.green),//color de la letra de ejemplo dentro del input
                 ),

                 keyboardType: TextInputType.text,
               ),

               new Padding(padding: const EdgeInsets.only(top: 10.0),),

               new TextFormField(

                 controller: nickname,

                 style: TextStyle(
                   color: Colors.green, //color de la letra dentro del input
                 ),

                 decoration: new InputDecoration(

                   icon: new Icon(Icons.supervised_user_circle),
                   contentPadding: new EdgeInsets.symmetric(vertical: 10.0, horizontal: 30.0),
                   labelText: 'Nombre de Usuario',
                   labelStyle: new TextStyle(
                       color: const Color(0xFF424242)

                   ),



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
                   hintText: nicknamecontroller,
                   hintStyle: nicknametextcolor,//color de la letra de ejemplo dentro del input
                 ),

                 keyboardType: TextInputType.text,
               ),

               new Padding(padding: const EdgeInsets.only(top: 10.0),),

            //***************************************************************************sexo********************************************************************************
               new Row(
                 mainAxisSize: MainAxisSize.min,
                 children: <Widget>[
                   Text("Femenino:",),
                   VerticalDivider(),
                   Checkbox(
                     value: Femenino,
                     onChanged: (bool value) {
                       setState(() {
                         Femenino = value;
                         if(Femenino){
                          setState(() {
                            linkavatar="https://notoneless.000webhostapp.com/notoneless/Logos/womanlogo.png";

                            Femenino=true;
                            masculino=false;
                          });
                         }
                       });
                     },
                   ),
                   Text("Masculino:",),
                   VerticalDivider(),
                   Checkbox(
                     value: masculino,
                     onChanged: (bool value) {
                       setState(() {
                         masculino = value;
                         if(masculino){
                          setState(() {
                            linkavatar="https://notoneless.000webhostapp.com/notoneless/Logos/userman.png";
                            masculino=true;
                            Femenino=false;
                          });
                         }
                       });
                     },
                   ),

                 ],
               ),


               new Padding(padding: const EdgeInsets.only(top: 10.0),),
               new TextFormField(

                 controller: edad,

                 style: TextStyle(
                   color: Colors.green, //color de la letra dentro del input
                 ),

                 decoration: new InputDecoration(

                   icon: new Icon(Icons.cake),
                   contentPadding: new EdgeInsets.symmetric(vertical: 10.0, horizontal: 30.0),
                   labelText: "Edad",
                   labelStyle: new TextStyle(
                       color: const Color(0xFF424242)

                   ),



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
                   hintText: 'Edad en años',
                   hintStyle: TextStyle(color: Colors.green),//color de la letra de ejemplo dentro del input
                 ),

                 keyboardType: TextInputType.number,
               ),


               new Padding(padding: const EdgeInsets.only(top: 10.0),),
               new TextFormField(

                 controller: telefono,

                 style: TextStyle(
                   color: Colors.green, //color de la letra dentro del input
                 ),

                 decoration: new InputDecoration(

                   icon: new Icon(Icons.settings_cell),
                   contentPadding: new EdgeInsets.symmetric(vertical: 10.0, horizontal: 30.0),
                   labelText: "Telefono",
                   labelStyle: new TextStyle(
                       color: const Color(0xFF424242)

                   ),



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
                   hintText: '+52 1 442 475 2371',
                   hintStyle: TextStyle(color: Colors.green),//color de la letra de ejemplo dentro del input
                 ),

                 keyboardType: TextInputType.number,
               ),
               new Row(
                 mainAxisSize: MainAxisSize.min,
                 children: <Widget>[
                   Text("Aceptar Terminos y Condiciones:",),
                   VerticalDivider(),
                   Checkbox(
                     value: monVal,
                     onChanged: (bool value) {
                       setState(() {
                         monVal = value;
                         if(monVal){
                           confirm(context);
                         }
                       });
                     },
                   ),

                 ],
               ),


               new Padding(padding: const EdgeInsets.only(top: 10.0),),
               new Row(
                 mainAxisSize: MainAxisSize.min,
                 children: <Widget>[
                   new MaterialButton(
                     shape: RoundedRectangleBorder(
                         borderRadius: new BorderRadius.circular(60.0),
                         side: BorderSide(color: Colors.purpleAccent)
                     ),
                     height: 40.0,


                     minWidth: 150,
                     color: Colors.white,
                     textColor: Colors.purple,
                     child: new Icon(Icons.arrow_forward),


                       onPressed: () {

                         Registrar();
                       }

                   ),
                   VerticalDivider(),

                    
                 ],
               )
             ],
           ),

         ),
       ),
     ),
   );


  }
  Future<void> confirm(BuildContext context) {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(

          title: Text('Términos y condiciones'),


          content: Container(
          height: 210,
          width: 300,
            child: SingleChildScrollView(
            // won't be scrollable
              child: Column(
              children: <Widget>[

             Text('¡Te damos la bienvenida a Not One Less!',style: TextStyle(color: Colors.deepPurple[400],fontSize: 12)),
                Text('#NiUnaMenos',style: TextStyle(color: Colors.deepPurple[400],fontSize: 12)),
               Divider(),
                Text('IconoTecnologies desarrolla tecnologías y servicios'
                    'que permiten que las personas se conecten,'
                    ' creando comunidades y sociedades colectivas. NotOneLess(#NiUnaMenos) '
                'es una aplicación que tiene como propósito facilitar '
            'la atención de llamadas de auxilio por medio de una sociedad solidaria,'
               ' personas que pretendan estar preparadas para convatir'
           ' uno de los mayores problemas que se viven en el país, '

                'el acoso femenino, situaciones que muchas veces terminan'
            ' en trajedia.\n'
            'No cobramos por el uso que haces de NotOneLess(#NiUnaMenos) '
            ' ni de los otros productos y servicios que abarcan estás condiciones.\n'
            'Por el contrario, la aplicación puede estar sujeta a cambios de negocio, '
            'ya que es una aplicacion de desarrollo independiente '
            'que no obtiene ningún tipo de ingreso monetario o forma de lucro.\n'
                'IconoTecnologies no se hace responsable por el mal uso que se le dé a está tecnología,'
                ' ni por las acciones maliciosas que los usuarios pudieran llegar a ocacionar.',style: TextStyle(color: Colors.black87,fontSize: 12)),
              ]
              ),
          ),),


          actions: <Widget>[
            FlatButton(
              child: Text('Cancelar'),
              onPressed: () {
                setState(() {
                  monVal=false;
                });

                Navigator.of(context).pop();
              },
            ),
            FlatButton(
              child: Text('Aceptar'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }
  Future<List> Registrar() async {
    String sex="";
    imei= await ImeiPlugin.getImei();


    if(name.text!="" && nickname.text!="" && telefono.text!=""&& edad.text!=""&& monVal==true &&Femenino==true||
        name.text!="" && nickname.text!="" && telefono.text!=""&& edad.text!=""&& monVal==true &&masculino==true) {


      String Terminos="SI";

      final response = await http.post(
          "https://notoneless.000webhostapp.com/notoneless/nicknamecheck.php",
          body: {

            "nickname": nickname.text,
          });
      var data = json.decode(response.body);
      //print(data.toString());


      if (data.length != 0) {
        print("este nickname ya esta en uso");
        setState(() {
          nicknamecontroller="Este usuario ya existe";
          nicknametextcolor= TextStyle(color: Colors.red);
          nickname.clear();
          nickname.selection;
        });
        alertnickname(context, "Este Usuario ya esta En uso!");

      } else {
        //aqui va la insercion de datos
        if(Femenino==true){
          setState(() {
            sex="Femenino";
          });

        }else if(masculino==true){
          setState(() {
            sex="Masculino";
          });
        }else{
          alertnickname(context, "Por favor ingresa un sexo");
        }

        print("se insertara: nombre:${name.text} nickname:${nickname.text} telefono:${telefono.text} imei:${imei.toString()} edad:${edad.text} terminos:${Terminos}");
        final response2 = await http.post(
            "https://notoneless.000webhostapp.com/notoneless/Register.php",
            body: {

              "name": name.text,
              "nickname": nickname.text,
              "telefono": telefono.text,
              "imei": imei.toString(),
              "edad": edad.text,
              "sexo": sex,
              "terminos": Terminos,
            });
        //var data2 = json.decode(response2.body);

        //print(data2.toString());

       RegistroExitoso(context);
      }
      return data;
    }
  }

  Future<void> alertnickname(BuildContext context,String value) {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(

          title: Text('Ups!'),


          content: Container(

            child: SingleChildScrollView(
              // won't be scrollable
              child: Column(
                  children: <Widget>[

                    Text('${value}',style: TextStyle(color: Colors.red[300],fontSize: 18)),

                    Divider(),

                  ]
              ),
            ),),


          actions: <Widget>[

            FlatButton(
              child: Text('Aceptar'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );

  }
  Future<void> RegistroExitoso(BuildContext context) {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(

          title: Text('Gracias por Registrarse'),


          content: Container(

            child: SingleChildScrollView(
              // won't be scrollable
              child: Column(
                  children: <Widget>[

                    Text('¡Todo listo Bienvenido!',style: TextStyle(color: Colors.blue[300],fontSize: 17)),

                    Divider(),
                   Text("${nickname.text}",style: TextStyle(color: Colors.purpleAccent[300],fontSize: 20)),

                  ]
              ),
            ),),


          actions: <Widget>[

            FlatButton(
              child: Text('Aceptar'),
              onPressed: () {
                Timer(Duration(seconds: 1),()=>Navigator.pushReplacementNamed(context, '/pages/PrincipalPage') );
              },
            ),
          ],
        );
      },
    );

  }


}

newapp() {
}