using Android.App;
using Android.Content;
using Android.Net;
using truckapp01.Droid;
using truckapp01.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCallDroid))]
namespace truckapp01.Droid
{
    public class PhoneCallDroid : IPhoneCall
    {
        public void PhoneCall(string number)
        {
            Intent phoneIntent = new Intent(Intent.ActionCall);
            phoneIntent.SetData(Uri.Parse("tel:"+number));
            ((Activity)Forms.Context).StartActivity(phoneIntent);
        }
    }
}
    