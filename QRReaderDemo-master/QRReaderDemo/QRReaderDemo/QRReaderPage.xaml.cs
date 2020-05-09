using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using MySql.Data.MySqlClient;
using System.Net.Http;
using Newtonsoft.Json;

namespace QRReaderDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRReaderPage : ContentPage
    {
        public string resultado { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string empleado { get; set; }
        public string nombre { get; set; }
        public string unidad { get; set; }
        public string turno { get; set; }
        //public string area { get; set; }

        private bool hayTurno;
        private bool hayUnidad;

        public QRReaderPage(string nombre, string user)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            loadUnidades();
            this.nombre = nombre;
            this.empleado = user;
            hayTurno = false;
            hayUnidad = false;
            
            try
            {
                InitializePlugin();
            } catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.ToString(), "Ok");
                return;
            }
        }

        private async void loadUnidades()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("HTTP://http://172.27.100.9");

            var postData = new List<KeyValuePair<string, string>>();

            /*postData.Add(new KeyValuePair<string, string>("user", user));
            postData.Add(new KeyValuePair<string, string>("desde", desde));
            postData.Add(new KeyValuePair<string, string>("hasta", hasta));*/

            var content = new FormUrlEncodedContent(postData);

            try
            {
                var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/unidades.php",content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    //await DisplayAlert("Aviso", "No hay datos para mostrar", "Aceptar");
                    pickerUnidad.ItemsSource = null;
                    //historialLista.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Unidad>>(result);
                    var unidadList = new List<string>();
                    foreach(Unidad u in tr)
                        unidadList.Add(u.unidad);
                    
                    pickerUnidad.ItemsSource = null;
                    pickerUnidad.SelectedItem = null;
                    pickerUnidad.ItemsSource = unidadList;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                return;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void InitializePlugin()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error", "No se cargó el plugin", "OK");
                return;
            }

            if (!CrossGeolocator.Current.IsGeolocationEnabled || !CrossGeolocator.Current.IsGeolocationAvailable)
            {
                await DisplayAlert("Advertencia", "GPS desactivado", "OK");
                return;
            }

            this.oficial.Text = "OFICIAL: " + empleado + " " + nombre;

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

            try
            {
                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 5), 0.5);
            } catch (Exception ex)
            {
                await DisplayAlert("Advertencia", ex.ToString(), "OK");
                await CrossGeolocator.Current.StopListeningAsync();
                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 5), 0.5);
            }


        }



        private async void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                await CrossGeolocator.Current.StopListeningAsync();
                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 5), 0.5);
                return;
            }
            var position = CrossGeolocator.Current.GetPositionAsync();
            this.Posicion.Text = "lat: " + position.Result.Latitude.ToString() + " ";
            latitud = position.Result.Latitude.ToString();
            this.Posicion.Text += "lon: " + position.Result.Longitude.ToString() + " ";
            longitud = position.Result.Longitude.ToString();
            this.Posicion.Text += "time: " + DateTime.Now.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Scanner();
        }

        private async void Scanner()
        {
            var scannerPage = new ZXingScannerPage();

            scannerPage.Title = "Registrar Frecuencia de Paso";
            
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    resultado = result.Text;

                    /*genero consulta para ver si el codigo qr escaneado existe en la base de datos de sitios*/
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://http://172.27.100.9");

                    var postData = new List<KeyValuePair<string, string>>();

                    postData.Add(new KeyValuePair<string, string>("sitio", resultado));
                    
                    var content = new FormUrlEncodedContent(postData);

                    try
                    {
                        var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/sitio.php", content);

                        var respuesta = response.Content.ReadAsStringAsync().Result;

                        if (string.IsNullOrEmpty(respuesta) || respuesta == "null" || respuesta == "[]\r\n\r\n")
                        {
                            await DisplayAlert("Aviso", "Este sitio no está registrado", "Aceptar");
                            return;
                        }
                        else
                        {
                            HttpClient client2 = new HttpClient();
                            client2.BaseAddress = new Uri("HTTP://http://172.27.100.9");

                            var postData2 = new List<KeyValuePair<string, string>>();

                            postData2.Add(new KeyValuePair<string, string>("sitio", resultado));

                            var content2 = new FormUrlEncodedContent(postData2);

                            char [] par = { '\r','\n', ' ' };
                            respuesta = respuesta.Trim(par);
                            char [] sep = {'/'};
                            string[] cadenas = resultado.Split(sep);
                            string[] cadenas2 = respuesta.Split(sep);
                            string idSitio = cadenas[0];
                            string fech = cadenas2[0];
                            string sitio = cadenas2[1];
                            string error = "";
                        /*pone el resultado de la consulta en la etiqueta*/
                        try
                        {
                            var response2 = await client2.PostAsync("Http://201.144.14.11/sidesp/app/sitio2.php", content2);
                            var respuesta2 = response2.Content.ReadAsStringAsync().Result;

                            
                            respuesta2 = respuesta2.Trim(par);
                            char[] sep2 = {'/'};
                            string[] cadenas3 = respuesta2.Split(sep2);
                                string c2 = cadenas3[1];
                                string c1 = cadenas3[0];
                               
                                error=c2;
                                double latit = Convert.ToDouble(c1);
                            double logit = Convert.ToDouble(c2);
                            double Lat = Convert.ToDouble(latitud);
                            double lon = Convert.ToDouble(longitud);
                                
                              //  double Lat =   Convert.ToDouble("20.545247");
                               // double lon = Convert.ToDouble("-100.405120");

                                if (Lat >= latit-0.001000 && Lat <= latit + 0.001000 &&lon <= logit + 0.001000 && lon >= logit - 0.001000  )
                                {


                                    DateTime tiempoActual = DateTime.Now;
                                    DateTime vigencia;
                                    DateTime.TryParse(fech, out vigencia);
                                    double diff = tiempoActual.Subtract(vigencia).TotalDays;
                                    if (diff > 1)
                                    {
                                        this.Resultado2.Text = "Esta fecha esta vencida ";
                                        this.contentResult2.IsVisible = true;               
                                        this.resultado = idSitio;
                                        this.contentResult.IsVisible = false;
                                    }
                                    else
                                    {
                                        this.contentResult2.IsVisible = false;
                                        this.Resultado.Text = "vigencia: " + fech + "\n" + "Sitio: " + sitio;
                                        this.contentResult.IsVisible = true;
                                        this.resultado = idSitio;
                                    }

                                }
                                else
                                {
                                    this.Resultado2.Text = "No estas en la zona: "+sitio;
                                    this.contentResult2.IsVisible = true;
                                    this.resultado = idSitio;
                                    this.contentResult.IsVisible = false;

                                }
                            }
                            catch (Exception ex)
                            {
                                await DisplayAlert("ERROR", "algo fallo:"+ex, "Aceptar");
                                return;

                            }
                        
                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                        return;
                    }
                    /*termina consulta*/
                    
                    
                });
            };

            await Navigation.PushAsync(scannerPage);
        }

        private async void btn1_click(object sender, EventArgs e)
        {
            bool guarda = false;

            try // se lee la ultima frecuencia realizada para el sitio actual
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("sitio", resultado));
                var content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("Http://201.144.14.11");
                var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/ultimaFrecuencia.php", content);
                string ultimaFrecuencia = response.Content.ReadAsStringAsync().Result;
                //await DisplayAlert("Alerta", ultimaFrecuencia, "Aceptar");
                
                if(ultimaFrecuencia == null || ultimaFrecuencia == "")
                {
                    guarda = true;
                }
                else
                {
                    DateTime tiempoActual = DateTime.Now;
                    DateTime ultima;
                    DateTime.TryParse(ultimaFrecuencia, out ultima);
                    double diff = tiempoActual.Subtract(ultima).TotalHours;
                    if (diff > 1)
                        guarda = true;
                    else
                        guarda = false;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Ok");
                return;
            }


            if (guarda)
            {
                try
                {
                    var postData = new List<KeyValuePair<string, string>>();

                    postData.Add(new KeyValuePair<string, string>("latitud", latitud));
                    postData.Add(new KeyValuePair<string, string>("longitud", longitud));
                    postData.Add(new KeyValuePair<string, string>("empleado", empleado));
                    postData.Add(new KeyValuePair<string, string>("dato", resultado));
                    postData.Add(new KeyValuePair<string, string>("unidad", unidad));
                    postData.Add(new KeyValuePair<string, string>("turno", turno));

                    var content = new FormUrlEncodedContent(postData);

                    HttpClient client = new HttpClient();

                    client.BaseAddress = new Uri("Http://201.144.14.11");

                    var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/inserta.php", content);
                    Resultado.Text = response.Content.ReadAsStringAsync().Result;
                    contentResult.IsVisible = false;
                    await DisplayAlert("OK", "Dato enviado de manera correcta", "Aceptar");

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.ToString(), "Ok");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Este sitio fue visitado hace menos de una hora", "Aceptar");
            }
        }

        /*private void pickerArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            this.area = selectedItem.ToString();
        }*/

        private void pickerUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            this.unidad = selectedItem.ToString();
            this.hayUnidad = true;
            habilitaFrecuencia();
        }

        private void pickerTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            this.turno = selectedItem.ToString();
            this.hayTurno = true;
            habilitaFrecuencia();
        }

        private void habilitaFrecuencia()
        {
            if(hayTurno && hayUnidad)
            {
                this.ButtonFrecuencia.IsEnabled = true;
            }
            else
            {
                this.ButtonFrecuencia.IsEnabled = false;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            HistorialPage historialPage = new HistorialPage(this.nombre, this.empleado);
            await Navigation.PushAsync(historialPage);            
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            PuntosPage puntosPage = new PuntosPage();
            await Navigation.PushAsync(puntosPage);
        }
    }
}
