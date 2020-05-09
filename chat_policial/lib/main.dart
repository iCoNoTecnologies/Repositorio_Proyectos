import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:chat_policial/bodegaPage.dart';
import 'package:chat_policial/pages/listarUsuarios.dart';
import 'package:chat_policial/componentes.dart';
void main() => runApp(new MyApp());

String username='';
String NumEmpleado='';
class MyApp extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return new MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Login PHP My Admin',
      home: new MyHomePage(),
      routes: <String,WidgetBuilder>{
        '/pages/listarUsuarios': (BuildContext context)=> new Home(username: username,NumEmpleado:NumEmpleado),
        '/bodegaPage': (BuildContext context)=> new BodegaPage(username: username,),
        '/MyHomePage': (BuildContext context)=> new MyHomePage(),
      },
    );

  }

}

class MyHomePage extends StatefulWidget {
  @override
  _MyHomePageState createState() => _MyHomePageState();

}

class _MyHomePageState extends State<MyHomePage>  with SingleTickerProviderStateMixin{
  AnimationController _iconAnimationController;
  Animation<double>_iconAnimation;



  String msg='';
  @override
  void initState(){
    super.initState();
    // declarar botones con componentes iniciales exito******************************************************************************************
    boton1;
    boton2;
    //******************************************************************************************************************************************************
    _iconAnimationController = new AnimationController(vsync: this,
        duration:  new Duration(milliseconds: 2000)
    );
    _iconAnimation = new CurvedAnimation(parent: _iconAnimationController,
        curve: Curves.easeOut

    );
    _iconAnimation.addListener(()=>this.setState((){}));
    _iconAnimationController.forward();



  }


  Future<List> _login() async {


    final response = await http.post("http://201.144.14.11/AppsManager/login.php", body: {
      "username": user.text,
      "password": pass.text,
    });

    var datauser = json.decode(response.body);
    print(datauser.toString());
    if(datauser.length==0){
      setState(() {
        msg="Login Fail";
      });
    }else{

        Navigator.pushReplacementNamed(context, '/pages/listarUsuarios');


      setState(() {
        username= datauser[0]['Nombre'];
        NumEmpleado=datauser[0]['NoEmpleado'];
      });

    }

    return datauser;
  }


  @override
  Widget build(BuildContext context) {

    return new Scaffold(
      appBar: AppBar(
        title: Text("SSPMC"),

      ),

      backgroundColor: Colors.white,
      body: new Stack(
        fit: StackFit.expand,
        children: <Widget>[
          new Image(
            image:new AssetImage("assets/SSPMC.jpg"),
            fit: BoxFit.cover,
            color: Colors.black54,
            colorBlendMode: BlendMode.lighten,


          ),

          new Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[

              new Hero(
                tag: 'hero',

                child: Padding(

                  padding: EdgeInsets.fromLTRB(0.0, 10.0, 0.0, 0.0),
                  child: CircleAvatar(
                    backgroundColor: Colors.lightGreenAccent.withOpacity(0.4),

                    radius: _iconAnimation.value *60,

                    child:  Image.asset('assets/images/policia.png'),

                  ),
                ),
              ),
              new Form(
                  child:new Theme(
                    data: new ThemeData(
                        brightness: Brightness.dark,
                        primarySwatch: Colors.blue, inputDecorationTheme: new InputDecorationTheme(
                        labelStyle: new TextStyle(
                          color: Colors.green,fontSize: 20.0,
                          backgroundColor: Colors.yellowAccent,
                        )
                    )
                    ),
                    child:new Container(
                      padding: const EdgeInsets.all(40.0),
                      child: new Column(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: <Widget>[
                          boton1,
                          new Padding(padding: const EdgeInsets.only(top: 20.0),

                          ),

                          boton2,
                          new Padding(padding: const EdgeInsets.only(top: 20.0),

                          ),

                      new Padding(padding: const EdgeInsets.only(left: 70.0),
                      ),

                          new MaterialButton(
                            shape: RoundedRectangleBorder(
                                borderRadius: new BorderRadius.circular(60.0),
                                side: BorderSide(color: Colors.lightBlue)
                            ),
                            height: 55.0,


                            minWidth: _iconAnimation.value*200,
                            color: Colors.white,
                            textColor: Colors.black,
                            child: new Icon(Icons.account_circle),




                            onPressed: (){
                              if(user.text!='') {
                                _login();
                                Navigator.pop(context);

                              }
                              else{
                                return setState(() {//se cambia el estado del boton
                                  boton1 =new TextFormField(

                                    controller: user,

                                    style: TextStyle(
                                      color: Colors.green, //color de la letra dentro del input
                                    ),

                                    decoration: new InputDecoration(
                                      labelText: "falta llenar",
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
                                        borderSide: BorderSide(color: Colors.red, width: 1.0),
                                      ),
                                      hintText: 'falta llenar',
                                      hintStyle: TextStyle(color: Colors.green),//color de la letra de ejemplo dentro del input
                                    ),

                                    keyboardType: TextInputType.emailAddress,
                                  );

                                });
                              }
                            },
                            splashColor: Colors.blueAccent,
                          ),
                          Text(
                            msg,
                          ),
                        ],

                      ),
                    ),

                  )
              ),
            ],
          ),
          new Column(

          ),
        ],
      ),

    );


  }

}