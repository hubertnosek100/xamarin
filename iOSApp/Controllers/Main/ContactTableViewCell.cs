using System;

using Foundation;
using iOSApp.Model;
using UIKit;

namespace iOSApp.Controllers.Main
{
    public partial class ContactTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ContactTableViewCell");
        public static readonly UINib Nib;

        static ContactTableViewCell()
        {
            Nib = UINib.FromName("ContactTableViewCell", NSBundle.MainBundle);
        }

        protected ContactTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void Initialize(Contact contact)
        {
            NameLabel.Text = contact.Name;
            PhoneNumberLabel.Text = contact.PhoneNumber;

            EmailImageView.UserInteractionEnabled = true;
            EmailImageView.AddGestureRecognizer(new UITapGestureRecognizer(x =>
           {
               var url = NSUrl.FromString(string.Format("mailto:{0}", contact.Email));
               OpenUrl(url);
           }));

            PhoneImageView.UserInteractionEnabled = true;
            PhoneImageView.AddGestureRecognizer(new UITapGestureRecognizer(x =>
            {
                var url = NSUrl.FromString(string.Format("tel:{0}", contact.PhoneNumber.Replace(" ", "")));
                OpenUrl(url);
            }));

        }

        private void OpenUrl(NSUrl url)
        {
            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var alert = new UIAlertView("Not supported", "This is not suportted on your device", null, "Ok", null);
                alert.Show();
            }
        }
    }
}
