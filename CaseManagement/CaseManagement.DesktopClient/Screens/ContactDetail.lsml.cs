using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Collections.Specialized;

namespace LightSwitchApplication
{
    public partial class ContactDetail
    {
        void SetContactPrimaryEmailAddress()
        {

            var primary = ScreenData.ContactEmailAddresses.FirstOrDefault(x => x.Primary);
            if (primary == null)
            {
                //primary.Primary = true;
                //this.PrimaryContactEmailAddress = primary;
                primary = ScreenData.ContactEmailAddresses.FirstOrDefault();
                if(primary != null)
                {
                    primary.Primary = true;
                    this.PrimaryContactEmailAddress = primary;
                }
            }
            else
            {
                this.PrimaryContactEmailAddress = primary;
            }

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



        partial void Contact_Loaded(bool succeeded)
        {
            this.ScreenData = this.Contact ?? this.DataWorkspace.ApplicationData.Contacts.AddNew();
            this.SetDisplayNameFromEntity(this.ScreenData);


            SetContactAddressProperties();
            SetContactPrimaryEmailAddress();
        }

        partial void ContactEmailAddressesAddAndEditNew_Execute()
        {
            // Write your code here.
            this.ContactEmailAddressEdit = this.ContactEmailAddresses.AddNew();
            this.OpenModalWindow("ContactEmailAdressEditModal");
        }

        partial void SaveContactEmailAddress_Execute()
        {
            // Write your code here.
            if (this.ContactEmailAddressEdit.Primary)
            {
                this.ContactEmailAddresses.Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
                this.ContactEmailAddressEdit.Primary = true;
                SetContactPrimaryEmailAddress();
            }
            this.CloseModalWindow("ContactEmailAdressEditModal");
        }

        partial void CancelContactEmailAddressEdit_Execute()
        {
            // Write your code here.
            //this.ContactE
            this.ContactEmailAddressEdit.Details.DiscardChanges();
            this.CloseModalWindow("ContactEmailAdressEditModal");
        }

        partial void ContactEmailAddressesDeleteSelected_Execute()
        {
            // Write your code here.

            this.ContactEmailAddresses.SelectedItem.Delete();
            this.ContactEmailAddresses.Screen.Save();
            SetContactPrimaryEmailAddress();
        }

        partial void PrimaryContactEmailAddress_Changed()
        {

            var selected = this.PrimaryContactEmailAddress;
            var primary = this.ContactEmailAddresses.FirstOrDefault(x => x.Primary);
            if (selected != primary)
            {
                this.ContactEmailAddresses.Except(new List<ContactEmailAddress> { selected }).Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
                this.PrimaryContactEmailAddress.Primary = true;
            }

           
        }

        partial void ContactDetail_Saving(ref bool handled)
        {
            // Write your code here.
            if(this.ContactEmailAddresses.Any(x=>x.Primary) == false && this.ContactEmailAddresses.Any())       
                this.ContactEmailAddresses.OrderByDescending(x => x.Modified).First().Primary = true;

            //this.Refresh();
           
 
        }

        partial void ContactDetail_Saved()
        {
            // Write your code here.
            Application.RaiseContactSavedEvent();
            this.Close(false);
        }






















    }
}