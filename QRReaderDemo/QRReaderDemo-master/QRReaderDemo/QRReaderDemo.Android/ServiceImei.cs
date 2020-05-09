using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using QRReaderDemo.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ServiceImei))]
namespace QRReaderDemo.Droid
{
    class ServiceImei : IServiceImei
    {
        public string GetImei()
        {
            try
            {
                TelephonyManager manager = (TelephonyManager)Forms.Context.GetSystemService(Android.Content.Context.TelephonyService);
                return manager.Imei;
            }
            catch
            {
                return null;
            }
        }
    }
}