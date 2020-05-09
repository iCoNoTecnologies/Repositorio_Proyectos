import 'dart:convert';
import 'package:not_one_less/pages/comunidad.dart';
import 'package:not_one_less/pages/inicio.dart';
import 'package:not_one_less/pages/social.dart';
import 'package:permission_handler/permission_handler.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:imei_plugin/imei_plugin.dart';
import 'dart:async';
import 'package:not_one_less/pages/CheckLogin.dart';
import 'package:curved_navigation_bar/curved_navigation_bar.dart';

/// This Widget is the main application widget.
class PrincipalPage extends StatelessWidget {
  static const String _title = 'Flutter Code Sample';

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: _title,
      theme: ThemeData(

        primarySwatch: Colors.deepPurple,
      ),
      home: MyStatefulWidget(),
    );
  }
}

class MyStatefulWidget extends StatefulWidget {
  MyStatefulWidget({Key key}) : super(key: key);

  @override
  _MyStatefulWidgetState createState() => _MyStatefulWidgetState();
}

class _MyStatefulWidgetState extends State<MyStatefulWidget> {

  int pageIndex = 0;

  final PageInicio paginainicial= PageInicio();
  final Comunidad comuniti= new Comunidad();
  final Social social= new Social();
  Widget showpage =new PageInicio();
Widget _PageChoser(int page){
  switch(page){
    case 0:
      return paginainicial;
      break;
    case 1:
      return comuniti;
      break;
    case 2:
      return social;
      break;
    default:
      return paginainicial;
  }

}
  GlobalKey _bottomNavigationKey = GlobalKey();


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: new AppBar(title: new Text("NotOneLess(#NiUnaMenos)")),
        bottomNavigationBar: CurvedNavigationBar(
          key: _bottomNavigationKey,
          index: pageIndex,
          height: 50.0,
          items: <Widget>[
            Icon(Icons.location_on, size: 30,color: Colors.white,),
            Icon(Icons.public, size: 30,color: Colors.white,),
            Icon(Icons.favorite_border, size: 30,color: Colors.white,),
          ],
          color: Colors.purple[600],
          buttonBackgroundColor: Colors.purpleAccent[400],
          backgroundColor: Colors.white,
          animationCurve: Curves.easeInOut,
          animationDuration: Duration(milliseconds: 600),
          onTap: (int tappedindex) {
            setState(() {
              showpage = _PageChoser(tappedindex);
            });
          },
        ),
        body: showpage,

    );
  }
}