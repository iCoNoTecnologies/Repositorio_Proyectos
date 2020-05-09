using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRReaderDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageFirma : ContentPage
	{
        private bool firma;

        public PageFirma (bool hayFirma)
		{
			InitializeComponent ();
            firma = hayFirma;
		}

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (Firma.IsBlank)
            {
                firma = false;
                await DisplayAlert("Advertencia", "La firma es obligatoria", "Aceptar");
            }                
            else
            {
                firma = true;
                await Navigation.PopAsync();
            }                
        }

        public bool getFirma()
        {
            return firma;
        }

        public void setFirma(bool f)
        {
            this.firma = f;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            firma = false;
            Firma.Clear();
        }
    }
}