using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRReaderDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            buttonEnter.Clicked += buttonEnter_Clicked;
		}

        private async void creaConexion(string uri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("Http://" + uri);

            var postData = new List<KeyValuePair<string, string>>();
            var user = entryUser.Text;
            var pass = entryPass.Text;
            postData.Add(new KeyValuePair<string, string>("user", user));
            postData.Add(new KeyValuePair<string, string>("pass", pass));

            var content = new FormUrlEncodedContent(postData);

            var response = await client.PostAsync("Http://" + uri + "/test_evaluaciones/app/login.php", content);
            var result = response.Content.ReadAsStringAsync().Result;
            var nombre = result.Trim();

            buttonEnter.IsEnabled = true;
            activityIndicator.IsRunning = false;

            if (string.IsNullOrEmpty(nombre) || nombre == "null" || nombre.Equals("") || nombre.Length < 1)
            {
                await DisplayAlert("Error", "Usuario o contraseña inválidos", "Aceptar");
                entryPass.Text = string.Empty;
                entryPass.Focus();
                return;
            }

            QRReaderPage pageQR = new QRReaderPage(nombre, user);
            try
            {
                await Navigation.PushAsync(pageQR);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.ToString(), "Aceptar");
            }
        }

        private async void buttonEnter_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryUser.Text))
            {
                await DisplayAlert("Error", "Debe ingresar usuario", "Aceptar");
                entryUser.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryPass.Text))
            {
                await DisplayAlert("Error", "Debe ingresar contraseña", "Aceptar");
                entryPass.Focus();
                return;
            }

            activityIndicator.IsRunning = true;
            buttonEnter.IsEnabled = false;
            

            try // se intenta hacer la conexión por medio de la red local (wifi)
            {
                //creaConexion("172.27.100.7");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("Http://201.144.14.11");

                var postData = new List<KeyValuePair<string, string>>();
                var user = entryUser.Text;
                var pass = entryPass.Text;
                postData.Add(new KeyValuePair<string, string>("user", user));
                postData.Add(new KeyValuePair<string, string>("pass", pass));

                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("Http://201.144.14.11/test_evaluaciones/app/login.php", content);
                var result = response.Content.ReadAsStringAsync().Result;
                var nombre = result.Trim();

                buttonEnter.IsEnabled = true;
                activityIndicator.IsRunning = false;

                if (string.IsNullOrEmpty(nombre) || nombre == "null" || nombre.Equals("") || nombre.Length < 1)
                {
                    await DisplayAlert("Error", "Usuario o contraseña inválidos", "Aceptar");
                    entryPass.Text = string.Empty;
                    entryPass.Focus();
                    return;
                }

                QRReaderPage pageQR = new QRReaderPage(nombre, user);
                try
                {
                    await Navigation.PushAsync(pageQR);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERROR", ex.ToString(), "Aceptar");
                }
            }
            catch (Exception ex) // si no se puede accdeer de manera local, se intenta por medio de datos
            {
                try //intenta por medio de datos
                {
                    //creaConexion("201.144.14.11");
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("Http://172.27.100.7");

                    var postData = new List<KeyValuePair<string, string>>();
                    var user = entryUser.Text;
                    var pass = entryPass.Text;
                    postData.Add(new KeyValuePair<string, string>("user", user));
                    postData.Add(new KeyValuePair<string, string>("pass", pass));

                    var content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync("Http://172.27.100.7/test_evaluaciones/app/login.php", content);
                    var result = response.Content.ReadAsStringAsync().Result;
                    var nombre = result.Trim();

                    buttonEnter.IsEnabled = true;
                    activityIndicator.IsRunning = false;

                    if (string.IsNullOrEmpty(nombre) || nombre == "null" || nombre.Equals("") || nombre.Length < 1)
                    {
                        await DisplayAlert("Error", "Usuario o contraseña inválidos", "Aceptar");
                        entryPass.Text = string.Empty;
                        entryPass.Focus();
                        return;
                    }

                    QRReaderPage pageQR = new QRReaderPage(nombre, user);
                    try
                    {
                        await Navigation.PushAsync(pageQR);
                    }
                    catch (Exception ex2)
                    {
                        await DisplayAlert("ERROR", ex2.ToString(), "Aceptar");
                    }

                }
                catch (Exception ex2) //si falla por wifi y datos, no hay internet
                {
                    await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                    buttonEnter.IsEnabled = true;
                    activityIndicator.IsRunning = false;
                    return;
                }
            }
        }

        private void entryUser_Unfocused(object sender, FocusEventArgs e)
        {
            entryPass.Focus();
        }

        private void entryPass_Unfocused(object sender, FocusEventArgs e)
        {
            buttonEnter_Clicked(sender, e);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            entryPass.Text = "";
        }
    }
}