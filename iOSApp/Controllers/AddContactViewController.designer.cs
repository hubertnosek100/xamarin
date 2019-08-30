// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSApp.Controllers
{
    [Register ("AddContactViewController")]
    partial class AddContactViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddContact { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PhoneTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddContact != null) {
                AddContact.Dispose ();
                AddContact = null;
            }

            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (NameTextField != null) {
                NameTextField.Dispose ();
                NameTextField = null;
            }

            if (PhoneTextField != null) {
                PhoneTextField.Dispose ();
                PhoneTextField = null;
            }
        }
    }
}