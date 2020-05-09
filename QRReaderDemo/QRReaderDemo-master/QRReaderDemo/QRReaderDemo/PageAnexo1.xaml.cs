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
	public partial class PageAnexo1 : ContentPage
	{
        private int[] a2;
        
		public PageAnexo1 (int[] anexo2, string sexo)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            a2 = anexo2;
            if(sexo == "Masculino")
            {
                hombre_1.IsVisible = true;
                hombre_2.IsVisible = true;
                hombre_3.IsVisible = true;

                button16.IsVisible = true;
                button17.IsVisible = true;
                button18.IsVisible = true;

                button19.IsVisible = true;
                button20.IsVisible = true;
                button21.IsVisible = true;

                button22.IsVisible = true;
                button23.IsVisible = true;
                button24.IsVisible = true;

                mujer_1.IsVisible = false;
                mujer_2.IsVisible = false;

                button25.IsVisible = false;
                button26.IsVisible = false;
                button27.IsVisible = false;

                button28.IsVisible = false;
                button29.IsVisible = false;
                button30.IsVisible = false;
            }
            else if(sexo == "Femenino")
            {
                hombre_1.IsVisible = false;
                hombre_2.IsVisible = false;
                hombre_3.IsVisible = false;

                button16.IsVisible = false;
                button17.IsVisible = false;
                button18.IsVisible = false;

                button19.IsVisible = false;
                button20.IsVisible = false;
                button21.IsVisible = false;

                button22.IsVisible = false;
                button23.IsVisible = false;
                button24.IsVisible = false;

                mujer_1.IsVisible = true;
                mujer_2.IsVisible = true;

                button25.IsVisible = true;
                button26.IsVisible = true;
                button27.IsVisible = true;

                button28.IsVisible = true;
                button29.IsVisible = true;
                button30.IsVisible = true;
            }
            fillButton();
        }

        private void fillButton()
        {
            switch (a2[0])
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
            switch (a2[1])
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
            switch (a2[2])
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
            switch (a2[3])
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
            switch (a2[4])
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
            switch (a2[5])
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
            switch (a2[6])
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
            switch (a2[7])
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
            switch (a2[8])
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
            switch (a2[9])
            {
                case 1:
                    button28.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button29.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button30.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a2[10])
            {
                case 1:
                    button31.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button32.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button33.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a2[11])
            {
                case 1:
                    button34.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button35.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button36.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a2[12])
            {
                case 1:
                    button37.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button38.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button39.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
        }

        public int[] getAnexo()
        {
            return a2;
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
                    a2[0] = 1;
                    break;
                case "button2":
                    a2[0] = 2;
                    break;
                case "button3":
                    a2[0] = 3;
                    break;
                default:
                    a2[0] = 0;
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
                    a2[1] = 1;
                    break;
                case "button5":
                    a2[1] = 2;
                    break;
                case "button6":
                    a2[1] = 3;
                    break;
                default:
                    a2[1] = 0;
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
                    a2[2] = 1;
                    break;
                case "button8":
                    a2[2] = 2;
                    break;
                case "button9":
                    a2[2] = 3;
                    break;
                default:
                    a2[2] = 0;
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
                    a2[3] = 1;
                    break;
                case "button11":
                    a2[3] = 2;
                    break;
                case "button12":
                    a2[3] = 3;
                    break;
                default:
                    a2[3] = 0;
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
                    a2[4] = 1;
                    break;
                case "button14":
                    a2[4] = 2;
                    break;
                case "button15":
                    a2[4] = 3;
                    break;
                default:
                    a2[4] = 0;
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
                    a2[5] = 1;
                    break;
                case "button17":
                    a2[5] = 2;
                    break;
                case "button18":
                    a2[5] = 3;
                    break;
                default:
                    a2[5] = 0;
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
                    a2[6] = 1;
                    break;
                case "button20":
                    a2[6] = 2;
                    break;
                case "button21":
                    a2[6] = 3;
                    break;
                default:
                    a2[6] = 0;
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
                    a2[7] = 1;
                    break;
                case "button23":
                    a2[7] = 2;
                    break;
                case "button24":
                    a2[7] = 3;
                    break;
                default:
                    a2[7] = 0;
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
                    a2[8] = 1;
                    break;
                case "button26":
                    a2[8] = 2;
                    break;
                case "button27":
                    a2[8] = 3;
                    break;
                default:
                    a2[8] = 0;
                    break;
            }
        }
        private void button_Clicked10(object sender, EventArgs e)
        {
            this.button28.BackgroundColor = Color.LightGray;
            this.button29.BackgroundColor = Color.LightGray;
            this.button30.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button28":
                    a2[9] = 1;
                    break;
                case "button29":
                    a2[9] = 2;
                    break;
                case "button30":
                    a2[9] = 3;
                    break;
                default:
                    a2[9] = 0;
                    break;
            }
        }
        private void button_Clicked11(object sender, EventArgs e)
        {
            this.button31.BackgroundColor = Color.LightGray;
            this.button32.BackgroundColor = Color.LightGray;
            this.button33.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button31":
                    a2[10] = 1;
                    break;
                case "button32":
                    a2[10] = 2;
                    break;
                case "button33":
                    a2[10] = 3;
                    break;
                default:
                    a2[10] = 0;
                    break;
            }
        }
        private void button_Clicked12(object sender, EventArgs e)
        {
            this.button34.BackgroundColor = Color.LightGray;
            this.button35.BackgroundColor = Color.LightGray;
            this.button36.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button34":
                    a2[11] = 1;
                    break;
                case "button35":
                    a2[11] = 2;
                    break;
                case "button36":
                    a2[11] = 3;
                    break;
                default:
                    a2[11] = 0;
                    break;
            }
        }
        private void button_Clicked13(object sender, EventArgs e)
        {
            this.button37.BackgroundColor = Color.LightGray;
            this.button38.BackgroundColor = Color.LightGray;
            this.button39.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button37":
                    a2[12] = 1;
                    break;
                case "button38":
                    a2[12] = 2;
                    break;
                case "button39":
                    a2[12] = 3;
                    break;
                default:
                    a2[12] = 0;
                    break;
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}