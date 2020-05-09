using Android.Content;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace QRReaderDemo
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        public IDownloadFile File; 
        bool isDownloading=true;
        public Actualizar()
        {
            InitializeComponent();
            CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
             System.Diagnostics.Debug.WriteLine(
                 "[DownloadManager] " + e.Action +
                 " -> New items: " + (e.NewItems?.Count ?? 0) +
                 "at" + e.NewStartingIndex +
                 "|| Old items:" + (e.OldItems?.Count ?? 0) +
                 "at" + e.OldStartingIndex
                );
            //NavigationPage.SetHasNavigationBar(this, false);
          


                
            }
        public async void DownlodFile(String FileNmae)
        
        {
            Console.WriteLine("entro download file");
            await Task.Yield();
           // await Navigation.PushPopupAsync(new DownloadingPage());
            await Task.Run(() =>
            {
                var downloadManager = CrossDownloadManager.Current;
                var file = downloadManager.CreateDownloadFile(FileNmae);
                downloadManager.Start(file, true);
                while (isDownloading)
                {
                    
                    isDownloading = IsDownloading(file);
                }
            });
            //await Navigation.PopAllPopupAsync();
            if (!isDownloading)
            {
                await DisplayAlert("File Status", "Archivo descargado!!", "OK");
                Abrir();
                

                //  DependencyService.Get<IToast>().ShowToast("el archivo se descargo!!");
            }

        }
        public bool IsDownloading(IDownloadFile File)
        {
            if (File ==null) return false;
            {
                

                switch (File.Status)
                {
                    case DownloadFileStatus.INITIALIZED:
                    case DownloadFileStatus.PAUSED:
                    case DownloadFileStatus.PENDING:
                    case DownloadFileStatus.RUNNING:
                        return true;
                    case DownloadFileStatus.COMPLETED:
                    case DownloadFileStatus.CANCELED:
                    case DownloadFileStatus.FAILED:
                        return false;
                    default:
                        throw new ArgumentOutOfRangeException();


                }

            }
           

        }
        public void AbortDownloading()
        {
            CrossDownloadManager.Current.Abort(File);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var Url = "http://201.144.14.11/AppsMovil/Frecuencia2020.apk";
            Console.WriteLine("se pico el boton");
            DownlodFile(Url);
        }
       public void Abrir()
        {



        }
        public static string Directorypath
        {
            get
            {
                return System.IO.Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, "Download");
            }
        }
       
    }

    
        
    }
    
