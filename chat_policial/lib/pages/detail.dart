import 'dart:async';
import 'package:chat_policial/main.dart';
import 'package:flutter_tts/flutter_tts.dart';
import 'package:flutter/material.dart';
import 'package:chat_policial/pages/listarUsuarios.dart';
import './editdata.dart';
import 'package:http/http.dart' as http;
import 'package:dio/dio.dart';
import 'package:percent_indicator/percent_indicator.dart';
import 'package:path_provider/path_provider.dart';
import 'package:open_file/open_file.dart';
bool p2 =true;
bool completado=false;
class Detail extends StatefulWidget {
  List list;
  int index;
  Detail({this.index,this.list});
  @override
  _DetailState createState() => new _DetailState();
}

class _DetailState extends State<Detail> {


  bool downloading = false;
  var progressString = "";
double porcentaje=0.0;
  Future paso2()async{
    // flutterTts.stop();
    print(await flutterTts.getLanguages);
    await flutterTts.speak("muy bien, preciona el boton verde para iniciar la descarga de ${widget.list[widget.index]['Nombre_App']} ");
    return p2=false;
  }
  void deleteData(){
    var url="https://escuelitavergas.000webhostapp.com/my_store/deleteData.php";
    http.post(url, body: {
      'id': widget.list[widget.index]['id']
    });
  }
  Future<void> downloadFile() async {
    String imgUrl = "http://201.144.14.11/AppsMovil/${widget.list[widget.index]['Nombre_APK']}";
    Dio dio = Dio();

    try {
      var dir = await getExternalStorageDirectory();

      await dio.download(imgUrl, "${dir.path}/sdcard/${widget.list[widget.index]['Nombre_APK']}",
          onReceiveProgress: (rec, total) {
            print("Rec: $rec , Total: $total");

            setState(() {
              downloading = true;
              progressString = ((rec / total) * 100).toStringAsFixed(0);
              porcentaje=double.parse(progressString)/100;
            });
          });
    } catch (e) {
      print(e);
    }

    setState(() {
      downloading = false;
      if(progressString=="100"){
        completado=true;
      }else{
        completado=false;
      }
      progressString="100";
      porcentaje=double.parse(progressString)/100;
    });
    print("Download completed");
  }
openfile(){
  OpenFile.open("/sdcard/Android/data/com.example.chat_policial/files/sdcard/${widget.list[widget.index]['Nombre_APK']}");
}


  Future<void> confirm(BuildContext context) {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('${widget.list[widget.index]['Nombre_App']}'),
          content: const Text('Primero Descarga la Aplicacion!!'),
          actions: <Widget>[
            FlatButton(
              child: Text('Ok'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    if(p2){
      paso2();
    p2=false;
    }
    return new Scaffold(
      appBar: new AppBar(title: new Text("${widget.list[widget.index]['Nombre_App']}")),
      body: new Container(
        height: 570.0,
        padding: const EdgeInsets.all(20.0),
        child: new Card(
          child: new Center(
            child: new Column(
              children: <Widget>[

                new Padding(padding: const EdgeInsets.only(top: 10.0),),
                new Image.network('http://201.144.14.11/AppsManager/logo/${widget.list[widget.index]['Logo']}',width: 50,
                  height: 50,),
                new Text(widget.list[widget.index]['Nombre_App'], style: new TextStyle(fontSize: 20.0),),
                Divider(),
                new Text("version : ${widget.list[widget.index]['Version_Actual']}", style: new TextStyle(fontSize: 18.0),),
                new Text('progreso:${progressString}%', style: new TextStyle(fontSize: 30.0),),
                new Padding(padding: const EdgeInsets.only(top: 10.0),),
                new CircularPercentIndicator(
                  radius: 200.0,
                  lineWidth: 20.0,
                  percent: porcentaje,
                  center: new Text("${progressString}%", style: new TextStyle(fontSize: 30.0),),
                  progressColor: Colors.green,
                ),

                new Row(
                  mainAxisSize: MainAxisSize.min,
                  children: <Widget>[
                    new RaisedButton(
                      child: new Text("DESCARGAR"),
                      color: Colors.green,
                      shape: new RoundedRectangleBorder(
                          borderRadius: new BorderRadius.circular(30.0)),
                      onPressed: ()=> downloadFile(),
                    ),
                    VerticalDivider(),
                    if(progressString=="100")
                      new RaisedButton(
                        child: new Text("INSTALAR"),
                        color: Colors.blue,
                        shape: new RoundedRectangleBorder(
                            borderRadius: new BorderRadius.circular(30.0)),
                        onPressed: () => openfile(),
                      ),
                    if(progressString!="100")
                      new RaisedButton(
                        child: new Text("INSTALAR"),
                        color: Colors.grey,
                        shape: new RoundedRectangleBorder(
                            borderRadius: new BorderRadius.circular(30.0)),
                        onPressed: () => confirm(context),
                      ),
                  ],
                )
              ],
            ),

          ),
        ),
      ),
    );
  }
}