// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOSApp.Controllers.Main
{
    [Register ("ContactTableViewCell")]
    partial class ContactTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView EmailImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView PhoneImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PhoneNumberLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailImageView != null) {
                EmailImageView.Dispose ();
                EmailImageView = null;
            }

            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (PhoneImageView != null) {
                PhoneImageView.Dispose ();
                PhoneImageView = null;
            }

            if (PhoneNumberLabel != null) {
                PhoneNumberLabel.Dispose ();
                PhoneNumberLabel = null;
            }
        }
    }
}