using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using AndroidApp.Model;
using AndroidApp.Adapter;
using AndroidApp.Activities;
using Android.Content;
using Newtonsoft.Json;
using AlertDialog = Android.App.AlertDialog;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private static int ADD_CONTACT_REQUEST_CODE = 200;
        private List<Contact> contacts;
        private ContactListAdapter adapter;

        public static string NEW_CONTACT_KEY = "NEW_CONTACT_KEY";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button addButton = FindViewById<Button>(Resource.Id.addButton);

            addButton.Click += delegate
            {
                StartActivityForResult(typeof(AddActivity), ADD_CONTACT_REQUEST_CODE);
            };

            ListView listView = FindViewById<ListView>(Resource.Id.contactListView);

            Initialize();
            adapter = new ContactListAdapter(contacts, this);
            listView.Adapter = adapter;
            listView.ItemLongClick += ItemLongClicked;
        }
        private void ItemLongClicked(object sender, AdapterView.ItemLongClickEventArgs args)
        {
            var contact = contacts[args.Position];

            var alert = new AlertDialog.Builder(this).Create();

            alert.SetTitle("Delete");
            alert.SetMessage(string.Format("Are you sure to delete {0}?", contact.Name));

            alert.SetButton("Yes", delegate
            {
                contacts.Remove(contact);
                adapter.NotifyDataSetChanged();
            });
            alert.SetButton2("No", delegate
            {

            });

            alert.Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ADD_CONTACT_REQUEST_CODE && data != null)
            {
                var contact = JsonConvert.DeserializeObject<Contact>(data.GetStringExtra(NEW_CONTACT_KEY));
                contacts.Add(contact);
                adapter.NotifyDataSetChanged();

            }
        }

        private void Initialize()
        {
            contacts = new List<Contact>();

            for (int i = 0; i < 20; i++)
            {
                contacts.Add(new Contact("My Contact" + i, "contact@gmail.com", "+48 500 501 502"));
            }
        }

    }
}