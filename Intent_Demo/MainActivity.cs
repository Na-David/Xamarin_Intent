using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;
using Android.Widget;
using Android.Content;

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

            btnCall.Click += BtnCall_Click;
            btnSearch.Click += BtnSearch_Click;
            btnSend.Click += BtnSend_Click;
        }
        
        private void BtnCall_Click(object sender, EventArgs e)
        {
            var call = Android.Net.Uri.Parse("tel:" + PhoneNumber.Text);
            var intent = new Intent(Intent.ActionDial,call);
            StartActivity(intent);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var search = Android.Net.Uri.Parse("geo:" + Latitude.Text + "," + Longitude.Text);
            var intent = new Intent(Intent.ActionView, search);
            StartActivity(intent);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { EmailTo.Text });

            email.PutExtra(Android.Content.Intent.ExtraSubject, Subject.Text);
            email.PutExtra(Android.Content.Intent.ExtraSubject, Message.Text);
            email.SetType("message/rfc822");
            StartActivity(email);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}