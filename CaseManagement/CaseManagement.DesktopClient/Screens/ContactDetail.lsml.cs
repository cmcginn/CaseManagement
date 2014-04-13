using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication
{
    public partial class ContactDetail
    {
        void SetContactPrimaryEmailAddress()
        {
            var primary = ScreenData.ContactEmailAddresses.FirstOrDefault(x => x.Primary);
            if (primary != null)
                this.PrimaryEmailAddress = primary;
            ContactEmailAddresses.ToList().ForEach(x => { });
        }
        void SetContactAddressProperties()
        {
            //var primaryAddress = ContactAddresses.FirstOrDefault(x => x.Primary);
            ////if (primaryAddress != null)
            ////    this.PrimaryAddress = primaryAddress;
            //ContactAddresses.ToList().ForEach(x =>
            //{
            //    this.FindControlInCollection("SetPrimaryContactAddress", x).IsVisible = x.Primary == false;

            //});
        }
        //partial void Contact_Loaded(bool succeeded)
        //{
        //    // Write your code here.
        //    this.SetDisplayNameFromEntity(this.Contact);
        //    this.ScreenData = this.Contact ?? this.DataWorkspace.ApplicationData.Contacts.AddNew();
        //}

        //partial void Contact_Changed()
        //{
        //    // Write your code here.
        //    this.SetDisplayNameFromEntity(this.Contact);
        //}

        //partial void ContactDetail_Saved()
        //{
        //    // Write your code here.
        //    this.SetDisplayNameFromEntity(this.Contact);
        //}

        partial void ContactAddressesAddAndEditNew_CanExecute(ref bool result)
        {
            // Write your code here.

        }

        partial void ContactAddressesAddAndEditNew_Execute()
        {
            // Write your code here.
          //  this.ContactAddressEdit = this.ContactAddresses.AddNew();
            this.OpenModalWindow("ContactAddressEditGroup");
        }

        partial void SaveContactAddress_Execute()
        {
            // Write your code here.
            this.CloseModalWindow("ContactAddressEditGroup");
            SetContactAddressProperties();
        }

        partial void CancelContactAddressEdit_Execute()
        {
            // Write your code here.
            this.ContactAddressEdit.Details.DiscardChanges();
            this.CloseModalWindow("ContactAddressEditGroup");
        }

        partial void SetPrimaryContactAddress_Execute()
        {
            // Write your code here.

        }

        partial void ContactDetail_Created()
        {
            
        }

        partial void SetPrimaryEmailAddress_Execute()
        {
            // Write your code here.
            this.ContactEmailAddresses.Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
            this.ContactEmailAddresses.SelectedItem.Primary = true;
            SetContactPrimaryEmailAddress();
        }

        partial void Contact_Loaded(bool succeeded)
        {
            this.ScreenData = this.Contact ?? this.DataWorkspace.ApplicationData.Contacts.AddNew();
            this.SetDisplayNameFromEntity(this.ScreenData);


            SetContactAddressProperties();
            SetContactPrimaryEmailAddress();
        }
    }
}