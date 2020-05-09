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
using System.IO;
using System.Net;
using SignaturePad.Forms;
using System.Collections.ObjectModel;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace QRReaderDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRReaderPage : ContentPage
    {
        ObservableCollection<MediaModel> Photos = new ObservableCollection<MediaModel>();

        private int[] anexo1;
        private int[] anexo2;
        private int[] anexo3;
        private int[] anexo4;

        private bool completo1;
        private bool completo2;
        private bool completo3;
        private bool completo4;

        private string sexo;
        private string nombre;
        private string numero;
        private string evaluador;
        private string ultimaEvaluacion;
        private int asistencia;

        private string grupo;
        private string turno;
        private string tablet;
        private string bodycam;
        private string kit;
        private string unidad;

        private bool hayEmpleado;
        private bool hayFirma;
        private bool hayFoto;
        private bool hayGrupo;
        private bool hayTurno;
        private bool hayTablet;
        private bool hayBodycam;
        private bool hayKit;
        private bool hayUnidad;

        PageFirma pageFirma;

        public QRReaderPage(string nombre, string user)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            this.nombre = nombre;
            this.numero = user;
            this.evaluador = user;
            this.asistencia = 1;
            this.hayEmpleado = false;
            this.hayFirma = false;
            this.hayFoto = false;
            this.hayGrupo = false;
            this.hayTurno = false;
            this.hayTablet = false;
            this.hayBodycam = false;
            this.hayKit = false;
            this.hayUnidad = false;

            pageFirma = new PageFirma(hayFirma);
            initializeForm();
            loadGrupos();
            loadTablets();
            loadBodycam();
            loadKit();
            loadUnidades();
        }

        private void initializeForm()
        {
            anexo1 = new int[6];
            anexo2 = new int[13];
            anexo3 = new int[9];
            anexo4 = new int[10];

            initArray(anexo1);
            initArray(anexo2);
            initArray(anexo3);
            initArray(anexo4);

            completo1 = completo2 = completo3 = completo4 = false;

            Firma.IsVisible = false;
            Guardar.IsVisible = false;
            ButtonFirma.IsVisible = false;
            ButtonFoto.IsVisible = false;

            Anexo3.BackgroundColor = Color.FromHex("102f6f");
            Anexo1.BackgroundColor = Color.FromHex("102f6f");
            Anexo4.BackgroundColor = Color.FromHex("102f6f");
            Anexo6.BackgroundColor = Color.FromHex("102f6f");

            Anexo3.IsEnabled = false;
            Anexo1.IsEnabled = false;
            Anexo4.IsEnabled = false;
            Anexo6.IsEnabled = false;
            Inasistencia.IsEnabled = false;
            Comision.IsEnabled = false;
            Incapacidad.IsEnabled = false;

            nombreEmpleado.Text = "Nombre del elemento a evaluar";
            numeroEmpleado.Text = "";
            this.asistencia = 1;
            Firma.Clear();

            pickerGrupo.SelectedItem = -1;
            pickerTurno.SelectedItem = -1;
            pickerTablet.SelectedItem = -1;
            pickerBodycam.SelectedItem = -1;
            pickerkitPR.SelectedItem = -1;
            pickerUnidad.SelectedItem = -1;

            pageFirma.setFirma(false);
            hayFoto = false;
            this.hayEmpleado = false;
            this.hayGrupo = false;
            this.hayTurno = false;
            this.hayTablet = false;
            this.hayBodycam = false;
            this.hayKit = false;
            this.hayUnidad = false;
        }

        private void initializeForm(bool cambio)
        {
            anexo1 = new int[6];
            anexo2 = new int[13];
            anexo3 = new int[9];
            anexo4 = new int[10];

            initArray(anexo1);
            initArray(anexo2);
            initArray(anexo3);
            initArray(anexo4);

            completo1 = completo2 = completo3 = completo4 = false;

            Firma.IsVisible = false;
            Guardar.IsVisible = false;
            ButtonFirma.IsVisible = false;
            ButtonFoto.IsVisible = false;

            Anexo3.BackgroundColor = Color.FromHex("102f6f");
            Anexo1.BackgroundColor = Color.FromHex("102f6f");
            Anexo4.BackgroundColor = Color.FromHex("102f6f");
            Anexo6.BackgroundColor = Color.FromHex("102f6f");

            Anexo3.IsEnabled = false;
            Anexo1.IsEnabled = false;
            Anexo4.IsEnabled = false;
            Anexo6.IsEnabled = false;
            Inasistencia.IsEnabled = false;
            Comision.IsEnabled = false;
            Incapacidad.IsEnabled = false;
            this.asistencia = 1;
            //nombreEmpleado.Text = "Nombre de empleado";
            //numeroEmpleado.Text = "";
            Firma.Clear();

            pickerGrupo.SelectedItem = -1;
            pickerTurno.SelectedItem = -1;
            pickerTablet.SelectedItem = -1;
            pickerBodycam.SelectedItem = -1;
            pickerkitPR.SelectedItem = -1;
            pickerUnidad.SelectedItem = -1;

            pageFirma.setFirma(false);
            hayFoto = false;
            this.hayEmpleado = false;
            this.hayGrupo = false;
            this.hayTurno = false;
            this.hayTablet = false;
            this.hayBodycam = false;
            this.hayKit = false;
            this.hayUnidad = false;
        }

        private void initArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = 0;
        }

        private void fillArray(int[] array, char e)
        {
            if (e == 'f') //falta/inasistencia
                for (int i = 0; i < array.Length; i++)
                    array[i] = 20;
            else if (e == 'c') //comision
                for (int i = 0; i < array.Length; i++)
                    array[i] = 30;
            else if (e == 'i') //incapacidad
                for (int i = 0; i < array.Length; i++)
                    array[i] = 40;
        }

        /* Corresponde a Anexo 1 */
        private void Anexo3_Clicked(object sender, EventArgs e)
        {
            PageAnexo3 page3 = new PageAnexo3(anexo1);
            Navigation.PushAsync(page3);
            anexo1 = page3.getAnexo();
            if (!anexo1.Contains(0))
            {
                Anexo3.BackgroundColor = Color.LightGreen;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.nombreEvaluador.Text = "Evaluador: " + nombre;
            if (!anexo1.Contains(0))
            {
                Anexo3.BackgroundColor = Color.LightGreen;
                completo1 = true;
            }
            if (anexo2.Contains(0))
            {
                if (sexo == "Masculino")
                {
                    if(anexo2[5] != 0 && anexo2[6] != 0 && anexo2[7] != 0)
                    {
                        Anexo1.BackgroundColor = Color.LightGreen;
                        completo2 = true;
                    }
                }
                else if (sexo == "Femenino")
                {
                    if (anexo2[8] != 0 && anexo2[9] != 0)
                    {
                        Anexo1.BackgroundColor = Color.LightGreen;
                        completo2 = true;
                    }
                }                
            }
            if (!anexo3.Contains(0))
            {
                Anexo4.BackgroundColor = Color.LightGreen;
                completo3 = true;
            }
            if (!anexo4.Contains(0))
            {
                Anexo6.BackgroundColor = Color.LightGreen;
                completo4 = true;
            }

            if (completo1 && completo2 && completo3)
            {
                //Firma.IsVisible = true;
                //Guardar.IsVisible = true;
                ButtonFirma.IsVisible = true;
                ButtonFoto.IsVisible = true;
            }

            if (pageFirma.getFirma())
            {
                ButtonFirma.BackgroundColor = Color.LightGreen;
            } else
            {
                ButtonFirma.BackgroundColor = Color.FromHex("#102f6f");
            }

            if (hayFoto)
            {
                ButtonFoto.BackgroundColor = Color.LightGreen;
            }
            else
            {
                ButtonFoto.BackgroundColor = Color.FromHex("#102f6f");
            }

            if (ButtonFirma.BackgroundColor == Color.LightGreen && ButtonFoto.BackgroundColor == Color.LightGreen)
                Guardar.IsVisible = true;
            else
                Guardar.IsVisible = false;
                
        }
        /* Corresponde a Anexo 2 */
        private void Anexo1_Clicked(object sender, EventArgs e)
        {
            PageAnexo1 page1 = new PageAnexo1(anexo2, sexo);
            Navigation.PushAsync(page1);
            anexo2 = page1.getAnexo();
        }

        /* Corresponde a Anexo 3 */
        private void Anexo4_Clicked(object sender, EventArgs e)
        {
            PageAnexo4 page4 = new PageAnexo4(anexo3);
            Navigation.PushAsync(page4);
            anexo3 = page4.getAnexo();
        }

        /* Corresponde a Anexo 4 */
        private void Anexo6_Clicked(object sender, EventArgs e)
        {
            PageAnexo6 page6 = new PageAnexo6(anexo4);
            Navigation.PushAsync(page6);
            anexo4 = page6.getAnexo();
        }

        private void ButtonFirma_Clicked(object sender, EventArgs e)
        {
            //PageFirma page = new PageFirma(hayFirma);
            Navigation.PushAsync(pageFirma);
        }

        private async void ButtonFoto_Clicked(object sender, EventArgs e)
        {
            this.hayFoto = false;
            ButtonFoto.BackgroundColor = Color.FromHex("#102f6f");

            var isInitialize = await Plugin.Media.CrossMedia.Current.Initialize();
            if(!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported || !Plugin.Media.CrossMedia.IsSupported || !isInitialize)
            {
                await DisplayAlert("Error", "La cámara no se encuentra disponible", "Acpetar");
                return;
            }

            var newPhotoID = Guid.NewGuid();

            using (var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreVideoOptions()
            {
                Name = newPhotoID.ToString(),
                SaveToAlbum = true,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                Directory = "Evaluaciones"
            }))
            {
                if (string.IsNullOrWhiteSpace(photo?.Path))
                {
                    return;
                }

                var newPhotoMedia = new MediaModel()
                {
                    MediaID = newPhotoID,
                    Path = photo.Path,
                    LocalDateTime = DateTime.Now

                };

                //Photos.Add(newPhotoMedia);
                
                if (newPhotoMedia != null)
                {
                    this.hayFoto = true;
                    ButtonFoto.BackgroundColor = Color.LightGreen;
                }
                else
                {
                    this.hayFoto = false;
                    ButtonFoto.BackgroundColor = Color.FromHex("#102f6f");
                }


                photo.Dispose();
            }


        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            /*FIRMA: no implementado*/
            /*Stream firma = await Firma.GetImageStreamAsync(SignatureImageFormat.Png);
            StreamReader sR = new StreamReader(firma);
            string firmaString = sR.ReadToEnd();*/

            /*IMEI*/
            //string imei = Plugin.DeviceInfo.CrossDeviceInfo.Current.Id;
            //Verify Permission
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Phone);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Phone))
                    status = results[Permission.Phone];
            }
            string imei = DependencyService.Get<IServiceImei>().GetImei();

            /*Se crea variable post para enviar al WS*/
            var postData = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < anexo1.Length; i++)
            {
                postData.Add(new KeyValuePair<string, string>("anexo1_" + (i + 1), anexo1[i].ToString()));
            }
            for (int i = 0; i < anexo2.Length; i++)
            {
                postData.Add(new KeyValuePair<string, string>("anexo2_" + (i + 1), anexo2[i].ToString()));
            }
            for (int i = 0; i < anexo3.Length; i++)
            {
                postData.Add(new KeyValuePair<string, string>("anexo3_" + (i + 1), anexo3[i].ToString()));
            }
            for (int i = 0; i < anexo4.Length; i++)
            {
                postData.Add(new KeyValuePair<string, string>("anexo4_" + (i + 1), anexo4[i].ToString()));
            }
            //postData.Add(new KeyValuePair<string, string>("firma", firmaString));
            postData.Add(new KeyValuePair<string, string>("evaluado", numero));
            postData.Add(new KeyValuePair<string, string>("evaluador", evaluador));
            //postData.Add(new KeyValuePair<string, string>("asistencia", asistencia.ToString()));

            
            postData.Add(new KeyValuePair<string, string>("grupo", grupo));
            postData.Add(new KeyValuePair<string, string>("turno", turno));
            postData.Add(new KeyValuePair<string, string>("tablet", tablet));
            postData.Add(new KeyValuePair<string, string>("bodycam", bodycam));
            postData.Add(new KeyValuePair<string, string>("unidad", unidad));
            postData.Add(new KeyValuePair<string, string>("kit", kit));

            postData.Add(new KeyValuePair<string, string>("imei", imei));

            var content = new FormUrlEncodedContent(postData);

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("HTTP://201.144.14.11");
                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/save.php", content);
                var respuesta = response.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(respuesta) || respuesta == "null" || respuesta == "[]\r\n\r\n")
                {
                    await DisplayAlert("Aviso", "mensaje", "Aceptar");
                    return;
                }
                else
                {
                    await DisplayAlert("Mensaje", respuesta, "Aceptar");
                    initializeForm();
                    return;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://172.27.100.7");
                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/save.php", content);
                    var respuesta = response.Content.ReadAsStringAsync().Result;
                    if (string.IsNullOrEmpty(respuesta) || respuesta == "null" || respuesta == "[]\r\n\r\n")
                    {
                        await DisplayAlert("Aviso", "mensaje", "Aceptar");
                        return;
                    }
                    else
                    {
                        await DisplayAlert("Mensaje", respuesta, "Aceptar");
                        initializeForm();
                        return;
                    }
                }
                catch (Exception ex2)
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet " + ex2.ToString(), "Aceptar");
                    return;
                }
                
            }
        }

        private async void numeroEmpleado_Unfocused(object sender, FocusEventArgs e)
        {
            if((numeroEmpleado.Text.Trim() != null && numeroEmpleado.Text != null) || (numeroEmpleado.Text.Trim() != "" && numeroEmpleado.Text != ""))
            {
                numero = numeroEmpleado.Text;
                bool acepta = await DisplayAlert("Advertencia", "¿Desea cambiar de oficial? Se borrarán todos los datos", "Continuar", "Cancelar");
                if (acepta)
                {
                    initializeForm(true);
                    hayEmpleado = true;
                    try
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("HTTP://201.144.14.11");
                        var postData = new List<KeyValuePair<string, string>>();
                        postData.Add(new KeyValuePair<string, string>("user", numeroEmpleado.Text));
                        var content = new FormUrlEncodedContent(postData);

                        var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/evaluado.php", content);
                        var result = response.Content.ReadAsStringAsync().Result;

                        if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                        {
                            await DisplayAlert("Aviso", "El número de empleado no existe", "Aceptar");
                            initializeForm();
                            return;
                        }
                        else
                        {
                            var dato = JsonConvert.DeserializeObject<List<Elemento>>(result);
                            nombreEmpleado.Text = dato[0].Nombre + " " + dato[0].Paterno + " " + dato[0].Materno ;
                            sexo = dato[0].Sexo;
                            if(dato.Count > 1)
                            {
                                ultimaEvaluacion = dato[1].fecha;
                                await DisplayAlert("Mensaje", "La última evaluación del oficial fue " + ultimaEvaluacion, "Aceptar");
                            }
                            else
                                await DisplayAlert("Mensaje", "El elemento no ha sido evaluado", "Aceptar");

                            /*Anexo3.IsEnabled = true;
                            Anexo1.IsEnabled = true;
                            Anexo4.IsEnabled = true;
                            Anexo6.IsEnabled = true;
                            Inasistencia.IsEnabled = true;
                            Comision.IsEnabled = true;
                            Incapacidad.IsEnabled = true;*/
                            //habilitaEvaluacion();
                        }
                    }
                    catch (Exception ex)
                    {
                        if(numero == "")
                        {
                            await DisplayAlert("Advertencia", "El número de empleado no puede ser vacío", "Aceptar");
                            initializeForm();
                        }
                        else
                        {                            
                            try//intenta por red local
                            {
                                HttpClient client = new HttpClient();
                                client.BaseAddress = new Uri("HTTP://172.27.100.7");
                                var postData = new List<KeyValuePair<string, string>>();
                                postData.Add(new KeyValuePair<string, string>("user", numeroEmpleado.Text));
                                var content = new FormUrlEncodedContent(postData);

                                var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/evaluado.php", content);
                                var result = response.Content.ReadAsStringAsync().Result;

                                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                                {
                                    await DisplayAlert("Aviso", "El número de empleado no existe", "Aceptar");
                                    initializeForm();
                                    return;
                                }
                                else
                                {
                                    var dato = JsonConvert.DeserializeObject<List<Elemento>>(result);
                                    nombreEmpleado.Text = dato[0].Nombre + " " + dato[0].Paterno + " " + dato[0].Materno;
                                    sexo = dato[0].Sexo;
                                    if (dato.Count > 1)
                                    {
                                        ultimaEvaluacion = dato[1].fecha;
                                        await DisplayAlert("Mensaje", "La última evaluación del oficial fue " + ultimaEvaluacion, "Aceptar");
                                    }
                                    else
                                        await DisplayAlert("Mensaje", "El elemento no ha sido evaluado", "Aceptar");

                                    /*Anexo3.IsEnabled = true;
                                    Anexo1.IsEnabled = true;
                                    Anexo4.IsEnabled = true;
                                    Anexo6.IsEnabled = true;
                                    Inasistencia.IsEnabled = true;
                                    Comision.IsEnabled = true;
                                    Incapacidad.IsEnabled = true;*/
                                    //habilitaEvaluacion();
                                }
                            }
                            catch(Exception ex2)
                            {
                                await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet" + ex2.Message, "Aceptar");
                                return;
                            }
                        }
                        
                    }
                }
                else
                {
                    numeroEmpleado.Text = numero;
                }              
            }
            else
            {
                hayEmpleado = false;
            }
        }

        private void habilitaEvaluacion()
        {
            if(hayEmpleado && hayGrupo && hayTurno && hayTablet && hayBodycam && hayKit && hayUnidad)
            {
                Anexo3.IsEnabled = true;
                Anexo1.IsEnabled = true;
                Anexo4.IsEnabled = true;
                Anexo6.IsEnabled = true;
                Inasistencia.IsEnabled = true;
                Comision.IsEnabled = true;
                Incapacidad.IsEnabled = true;
            }
        }

        private async Task Salir_Clicked(object sender, EventArgs e)
        {
            bool salir = await DisplayAlert("Cerrar sesión", "¿Desea cerrar la sesión activa?", "Aceptar", "Cancelar");
            if(salir)
                await Navigation.PopAsync(true);
        }

        private async void loadGrupos()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("HTTP://201.144.14.11");
                var postData = new List<KeyValuePair<string, string>>();
                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/grupos.php", content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    pickerGrupo.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Grupos>>(result);
                    var gruposList = new List<string>();
                    foreach (Grupos g in tr)
                        gruposList.Add(g.Nombre);

                    pickerGrupo.ItemsSource = null;
                    pickerGrupo.SelectedItem = null;
                    pickerGrupo.ItemsSource = gruposList;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://172.27.100.7");
                    var postData = new List<KeyValuePair<string, string>>();
                    var content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/grupos.php", content);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                    {
                        pickerGrupo.ItemsSource = null;
                        return;
                    }
                    else
                    {
                        var tr = JsonConvert.DeserializeObject<List<Grupos>>(result);
                        var gruposList = new List<string>();
                        foreach (Grupos g in tr)
                            gruposList.Add(g.Nombre);

                        pickerGrupo.ItemsSource = null;
                        pickerGrupo.SelectedItem = null;
                        pickerGrupo.ItemsSource = gruposList;
                    }

                }
                catch(Exception ex2)
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                    return;
                }                
            }
        }

        

        private async void Inasistencia_Clicked(object sender, EventArgs e)
        {
            bool aceptar = await DisplayAlert("Inasistencia", "Confirmar falta del elemento", "Confirmar", "Cancelar");
            if (aceptar)
            {
                fillArray(anexo1, 'f');
                fillArray(anexo2, 'f');
                fillArray(anexo3, 'f');
                fillArray(anexo4, 'f');
                this.asistencia = 0;
                this.Guardar_Clicked(sender, e);
            }

        }

        private async void Comision_Clicked(object sender, EventArgs e)
        {
            bool aceptar = await DisplayAlert("Comisión", "Comfirmar comisión del elemento", "Confirmar", "Cancelar");
            if (aceptar)
            {
                fillArray(anexo1, 'c');
                fillArray(anexo2, 'c');
                fillArray(anexo3, 'c');
                fillArray(anexo4, 'c');
                this.Guardar_Clicked(sender, e);
            }
        }

        private async void Incapacidad_Clicked(object sender, EventArgs e)
        {
            bool aceptar = await DisplayAlert("Incapacidad", "Comfirmar incapacidad del elemento", "Confirmar", "Cancelar");
            if (aceptar)
            {
                fillArray(anexo1, 'i');
                fillArray(anexo2, 'i');
                fillArray(anexo3, 'i');
                fillArray(anexo4, 'i');
                this.Guardar_Clicked(sender, e);
            }
        }

        private async void loadTablets()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("HTTP://201.144.14.11");
                var postData = new List<KeyValuePair<string, string>>();
                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/tablets.php", content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    pickerTablet.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Tablets>>(result);
                    var tabletsList = new List<string>();
                    foreach (Tablets t in tr)
                        tabletsList.Add(t.Descripcion);

                    pickerTablet.ItemsSource = null;
                    pickerTablet.SelectedItem = null;
                    pickerTablet.ItemsSource = tabletsList;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://172.27.100.7");
                    var postData = new List<KeyValuePair<string, string>>();
                    var content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/tablets.php", content);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                    {
                        pickerTablet.ItemsSource = null;
                        return;
                    }
                    else
                    {
                        var tr = JsonConvert.DeserializeObject<List<Tablets>>(result);
                        var tabletsList = new List<string>();
                        foreach (Tablets t in tr)
                            tabletsList.Add(t.Descripcion);

                        pickerTablet.ItemsSource = null;
                        pickerTablet.SelectedItem = null;
                        pickerTablet.ItemsSource = tabletsList;
                    }

                }
                catch (Exception ex2)
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                    return;
                }
            }
        }

        private async void loadBodycam()
        {
            //this.pickerBodycam.Items.Add("N/A");
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("HTTP://201.144.14.11");
                var postData = new List<KeyValuePair<string, string>>();
                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/bodycam.php", content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    pickerBodycam.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Bodycam>>(result);
                    var bodycamList = new List<string>();
                    foreach (Bodycam b in tr)
                        bodycamList.Add(b.Descripcion);

                    pickerBodycam.ItemsSource = null;
                    pickerBodycam.SelectedItem = null;
                    pickerBodycam.ItemsSource = bodycamList;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://172.27.100.7");
                    var postData = new List<KeyValuePair<string, string>>();
                    var content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/bodycam.php", content);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                    {
                        pickerBodycam.ItemsSource = null;
                        return;
                    }
                    else
                    {
                        var tr = JsonConvert.DeserializeObject<List<Bodycam>>(result);
                        var bodycamList = new List<string>();
                        foreach (Bodycam b in tr)
                            bodycamList.Add(b.Descripcion);

                        pickerBodycam.ItemsSource = null;
                        pickerBodycam.SelectedItem = null;
                        pickerBodycam.ItemsSource = bodycamList;
                    }

                }
                catch (Exception ex2)
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                    return;
                }
            }
        }

        private async void loadKit()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("HTTP://201.144.14.11");
                var postData = new List<KeyValuePair<string, string>>();
                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/kits.php", content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    pickerkitPR.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Kit>>(result);
                    var kitList = new List<string>();
                    foreach (Kit k in tr)
                        kitList.Add(k.Descripcion);

                    pickerkitPR.ItemsSource = null;
                    pickerkitPR.SelectedItem = null;
                    pickerkitPR.ItemsSource = kitList;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://172.27.100.7");
                    var postData = new List<KeyValuePair<string, string>>();
                    var content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/kits.php", content);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                    {
                        pickerkitPR.ItemsSource = null;
                        return;
                    }
                    else
                    {
                        var tr = JsonConvert.DeserializeObject<List<Kit>>(result);
                        var kitList = new List<string>();
                        foreach (Kit k in tr)
                            kitList.Add(k.Descripcion);

                        pickerkitPR.ItemsSource = null;
                        pickerkitPR.SelectedItem = null;
                        pickerkitPR.ItemsSource = kitList;
                    }

                }
                catch (Exception ex2)
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                    return;
                }
            }
        }

        private async void loadUnidades()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("HTTP://201.144.14.11");
                var postData = new List<KeyValuePair<string, string>>();
                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/unidades.php", content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    pickerUnidad.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Unidad>>(result);
                    var unidadList = new List<string>();
                    foreach (Unidad u in tr)
                        unidadList.Add(u.Descripcion);

                    pickerUnidad.ItemsSource = null;
                    pickerUnidad.SelectedItem = null;
                    pickerUnidad.ItemsSource = unidadList;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("HTTP://172.27.100.7");
                    var postData = new List<KeyValuePair<string, string>>();
                    var content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/unidades.php", content);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                    {
                        pickerUnidad.ItemsSource = null;
                        return;
                    }
                    else
                    {
                        var tr = JsonConvert.DeserializeObject<List<Unidad>>(result);
                        var unidadList = new List<string>();
                        foreach (Unidad u in tr)
                            unidadList.Add(u.Descripcion);

                        pickerUnidad.ItemsSource = null;
                        pickerUnidad.SelectedItem = null;
                        pickerUnidad.ItemsSource = unidadList;
                    }

                }
                catch (Exception ex2)
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                    return;
                }
            }
        }

        private void pickerGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerGrupo.SelectedIndex != -1)
            {
                this.grupo = pickerGrupo.SelectedItem.ToString();
                this.hayGrupo = true;
                habilitaEvaluacion();
            }
            else
            {
                this.grupo = "";
                this.hayGrupo = false;
            }                
        }

        private void pickerTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerTurno.SelectedIndex != -1)
            {
                this.turno = pickerTurno.SelectedItem.ToString();
                this.hayTurno = true;
                habilitaEvaluacion();
            }
            else
            {
                this.turno = "";
                this.hayTurno = false;
            }                
        }

        private void pickerTablet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerTablet.SelectedIndex != -1)
            {
                this.tablet = pickerTablet.SelectedItem.ToString();
                this.hayTablet = true;
                habilitaEvaluacion();
            }
            else
            {
                this.tablet = "";
                this.hayTablet = false;
            }
                
        }

        private void pickerBodycam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerBodycam.SelectedIndex != -1)
            {
                this.bodycam = pickerBodycam.SelectedItem.ToString();
                this.hayBodycam = true;
                habilitaEvaluacion();
            }
            else
            {
                this.bodycam = "";
                this.hayBodycam = false;
            }                
        }

        private void pickerkitPR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerkitPR.SelectedIndex != -1)
            {
                this.kit = pickerkitPR.SelectedItem.ToString();
                this.hayKit = true;
                habilitaEvaluacion();
            }
            else
            {
                this.kit = "";
                this.hayKit = false;
            }
        }

        private void pickerUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerUnidad.SelectedIndex != -1)
            {
                this.unidad = pickerUnidad.SelectedItem.ToString();
                this.hayUnidad = true;
                habilitaEvaluacion();
            }
            else
            {
                this.unidad = "";
                this.hayUnidad = false;
            }
        }

        private void pickerRadio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pickerArma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
