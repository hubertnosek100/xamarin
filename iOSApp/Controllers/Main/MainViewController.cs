using iOSApp.Controllers.Main;
using iOSApp.Model;
using System;
using System.Collections.Generic;
using UIKit;

namespace iOSApp.Controllers
{
    public partial class MainViewController : UIViewController
    {
        private List<Contact> contacts;
        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Initialize();
            AutomaticallyAdjustsScrollViewInsets = false;
            ContactTableView.Source = new ContactTableViewSource(ContactTableView, contacts, this);
            ContactTableView.AllowsSelection = false;
        }

        internal void AddContact(Contact newContact)
        {
            contacts.Add(newContact);
            ContactTableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
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