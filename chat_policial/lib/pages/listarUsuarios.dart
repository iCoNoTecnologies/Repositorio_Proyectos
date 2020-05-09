import 'package:chat_policial/main.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:chat_policial/pages/detail.dart';
import 'package:chat_policial/powerPage.dart';
import 'package:imei_plugin/imei_plugin.dart';
import 'dart:async';
import 'dart:convert';
import 'package:flutter_icons/flutter_icons.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:chat_policial/pages/registroUsuarios.dart';
import 'package:flutter_tts/flutter_tts.dart';
import 'package:webview_flutter/webview_flutter.dart';
var getdata3;
String Tablet;
final FlutterTts flutterTts = FlutterTts();
class Home extends StatefulWidget {

  Home({this.username,this.NumEmpleado});
  final String username;
  final String NumEmpleado;

  bool ayuda=false;
  @override
  _HomeState createState() => new _HomeState();

}


class _HomeState extends State<Home> {
  String Marca;

  String imei ;
  bool ayuda=false;


 Bandera(){


   return ayuda=true;

 }
Future _noRegistrer()async{
  print(await flutterTts.getLanguages);
  await flutterTts.speak("Al parecer tu dispositivo no se encuentra en la base de datos");
}

Future _speak()async{
setState(() {
  Bandera();
});

setState(() {
  llamada();
});
  print(await flutterTts.getLanguages);
  await flutterTts.speak("hola,"+username+", Bienvenido a tu administrador de Aplicaciones móviles, estoy aqui para ayudarte, Para empezar,"
      "asegúrate de que no tengas Aplicaciones abiertas, la manera mas sencilla de hacerlo es apagando y encendiendo tu dispositivo,"
      "pero si prefieres puedes optar por hacer lo siguiente, Desliza con tu dedo la pantalla hacia la hizquierda para ver un ejemplo");
}
  llamada(){
    if(ayuda){

      return Boton_ayuda();
    }else{
      return Color(0xFFFFFFFF) ;
    }
  }
  //************************************************se realiza consulta para obtener la marca de la tablet en base al usuario*****************y el numero de tablet
  List<Offset> _points2 = <Offset>[];
  Future<List> getData2() async {
    imei= await ImeiPlugin.getImei();
   // refreshKey.currentState?.show(atTop: false);
    //print(NumEmpleado);
   // print(imei.toString());
    //await Future.delayed(Duration(seconds: 2));
    final response = await http.post("http://201.144.14.11/AppsManager/getdata.php",body: {
      "imei": imei,
    });
    var data =json.decode(response.body);
    //print(data.toString());
    if(data.length!=0){
      setState(() {
        Marca=data[0]['marca'];
        Tablet=data[0]['id'];
      });

    }else{
      setState(() {
        Marca="LENOVO";
        Tablet="1";
      });

    }
    return data;
  }



//*******************************************************se enlistan las aplicaciones en base a la marca
  List<Offset> _points = <Offset>[];
  Future<List> getData() async {
    //refreshKey.currentState?.show(atTop: false);
    //await Future.delayed(Duration(seconds: 2));
    final response = await http.post("http://201.144.14.11/AppsManager/getdata2.php",body: {
      "marca": Marca,
    });
    return json.decode(response.body);
  }



