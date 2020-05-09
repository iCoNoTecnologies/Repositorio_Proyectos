using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;
using Plugin.Media.Abstractions;

namespace QRReaderDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageFoto : ContentPage
	{
		public PageFoto ()
		{
			InitializeComponent ();
            CrossMedia.Current.Initialize();
		}

        
    }
}