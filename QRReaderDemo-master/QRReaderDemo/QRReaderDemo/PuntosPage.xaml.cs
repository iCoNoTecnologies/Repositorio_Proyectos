using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace QRReaderDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PuntosPage : ContentPage
	{
		public PuntosPage ()
		{
			InitializeComponent ();
            mapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(20.5327612, -100.4350794), Distance.FromMiles(1)));

            loadHistorial();

        }

        private async void loadHistorial()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("HTTP://201.144.14.11");

            var postData = new List<KeyValuePair<string, string>>();

            postData.Add(new KeyValuePair<string, string>("user", ""));
            var content = new FormUrlEncodedContent(postData);

            try
            {
                var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/puntos.php", content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    await DisplayAlert("Aviso", "No hay datos para mostrar", "Aceptar");
                    listaPuntos.ItemsSource = null;
                    return;
                }
                else
                {
                    var tr = JsonConvert.DeserializeObject<List<Sitio>>(result);
                    listaPuntos.ItemsSource = null;
                    listaPuntos.SelectedItem = null;
                    listaPuntos.ItemSelected += null;
                    listaPuntos.ItemsSource = tr;
                    listaPuntos.ItemSelected += listaPuntos_ItemSelected;
                    
                    foreach(Sitio s in tr)
                    {
                        double latitud = double.Parse(s.latitud);
                        double longitud = double.Parse(s.longitud);
                        var pin = new Pin()
                        {
                            Position = new Position(latitud, longitud),
                            Label = s.direccion
                        };

                        mapView.Pins.Add(pin);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                return;
            }
        }

        

        private void listaPuntos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //var element = e.SelectedItem as Elemento;
                //string descripcion = "SITIO: " + element.razon + " " + element.direccion + "\n\nOFICIAL: " + element.empleado + " " + element.nombre + "\n\nTURNO: " + element.turno + "        ÁREA: " + element.area + "        UNIDAD: " + element.unidad;
                //await DisplayAlert(element.fecha, descripcion, "Aceptar");
                var sitio = e.SelectedItem as Sitio;
                double latitud = double.Parse(sitio.latitud);
                double longitud = double.Parse(sitio.longitud);
                mapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(latitud, longitud), Distance.FromMeters(5)));
            }
        }
    }
}