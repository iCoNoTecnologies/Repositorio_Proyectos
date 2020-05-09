using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRReaderDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistorialPage : ContentPage
	{
        string user;
        string desde;
        string hasta;

		public HistorialPage (string nombre, string user)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            this.oficial.Text = "OFICIAL: " + user + " " + nombre;
            this.user = user;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            /*ListaElementos elementos = new ListaElementos();
            historialLista.ItemsSource = elementos._elementos;
            historialLista.ItemSelected += HistorialLista_ItemSelected;*/

            loadHistorial();
        }

        private async void loadHistorial()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("HTTP://http://172.27.100.9");

            desde = pickerDesde.Date.ToString();
            hasta = pickerHasta.Date.ToString();

            var postData = new List<KeyValuePair<string, string>>();            
            
            postData.Add(new KeyValuePair<string, string>("user", user));
            postData.Add(new KeyValuePair<string, string>("desde", desde));
            postData.Add(new KeyValuePair<string, string>("hasta", hasta));

            var content = new FormUrlEncodedContent(postData);

            try
            {
                var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/historial.php", content);
                var result = response.Content.ReadAsStringAsync().Result;
                
                if (string.IsNullOrEmpty(result) || result == "null" || result == "[]\r\n\r\n")
                {
                    await DisplayAlert("Aviso", "No hay datos para mostrar", "Aceptar");
                    historialLista.ItemsSource = null;
                    return;
                }
                else
                {
                    /*el web service regresa un objeto jSON, se deserializa para poder trabajarlo*/
                    var tr = JsonConvert.DeserializeObject<List<Elemento>>(result);
                    historialLista.ItemsSource = null;
                    historialLista.SelectedItem = null;
                    historialLista.ItemSelected += null;
                    historialLista.ItemsSource = tr;
                    historialLista.ItemSelected += HistorialLista_ItemSelected;
                    
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                return;
            }
        }

        private async void HistorialLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var element = e.SelectedItem as Elemento;
                string descripcion = "SITIO: " + element.razon + " " + element.direccion + "\n\nOFICIAL: " + element.empleado + " " + element.nombre + "\n\nTURNO: " + element.turno + "        ÁREA: " + element.area + "        UNIDAD: " + element.unidad ;
                await DisplayAlert(element.fecha, descripcion, "Aceptar");
            }
        }
    }
}