using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;
using System.IO;
using Android.Widget;

namespace Intent_Demo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnSearch;
        Button btnCall;
        Button btnSend;

        EditText PhoneNumber;
        EditText Latitude;
        EditText Longitude;
        EditText EmailTo;
        EditText Subject;
        EditText Message;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnCall = FindViewById<Button>(Resource.Id.btnCall);
            btnSend = FindViewById<Button>(Resource.Id.btnSend);

            PhoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumber);
            Latitude = FindViewById<EditText>(Resource.Id.Latitude);
            Longitude = FindViewById<EditText>(Resource.Id.Longitude);
            EmailTo = FindViewById<EditText>(Resource.Id.EmailTo);
            Subject = FindViewById<EditText>(Resource.Id.Subject);
            Message = FindViewById<EditText>(Resource.Id.Message);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}