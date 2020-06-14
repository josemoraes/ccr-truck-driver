using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android.Factories;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;

namespace truckapp01.Droid
{
    public class AccessNativeBitmapConfig : IBitmapDescriptorFactory
    {
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor)
        {
            /*int resId = 0;
            switch (descriptor.Id)
            {
                case "localizacao":
                    resId = Resource.Drawable.localizacao;
                    break;
            }

            return AndroidBitmapDescriptorFactory.FromResource(resId);*/

            return null;
        }
    }
}
