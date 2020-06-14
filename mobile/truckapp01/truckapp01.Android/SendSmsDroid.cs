using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Telephony;
using Android.Widget;
using truckapp01.Droid;
using truckapp01.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SendSmsDroid))]
namespace truckapp01.Droid
{
    public class SendSmsDroid : ISendSms
    {
        [System.Obsolete]
        public void SendSms(string number, string message)
        {
            //SmsManager smsManager = SmsManager.Default;
            //smsManager.SendTextMessage(number, null, message, null, null);


            Uri uri = Uri.Parse($"smsto:{number}");
            Intent it = new Intent(Intent.ActionView, uri);
            it.PutExtra("sms_body", "The SMS text");
            ((Activity)Forms.Context).StartActivity(it);

        }
    }    
}

