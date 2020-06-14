using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android;
using Acr.UserDialogs;
using Xamarin.Forms.GoogleMaps.Android;

namespace truckapp01.Droid
{
    [Activity(Label = "Rodapi", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);

            var platformConfig = new PlatformConfig
            {
                BitmapDescriptorFactory = new AccessNativeBitmapConfig()
            };
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState, platformConfig);

            ActivityCompat.RequestPermissions(this, new String[]
            {
                Manifest.Permission.ReadExternalStorage,
                Manifest.Permission.WriteExternalStorage,
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.AccessFineLocation,
                Manifest.Permission.AccessLocationExtraCommands,
                Manifest.Permission.AccessMockLocation,
                Manifest.Permission.AccessNetworkState,
                Manifest.Permission.AccessWifiState,
                Manifest.Permission.Internet,
                Manifest.Permission.SendSms,
                Manifest.Permission.CallPhone
            }, 0);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}