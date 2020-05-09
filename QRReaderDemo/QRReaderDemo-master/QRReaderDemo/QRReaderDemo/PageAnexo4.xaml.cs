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
	public partial class PageAnexo4 : ContentPage
	{
        private int[] a3;

		public PageAnexo4 (int[] anexo3)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            a3 = anexo3;
            fillButton();
        }

        private void fillButton()
        {
            switch (a3[0])
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
            switch (a3[1])
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
            switch (a3[2])
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
            switch (a3[3])
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
            switch (a3[4])
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
            switch (a3[5])
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
            switch (a3[6])
            {
                case 1:
                    button19.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button20.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button21.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a3[7])
            {
                case 1:
                    button22.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button23.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button24.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a3[8])
            {
                case 1:
                    button25.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button26.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button27.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
        }

        public int[] getAnexo()
        {
            return a3;
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
                    a3[0] = 1;
                    break;
                case "button2":
                    a3[0] = 2;
                    break;
                case "button3":
                    a3[0] = 3;
                    break;
                default:
                    a3[0] = 0;
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
                    a3[1] = 1;
                    break;
                case "button5":
                    a3[1] = 2;
                    break;
                case "button6":
                    a3[1] = 3;
                    break;
                default:
                    a3[1] = 0;
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
                    a3[2] = 1;
                    break;
                case "button8":
                    a3[2] = 2;
                    break;
                case "button9":
                    a3[2] = 3;
                    break;
                default:
                    a3[2] = 0;
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
                    a3[3] = 1;
                    break;
                case "button11":
                    a3[3] = 2;
                    break;
                case "button12":
                    a3[3] = 3;
                    break;
                default:
                    a3[3] = 0;
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
                    a3[4] = 1;
                    break;
                case "button14":
                    a3[4] = 2;
                    break;
                case "button15":
                    a3[4] = 3;
                    break;
                default:
                    a3[4] = 0;
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
                    a3[5] = 1;
                    break;
                case "button17":
                    a3[5] = 2;
                    break;
                case "button18":
                    a3[5] = 3;
                    break;
                default:
                    a3[5] = 0;
                    break;
            }
        }
        private void button_Clicked7(object sender, EventArgs e)
        {
            this.button19.BackgroundColor = Color.LightGray;
            this.button20.BackgroundColor = Color.LightGray;
            this.button21.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button19":
                    a3[6] = 1;
                    break;
                case "button20":
                    a3[6] = 2;
                    break;
                case "button21":
                    a3[6] = 3;
                    break;
                default:
                    a3[6] = 0;
                    break;
            }
        }
        private void button_Clicked8(object sender, EventArgs e)
        {
            this.button22.BackgroundColor = Color.LightGray;
            this.button23.BackgroundColor = Color.LightGray;
            this.button24.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button22":
                    a3[7] = 1;
                    break;
                case "button23":
                    a3[7] = 2;
                    break;
                case "button24":
                    a3[7] = 3;
                    break;
                default:
                    a3[7] = 0;
                    break;
            }
        }
        private void button_Clicked9(object sender, EventArgs e)
        {
            this.button25.BackgroundColor = Color.LightGray;
            this.button26.BackgroundColor = Color.LightGray;
            this.button27.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button25":
                    a3[8] = 1;
                    break;
                case "button26":
                    a3[8] = 2;
                    break;
                case "button27":
                    a3[8] = 3;
                    break;
                default:
                    a3[8] = 0;
                    break;
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}