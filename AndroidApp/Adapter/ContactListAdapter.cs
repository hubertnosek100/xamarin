using Android.App;
using Android.Views;
using Android.Widget;
using AndroidApp.Model;
using Java.Lang;
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
                convertView.Tag = viewHolder;
            }

            if (viewHolder is null)
            {
                viewHolder = convertView.Tag as ContactViewHolder;
            }

            Contact contact = contacts[position];

            viewHolder.NameTextView.Text = contact.Name;
            viewHolder.PhoneTextView.Text = contact.PhoneNumber;

            return convertView;
        }
    }
}