using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidApp.Model;
using Newtonsoft.Json;

namespace AndroidApp.Activities
{
    [Activity(Label = "AddActivity")]
    public class AddActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.add_contact);

            var email = FindViewById<EditText>(Resource.Id.emailEditText);
            var name = FindViewById<EditText>(Resource.Id.nameEditText);
            var phone = FindViewById<EditText>(Resource.Id.phoneNumberEditText);


            var button = FindViewById<Button>(Resource.Id.addButton);
            button.Click += delegate
            {
                var newContact = new Contact(name.Text, email.Text, phone.Text);

                var intent = new Intent();
                intent.PutExtra(MainActivity.NEW_CONTACT_KEY, JsonConvert.SerializeObject(newContact));
                SetResult(Result.Ok, intent);
                Finish();
            };
        }
    }
}