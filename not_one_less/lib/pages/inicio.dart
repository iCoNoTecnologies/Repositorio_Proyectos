import 'dart:convert';
import 'package:permission_handler/permission_handler.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:imei_plugin/imei_plugin.dart';
import 'dart:async';
import 'package:not_one_less/pages/CheckLogin.dart';
import 'package:curved_navigation_bar/curved_navigation_bar.dart';
import 'package:percent_indicator/percent_indicator.dart';
/// This Widget is the main application widget.
class PageInicio extends StatelessWidget {
  static const String _title = 'Flutter Code Sample';

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: _title,
      theme: ThemeData(

        primarySwatch: Colors.purple,
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
  String linkavatar="";
  String UserNickname="No hay internet";
  Timer _timer;
  double _start = 5000;
double miliseconds=5000;


  @override
  void initState(){

    Tarjeta();


  }

  void startTimer() {
    const oneSec = const Duration(milliseconds: 100);

    _timer = new Timer.periodic(
      oneSec,
          (Timer timer) => setState(
            () {
          if (_start < 1) {
            timer.cancel();
          } else {
            _start = _start - 100;
print(_start);
          }
        },
      ),
    );


  }

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {

    return Scaffold(
        body: Container(
          color: Colors.white,
          child: Center(
            // Center is a layout widget. It takes a single child and positions it
            // in the middle of the parent.
            

            child: Column(
           

              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[

                new Padding(padding: const EdgeInsets.only(top: 25.0),),
          Card(

            child: new Column(

                children: <Widget>[
                  new Row(

                      mainAxisSize:
                      MainAxisSize.min,
                      children: <Widget>[
                        new  CircleAvatar(

                          backgroundColor: Colors.grey.withOpacity(0.3),
                          radius: 35,

                          child: Image.network('${linkavatar}',width: 70,  //
                            height: 70,),

                        ),

                        new Text("     Bienvenido \n ${UserNickname}  ", style: TextStyle(fontSize: 20.0, color: Colors.deepPurple),),
                        new MaterialButton(
                            shape: RoundedRectangleBorder(
                                borderRadius: new BorderRadius.circular(360.0),
                                side: BorderSide(color: Colors.purpleAccent)
                            ),
                            height: 40.0,


                            minWidth: 30,
                            color: Colors.white,
                            textColor: Colors.purple,
                            child: new Icon(Icons.device_unknown),



                            onPressed: () {


                            }

                        ),

                      ]),
                ]),

          ),
                      

                 Divider(),

                new CircularPercentIndicator(
                  radius: 250.0,
                  lineWidth: 20.0,
                  percent: (_start/10000)*2,
                  center:new FlatButton(
                      onPressed: startTimer,
                      padding: EdgeInsets.all(0.0),
                      child: Image.asset('assets/images/feminist_logo.png',width: 210,height: 210,)),
                  progressColor: Colors.purpleAccent[100],
                ),




                Text("Pulsa para iniciar alerta real \n ", style: TextStyle(fontSize: 20.0, color: Colors.deepPurple),),

                new Row(

                    mainAxisSize:
                MainAxisSize.min,
                    children: <Widget>[

                      Text(" en: ", style: TextStyle(fontSize: 25.0, color: Colors.deepPurple),),

                      Text(" ${(_start/1000).toString()}", style: TextStyle(fontSize: 35.0, color: Colors.green),),
                      Text(" segundos", style: TextStyle(fontSize: 25.0, color: Colors.deepPurple),),
                    ]),



              ],
            ),
          ),
        ));
  }

  Future<List> Tarjeta()async {

    String imei ;
    imei= await ImeiPlugin.getImei();
    // refreshKey.currentState?.show(atTop: false);
    //print(NumEmpleado);
    // print(imei.toString());
    //await Future.delayed(Duration(seconds: 2));
    final response = await http.post("https://notoneless.000webhostapp.com/notoneless/SelectUser.php",body: {
      "imei": imei,
    });
    var data =json.decode(response.body);
    //print(data.toString());
    if(data.length!=0){
setState(() {
  linkavatar=data[0]["Foto"];
  UserNickname=data[0]["Nick_Name"];

});

    }else{
      setState(() {
        linkavatar="https://notoneless.000webhostapp.com/notoneless/Logos/womanlogo.png";
      });

    }
    return data;




  }

}