  var refreshKey = GlobalKey<RefreshIndicatorState>();
  @override
  Widget build(BuildContext context) {

    getData2();

    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: DefaultTabController(
        length: 2,
        child: Scaffold(
          appBar: new AppBar(
            elevation: 4,
            backgroundColor: Color(0xFFFFFFFF),

            title: new Text("Listado de Aplicaciones", style: GoogleFonts.acme(fontSize: 25.0, color: Colors.black54),),
            actions: <Widget>[
              IconButton(
                onPressed: (){},
                icon: Icon(FontAwesome5.file_audio),
                color: Colors.black54 ,
              ),

            ],
            bottom: TabBar(
              indicatorWeight: 2,

              indicatorSize: TabBarIndicatorSize.tab,
              indicatorColor: Colors.black,
              tabs: <Widget>[
                Tab(
                  child: Text(
                    "Apps".toUpperCase(),
                    style: GoogleFonts.indieFlower(fontSize: 25.0, color: Colors.black54),
                  ),
                ),
                Tab(
                  child: Text(
                    "Tutorial".toUpperCase(),
                    style: GoogleFonts.indieFlower(fontSize: 25.0, color: Colors.black54),
                  ),
                ),

              ],
            ),


          ),

          body: TabBarView(
              children: [
                Container(
                  child:new RefreshIndicator(
                    key: refreshKey,

                    child: new FutureBuilder<List>(
                      future: getData(),
                      builder: (context, snapshot) {
                          if (snapshot.hasError)
                            print(snapshot.hasError);
                             return snapshot.hasData
                              ? new ItemList(
                              list: snapshot.data,
                             )
                               : new Center(
                             child: new CircularProgressIndicator(),
                            );


                      },

                    ),
                    onRefresh: getData,

                  ),

                ),

               Tuto(),
              ]

          ),

          floatingActionButton: new FloatingActionButton(


            onPressed: () => _speak(),
            foregroundColor: Colors.black,
            child: new Icon(Icons.record_voice_over),
            backgroundColor: llamada(),
            shape: CircleBorder(side: BorderSide(color: Colors.black, width: 2.0)),
          ),


        ),
      ),
    );
  }

  Tuto(){

  if(Marca=="LENOVO") {

    return Container(child: new WebView(
      initialUrl: 'http://201.144.14.11/AppsManager/Tutorial.html',
      javascriptMode: JavascriptMode.unrestricted,
    ));
  }

  }
}

class ItemList extends StatelessWidget {



  final List list;

  ItemList({this.list});


  @override
  Widget build(BuildContext context) {

    return new ListView.builder(
      itemCount: list == null ? 0 : list.length,
      itemBuilder: (context, i) {
        return new Container(
          padding: const EdgeInsets.all(10.0),
          child: new GestureDetector(
            onTap: () => Navigator.of(context).push(
              new MaterialPageRoute(
                  builder: (BuildContext context) => new Detail(
                    list: list,
                    index: i,
                  )),
            ),
            child: new Card(
              child: new ListTile(
                title: new Text(
                  list[i]['Nombre_App'],
                  style: TextStyle(fontSize: 25.0, color: Colors.indigo),
                ),
                leading:

                  Image.network('http://201.144.14.11/AppsManager/logo/${list[i]['Logo'].toString()}',width: 50,
                    height: 50,),

                subtitle:ComparaVersion(list[i]['Version_Actual'].toString(),i),
              ),
            ),
          ),
        );
      },
    );
  }
}
getdate()async {
//refreshKey.currentState?.show(atTop: false);
 //await Future.delayed(Duration(seconds: 2));
final response = await
http.post("http://201.144.14.11/AppsManager/getdata3.php", body: {
"tablet": Tablet,
});


getdata3 = json.decode(response.body);
getdata3.toString();

//print(getdata3);

return getdata3;
}
//***********************************************************aqui se compara la version de las aplicaciones*******************************************
ComparaVersion(String string, int i){
  //refreshKey.currentState?.show(atTop: false);
 // await Future.delayed(Duration(seconds: 2));
 getdate();

i= i+1;
 String vers= i.toString();

 //print('version:'+getdata3[0][vers]);
if(getdata3[0][vers]==string) {
 // print('es la misma version');
  return  new Text(
    "Aplicacion Actualizada\n version instalada: ${getdata3[0][vers]} \n version mas reciente:${string}",
    style: TextStyle(fontSize: 20.0, color: Colors.greenAccent),
  );
}else{
  //print('la version es distinta');
  return new Text(
    "Aplicacion Desactualizada \n version instalada: ${getdata3[0][vers]} \n version mas reciente: ${string}",
    style: TextStyle(fontSize: 20.0, color: Colors.deepOrangeAccent),
  );
}
}


Boton_ayuda(){
  return Color(0xFF69F0AE) ;
}