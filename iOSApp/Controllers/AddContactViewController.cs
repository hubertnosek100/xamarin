using Foundation;
using iOSApp.Model;
using System;
using UIKit;

namespace iOSApp.Controllers
{
    public partial class AddContactViewController : UIViewController
    {
        public AddContactViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddContact.TouchUpInside += delegate
            {
                var newContact = new Contact(NameTextField.Text, EmailTextField.Text, PhoneTextField.Text);

                NavigationController.PopViewController(true);
                (NavigationController.TopViewController as MainViewController).AddContact(newContact);
            };
        }
    }
}