using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.App;
using System.Net.Http;
using System.Collections.Generic;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System.IO;
using System.Linq;

namespace QRReaderDemo.Droid
{
    [Activity(Label = "Frecuencia de Paso Corregidora", Icon = "@mipmap/corregidora", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnStart()
        {
            base.OnStart();
          
            if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);


              
            }

            if (CheckSelfPermission(Manifest.Permission.Camera) != (int)Permission.Granted)
            {
                RequestPermissions(new String[] { Manifest.Permission.Camera }, 0);

            }





        }
        protected override async void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Downloaded();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
            

        }
        public void Downloaded()

        {

            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>

                (file =>

                {

                    string filename = Android.Net.Uri.Parse(file.Url).Path.Split('/').Last();

                    return Path.Combine(ApplicationContext.GetExternalFilesDir

                        (Android.OS.Environment.DirectoryDownloads).AbsolutePath, filename);

                });

        }


    }
  
}