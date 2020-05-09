import 'dart:convert';

import 'package:flutter/material.dart';
import 'dart:async';
import 'package:not_one_less/pages/CheckLogin.dart';
import 'package:not_one_less/pages/PrincipalPage.dart';
import 'package:permission_handler/permission_handler.dart';
import 'package:http/http.dart' as http;
import 'package:imei_plugin/imei_plugin.dart';


void main() => runApp(MyApp());
String username='';
String NumEmpleado='';
class MyApp extends StatelessWidget {


  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {


    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Not One Less',

      home: MyHomePage(title: 'Not One Less'),
      routes: <String,WidgetBuilder>{
        '/pages/CheckLogin': (BuildContext context)=> new Home(username: username,NumEmpleado:NumEmpleado),
        '/pages/PrincipalPage': (BuildContext context)=> new PrincipalPage(),

      },
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);
  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage>  with SingleTickerProviderStateMixin{
  AnimationController _iconAnimationController;
  Animation<double>_iconAnimation;
  PermissionStatus _status;
  String imei ;
int permision=0;
  @override
  void initState(){

    super.initState();
    // declarar botones con componentes iniciales exito******************************************************************************************

    //******************************************************************************************************************************************************
    _iconAnimationController = new AnimationController(vsync: this,
        duration:  new Duration(milliseconds: 2000)
    );
    _iconAnimation = new CurvedAnimation(parent: _iconAnimationController,
        curve: Curves.easeOut

    );
    _iconAnimation.addListener(()=>this.setState((){}));
    _iconAnimationController.forward();

    if(PermissionHandler().checkPermissionStatus(PermissionGroup.locationWhenInUse)!=PermissionStatus.granted)
    {
      print("no ay permiso de ubicacion");
      PermissionHandler().requestPermissions([PermissionGroup.locationWhenInUse,PermissionGroup.phone,PermissionGroup.storage]);
    }


getData2();


  }


  Future<List> getData2() async {
    imei= await ImeiPlugin.getImei();
    // refreshKey.currentState?.show(atTop: false);
    //print(NumEmpleado);
    // print(imei.toString());
    //await Future.delayed(Duration(seconds: 2));

    try {
      final response = await http.post(
          "https://notoneless.000webhostapp.com/notoneless/UserVerification.php",
          body: {
            "imei": imei,
          });
      var data = json.decode(response.body);
      //print(data.toString());
      if (data.length != 0) {
        Timer(Duration(seconds: 3), () =>
            Navigator.pushReplacementNamed(context, '/pages/PrincipalPage'));
      } else {
        print("el usuario no existe");
        Timer(Duration(seconds: 3), () =>
            Navigator.pushReplacementNamed(context, '/pages/CheckLogin'));
      }
      return data;

    }catch(error){
      Timer(Duration(seconds: 3), () =>
          Navigator.pushReplacementNamed(context, '/pages/PrincipalPage'));

    }
  }


  @override
  Widget build(BuildContext context) {
    // This method is rerun every time setState is called, for instance as done
    // by the _incrementCounter method above.
    //
    // The Flutter framework has been optimized to make rerunning build methods
    // fast, so that you can just rebuild anything that needs updating rather
    // than having to individually change instances of widgets.
    return Scaffold(

      body: Center(
        // Center is a layout widget. It takes a single child and positions it
        // in the middle of the parent.
        child: Column(
          // Column is also a layout widget. It takes a list of children and
          // arranges them vertically. By default, it sizes itself to fit its
          // children horizontally, and tries to be as tall as its parent.
          //
          // Invoke "debug painting" (press "p" in the console, choose the
          // "Toggle Debug Paint" action from the Flutter Inspector in Android
          // Studio, or the "Toggle Debug Paint" command in Visual Studio Code)
          // to see the wireframe for each widget.
          //
          // Column has various properties to control how it sizes itself and
          // how it positions its children. Here we use mainAxisAlignment to
          // center the children vertically; the main axis here is the vertical
          // axis because Columns are vertical (the cross axis would be
          // horizontal).
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            new Hero(
              tag: 'hero',

              child: Padding(

                padding: EdgeInsets.fromLTRB(0.0, 90.0, 0.0, 0.0),
                child: CircleAvatar(
                  backgroundColor: Colors.deepPurple.withOpacity(0.3),

                  radius: _iconAnimation.value *130,

                  child:  Image.asset('assets/images/LogoNotOneLess.png'),

                ),
              ),
            ),
            new Padding(padding: const EdgeInsets.only(top: 200.0),

            ),
            CircularProgressIndicator(),
            Text(
              '#NiUnaMenos',style: TextStyle(color: Colors.deepPurple[400],fontSize: 20),
            ),

          ],
        ),


      ),
      // This trailing comma makes auto-formatting nicer for build methods.
    );
  }



}
