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
	public partial class PageAnexo3 : ContentPage
	{
        private int[] a1;

		public PageAnexo3 (int[] anexo1)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            a1 = anexo1;
            fillButton();
		}

        private void fillButton()
        {
            switch (a1[0])
            {
                case 1:
                    button1.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button2.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button3.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a1[1])
            {
                case 1:
                    button4.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button5.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button6.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a1[2])
            {
                case 1:
                    button7.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button8.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button9.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a1[3])
            {
                case 1:
                    button10.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button11.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button12.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a1[4])
            {
                case 1:
                    button13.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button14.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button15.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a1[5])
            {
                case 1:
                    button16.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button17.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button18.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
        }

        public int[] getAnexo()
        {
            return a1;
        }

        private void button_Clicked1(object sender, EventArgs e)
        {
            this.button1.BackgroundColor = Color.LightGray;
            this.button2.BackgroundColor = Color.LightGray;
            this.button3.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button1":
                    a1[0] = 1;
                    break;
                case "button2":
                    a1[0] = 2;
                    break;
                case "button3":
                    a1[0] = 3;
                    break;
                default:
                    a1[0] = 0;
                    break;
            }
        }
        private void button_Clicked2(object sender, EventArgs e)
        {
            this.button4.BackgroundColor = Color.LightGray;
            this.button5.BackgroundColor = Color.LightGray;
            this.button6.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button4":
                    a1[1] = 1;
                    break;
                case "button5":
                    a1[1] = 2;
                    break;
                case "button6":
                    a1[1] = 3;
                    break;
                default:
                    a1[0] = 0;
                    break;
            }
        }
        private void button_Clicked3(object sender, EventArgs e)
        {
            this.button7.BackgroundColor = Color.LightGray;
            this.button8.BackgroundColor = Color.LightGray;
            this.button9.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button7":
                    a1[2] = 1;
                    break;
                case "button8":
                    a1[2] = 2;
                    break;
                case "button9":
                    a1[2] = 3;
                    break;
                default:
                    a1[2] = 0;
                    break;
            }
        }
        private void button_Clicked4(object sender, EventArgs e)
        {
            this.button10.BackgroundColor = Color.LightGray;
            this.button11.BackgroundColor = Color.LightGray;
            this.button12.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button10":
                    a1[3] = 1;
                    break;
                case "button11":
                    a1[3] = 2;
                    break;
                case "button12":
                    a1[3] = 3;
                    break;
                default:
                    a1[3] = 0;
                    break;
            }
        }
        private void button_Clicked5(object sender, EventArgs e)
        {
            this.button13.BackgroundColor = Color.LightGray;
            this.button14.BackgroundColor = Color.LightGray;
            this.button15.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button13":
                    a1[4] = 1;
                    break;
                case "button14":
                    a1[4] = 2;
                    break;
                case "button15":
                    a1[4] = 3;
                    break;
                default:
                    a1[4] = 0;
                    break;
            }
        }
        private void button_Clicked6(object sender, EventArgs e)
        {
            this.button16.BackgroundColor = Color.LightGray;
            this.button17.BackgroundColor = Color.LightGray;
            this.button18.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button16":
                    a1[5] = 1;
                    break;
                case "button17":
                    a1[5] = 2;
                    break;
                case "button18":
                    a1[5] = 3;
                    break;
                default:
                    a1[5] = 0;
                    break;
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}