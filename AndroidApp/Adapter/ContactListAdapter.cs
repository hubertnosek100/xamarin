using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidApp.Model;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace AndroidApp.Adapter
{
    public class ContactListAdapter : BaseAdapter<Contact>
    {
        private List<Contact> contacts;
        private readonly Activity parent;

        public ContactListAdapter(List<Contact> contacts, Activity parent)
        {
            this.contacts = contacts;
            this.parent = parent;
        }
        public override Contact this[int position] => contacts[position];

        public override int Count => contacts.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ContactViewHolder viewHolder = null;

            if (convertView is null)
            {
                convertView = this.parent.LayoutInflater.Inflate(Resource.Layout.view_contact, null);
                viewHolder = new ContactViewHolder();
                viewHolder.NameTextView = convertView.FindViewById<TextView>(Resource.Id.name);
                viewHolder.PhoneTextView = convertView.FindViewById<TextView>(Resource.Id.phoneNumber);
                viewHolder.PhoneImageView = convertView.FindViewById<ImageView>(Resource.Id.phoneImage);
                viewHolder.EmailImageView = convertView.FindViewById<ImageView>(Resource.Id.emailImage);

                viewHolder.EmailImageView.Click += EmailImageViewClicked;
                viewHolder.PhoneImageView.Click += PhoneImageViewClicked;

                convertView.Tag = viewHolder;
            }

            if (viewHolder is null)
            {
                viewHolder = convertView.Tag as ContactViewHolder;
            }

            Contact contact = contacts[position];

            viewHolder.NameTextView.Text = contact.Name;
            viewHolder.PhoneTextView.Text = contact.PhoneNumber;

            viewHolder.EmailImageView.Tag = position;
            viewHolder.PhoneImageView.Tag = position;

            return convertView;
        }
        private void EmailImageViewClicked(object sender, EventArgs args)
        {
            var contact = contacts[(int)(sender as ImageView).Tag];

            var intent = new Intent(Intent.ActionSend);
            intent.SetType("plain/text");
            intent.PutExtra(Intent.ExtraEmail, new string[] { contact.Email });
            parent.StartActivity(intent);
        }

        private void PhoneImageViewClicked(object sender, EventArgs args)
        {
            var contact = contacts[(int)(sender as ImageView).Tag];

            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Android.Net.Uri.Parse(string.Format("tel:{0}", contact.PhoneNumber)));
            parent.StartActivity(intent);
        }
    }
}