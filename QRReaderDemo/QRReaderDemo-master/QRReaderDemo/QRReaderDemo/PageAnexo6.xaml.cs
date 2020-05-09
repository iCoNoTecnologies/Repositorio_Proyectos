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
	public partial class PageAnexo6 : ContentPage
	{
        private int[] a4;

		public PageAnexo6 (int[] anexo4)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            a4 = anexo4;
            fillButton();
		}

        private void fillButton()
        {
            switch (a4[0])
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
                case 4:
                    button4.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button5.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[1])
            {
                case 1:
                    button6.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button7.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button8.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button9.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button10.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[2])
            {
                case 1:
                    button11.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button12.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button13.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button14.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button15.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[3])
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
                case 4:
                    button19.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button20.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[4])
            {
                case 1:
                    button21.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button22.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button23.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button24.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button25.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[5])
            {
                case 1:
                    button26.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button27.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button28.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button29.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button30.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[6])
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
                case 4:
                    button34.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button35.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[7])
            {
                case 1:
                    button36.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button37.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button38.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button39.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button40.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[8])
            {
                case 1:
                    button41.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button42.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button43.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button44.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button45.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
            switch (a4[9])
            {
                case 1:
                    button46.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 2:
                    button47.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 3:
                    button48.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 4:
                    button49.BackgroundColor = Color.LightSeaGreen;
                    break;
                case 5:
                    button50.BackgroundColor = Color.LightSeaGreen;
                    break;
            }
        }

        public int[] getAnexo()
        {
            return a4;
        }

        private void button_Clicked1(object sender, EventArgs e)
        {
            this.button1.BackgroundColor = Color.LightGray;
            this.button2.BackgroundColor = Color.LightGray;
            this.button3.BackgroundColor = Color.LightGray;
            this.button4.BackgroundColor = Color.LightGray;
            this.button5.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button1":
                    a4[0] = 1;
                    break;
                case "button2":
                    a4[0] = 2;
                    break;
                case "button3":
                    a4[0] = 3;
                    break;
                case "button4":
                    a4[0] = 4;
                    break;
                case "button5":
                    a4[0] = 5;
                    break;
                default:
                    a4[0] = 0;
                    break;
            }
        }
        private void button_Clicked2(object sender, EventArgs e)
        {
            this.button6.BackgroundColor = Color.LightGray;
            this.button7.BackgroundColor = Color.LightGray;
            this.button8.BackgroundColor = Color.LightGray;
            this.button9.BackgroundColor = Color.LightGray;
            this.button10.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button6":
                    a4[1] = 1;
                    break;
                case "button7":
                    a4[1] = 2;
                    break;
                case "button8":
                    a4[1] = 3;
                    break;
                case "button9":
                    a4[1] = 4;
                    break;
                case "button10":
                    a4[1] = 5;
                    break;
                default:
                    a4[1] = 0;
                    break;
            }
        }
        private void button_Clicked3(object sender, EventArgs e)
        {
            this.button11.BackgroundColor = Color.LightGray;
            this.button12.BackgroundColor = Color.LightGray;
            this.button13.BackgroundColor = Color.LightGray;
            this.button14.BackgroundColor = Color.LightGray;
            this.button15.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button11":
                    a4[2] = 1;
                    break;
                case "button12":
                    a4[2] = 2;
                    break;
                case "button13":
                    a4[2] = 3;
                    break;
                case "button14":
                    a4[2] = 4;
                    break;
                case "button15":
                    a4[2] = 5;
                    break;
                default:
                    a4[2] = 0;
                    break;
            }
        }
        private void button_Clicked4(object sender, EventArgs e)
        {
            this.button16.BackgroundColor = Color.LightGray;
            this.button17.BackgroundColor = Color.LightGray;
            this.button18.BackgroundColor = Color.LightGray;
            this.button19.BackgroundColor = Color.LightGray;
            this.button20.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button16":
                    a4[3] = 1;
                    break;
                case "button17":
                    a4[3] = 2;
                    break;
                case "button18":
                    a4[3] = 3;
                    break;
                case "button19":
                    a4[3] = 4;
                    break;
                case "button20":
                    a4[3] = 5;
                    break;
                default:
                    a4[3] = 0;
                    break;
            }
        }
        private void button_Clicked5(object sender, EventArgs e)
        {
            this.button21.BackgroundColor = Color.LightGray;
            this.button22.BackgroundColor = Color.LightGray;
            this.button23.BackgroundColor = Color.LightGray;
            this.button24.BackgroundColor = Color.LightGray;
            this.button25.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button21":
                    a4[4] = 1;
                    break;
                case "button22":
                    a4[4] = 2;
                    break;
                case "button23":
                    a4[4] = 3;
                    break;
                case "button24":
                    a4[4] = 4;
                    break;
                case "button25":
                    a4[4] = 5;
                    break;
                default:
                    a4[4] = 0;
                    break;
            }
        }
        private void button_Clicked6(object sender, EventArgs e)
        {
            this.button26.BackgroundColor = Color.LightGray;
            this.button27.BackgroundColor = Color.LightGray;
            this.button28.BackgroundColor = Color.LightGray;
            this.button29.BackgroundColor = Color.LightGray;
            this.button30.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button26":
                    a4[5] = 1;
                    break;
                case "button27":
                    a4[5] = 2;
                    break;
                case "button28":
                    a4[5] = 3;
                    break;
                case "button29":
                    a4[5] = 4;
                    break;
                case "button30":
                    a4[5] = 5;
                    break;
                default:
                    a4[5] = 0;
                    break;
            }
        }
        private void button_Clicked7(object sender, EventArgs e)
        {
            this.button31.BackgroundColor = Color.LightGray;
            this.button32.BackgroundColor = Color.LightGray;
            this.button33.BackgroundColor = Color.LightGray;
            this.button34.BackgroundColor = Color.LightGray;
            this.button35.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button31":
                    a4[6] = 1;
                    break;
                case "button32":
                    a4[6] = 2;
                    break;
                case "button33":
                    a4[6] = 3;
                    break;
                case "button34":
                    a4[6] = 4;
                    break;
                case "button35":
                    a4[6] = 5;
                    break;
                default:
                    a4[6] = 0;
                    break;
            }
        }
        private void button_Clicked8(object sender, EventArgs e)
        {
            this.button36.BackgroundColor = Color.LightGray;
            this.button37.BackgroundColor = Color.LightGray;
            this.button38.BackgroundColor = Color.LightGray;
            this.button39.BackgroundColor = Color.LightGray;
            this.button40.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button36":
                    a4[7] = 1;
                    break;
                case "button37":
                    a4[7] = 2;
                    break;
                case "button38":
                    a4[7] = 3;
                    break;
                case "button39":
                    a4[7] = 4;
                    break;
                case "button40":
                    a4[7] = 5;
                    break;
                default:
                    a4[7] = 0;
                    break;
            }
        }
        private void button_Clicked9(object sender, EventArgs e)
        {
            this.button41.BackgroundColor = Color.LightGray;
            this.button42.BackgroundColor = Color.LightGray;
            this.button43.BackgroundColor = Color.LightGray;
            this.button44.BackgroundColor = Color.LightGray;
            this.button45.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button41":
                    a4[8] = 1;
                    break;
                case "button42":
                    a4[8] = 2;
                    break;
                case "button43":
                    a4[8] = 3;
                    break;
                case "button44":
                    a4[8] = 4;
                    break;
                case "button45":
                    a4[8] = 5;
                    break;
                default:
                    a4[8] = 0;
                    break;
            }
        }
        private void button_Clicked10(object sender, EventArgs e)
        {
            this.button46.BackgroundColor = Color.LightGray;
            this.button47.BackgroundColor = Color.LightGray;
            this.button48.BackgroundColor = Color.LightGray;
            this.button49.BackgroundColor = Color.LightGray;
            this.button50.BackgroundColor = Color.LightGray;
            Button btn = (Button)sender;
            btn.BackgroundColor = Xamarin.Forms.Color.LightSeaGreen;
            switch (btn.ClassId)
            {
                case "button46":
                    a4[9] = 1;
                    break;
                case "button47":
                    a4[9] = 2;
                    break;
                case "button48":
                    a4[9] = 3;
                    break;
                case "button49":
                    a4[9] = 4;
                    break;
                case "button50":
                    a4[9] = 5;
                    break;
                default:
                    a4[9] = 0;
                    break;
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}