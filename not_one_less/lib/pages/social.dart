import 'dart:convert';
import 'package:permission_handler/permission_handler.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:imei_plugin/imei_plugin.dart';
import 'dart:async';
import 'package:not_one_less/pages/CheckLogin.dart';
import 'package:curved_navigation_bar/curved_navigation_bar.dart';


/// This Widget is the main application widget.
class Social extends StatelessWidget {
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


  @override
  Widget build(BuildContext context) {
    return  Scaffold(
        body: Container(
            color: Colors.white,
            child: Column(
              children: <Widget>[

                Container(
                  height: 200,
                  constraints: BoxConstraints.expand(height: MediaQuery.of(context).size.height- 158),
                  child: ListView(
                    padding: EdgeInsets.zero,
                    children: <Widget>[
                      Container(
                        margin: EdgeInsets.all(20),
                        height: 200,

                        child: Column(
                          children: <Widget>[
                            Row(
                              children: <Widget>[
                                Container(

                                  child: CircleAvatar(

                                    backgroundColor: Colors.grey.withOpacity(0.3),
                                    radius: 35,

                                    child: Image.network('${linkavatar}',width: 70,  //
                                      height: 70,),),
                                ),
                                Column(
                                  children: <Widget>[
                                    Row(
                                      children: <Widget>[
                                        Container(
                                          margin: EdgeInsets.only(left: 20, right: 20),
                                          child: Column(
                                            children: <Widget>[
                                              Text('129', style: TextStyle(fontWeight: FontWeight.bold),),
                                              Text('posts')
                                            ],
                                          ),
                                        ),
                                        Container(
                                          margin: EdgeInsets.only(right: 20),
                                          child: Column(
                                            children: <Widget>[
                                              Text('129K', style: TextStyle(fontWeight: FontWeight.bold),),
                                              Text('followers')
                                            ],
                                          ),
                                        ),
                                        Container(
                                          margin: EdgeInsets.only(right: 2),
                                          child: Column(
                                            children: <Widget>[
                                              Text('129', style: TextStyle(fontWeight: FontWeight.bold),),
                                              Text('following')
                                            ],
                                          ),
                                        ),
                                      ],
                                    ),
                                    Row(
                                      children: <Widget>[

                                        Container(
                                          margin: EdgeInsets.all(10),
                                          height: 30,
                                          width: 120,
                                          decoration: BoxDecoration(
                                              borderRadius: BorderRadius.all(Radius.circular(5)),
                                              border: Border.all(width: 1, color: Color(0xFFE7E7E7))
                                          ),
                                          child: FlatButton(
                                            child: Text('Editar Perfil'),
                                            onPressed: () {

                                            },
                                          ),
                                        ),
                                      ],
                                    )
                                  ],
                                )
                              ],
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: <Widget>[
                                Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: <Widget>[
                                    Text("carlos"),
                                    Text("I am a profile on instagram"),
                                    InkWell(
                                        child: new Text('my instagram'),

                                    ),
                                  ],
                                ),
                                Container(

                                )
                              ],
                            )
                          ],
                        ),
                        color: Colors.white,
                      ),
                      Divider(),
                      Column(

                        children: <Widget>[
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,),
                          Image.network('${linkavatar}',width: 70,  //
                            height: 70,)
                        ],

                      )
                    ],
                  ),
                )
              ],
            )
        ));
  }

}