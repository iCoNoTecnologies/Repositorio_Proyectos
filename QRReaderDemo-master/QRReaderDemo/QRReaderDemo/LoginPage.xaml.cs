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

        private async void buttonEnter_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("HTTP://172.27.103.104");
            /*string url = string.Format("/prueba.php?dato={0}",entryUser.Text);

            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;*/
            var postData = new List<KeyValuePair<string, string>>();
            var version = "2.0.1";

            postData.Add(new KeyValuePair<string, string>("version", version));


            var content = new FormUrlEncodedContent(postData);

            //client.BaseAddress = new Uri("Http://172.27.103.104");

            try
            {
                var response = await client.PostAsync("Http://201.144.14.11/sidesp/app/actualizar.php", content);
                var result = response.Content.ReadAsStringAsync().Result;
                var versionbd = result.Trim();



                if (versionbd.ToString() == version)
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
                    HttpClient client2 = new HttpClient();
                    client2.BaseAddress = new Uri("HTTP://172.27.103.104");
                    /*string url = string.Format("/prueba.php?dato={0}",entryUser.Text);

                    var response = await client.GetAsync(url);
                    var result = response.Content.ReadAsStringAsync().Result;*/
                    var postData2 = new List<KeyValuePair<string, string>>();
                    var user = entryUser.Text;
                    var pass = entryPass.Text;
                    postData2.Add(new KeyValuePair<string, string>("user", user));
                    postData2.Add(new KeyValuePair<string, string>("pass", pass));

                    var content2 = new FormUrlEncodedContent(postData2);

                    //client.BaseAddress = new Uri("Http://172.27.103.104");

                    try
                    {
                        var response2 = await client2.PostAsync("Http://201.144.14.11/sidesp/app/login.php", content2);
                        var result2 = response2.Content.ReadAsStringAsync().Result;
                        var nombre = result2.Trim();

                        buttonEnter.IsEnabled = true;
                        activityIndicator.IsRunning = false;

                        if (string.IsNullOrEmpty(nombre) || nombre == "null" || nombre.Equals("") || nombre.Length < 1)
                        {
                            await DisplayAlert("Error", "Usuario o contraseña inválidos", "Aceptar");
                            //await DisplayAlert("Error", result, "Aceptar");
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
                    catch (Exception ex)
                    {
                        await DisplayAlert("ERROR", "No es posible acceder en este momento, revise su configuración de internet", "Aceptar");
                        buttonEnter.IsEnabled = true;
                        activityIndicator.IsRunning = false;
                        return;
                    }


                }
                else
                {
                    Console.WriteLine("*********************entro else*********************************");
                    Actualizar act = new Actualizar();

                    await Navigation.PushAsync(act);


                }




            }
            catch (Exception ex)
            {


                return;
            }
           

            
            
            


        }
	}
}