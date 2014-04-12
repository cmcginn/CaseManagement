using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication
{
    public partial class ContactDetail
    {
        void SetContactAddressProperties()
        {
            var primaryAddress = ContactAddresses.FirstOrDefault(x => x.Primary);
            if (primaryAddress != null)
                this.PrimaryAddress = primaryAddress.Address;
            ContactAddresses.ToList().ForEach(x =>
            {
                this.FindControlInCollection("SetPrimaryAddress", x).IsVisible = x.Primary == false;

            });
        }
        partial void ContactDetail_Created()
        {
            if (ContactId.HasValue)
                ScreenData = this.DataWorkspace.ApplicationData.Contacts_SingleOrDefault(ContactId.Value);
                   // Application.CreateDataWorkspace().ApplicationData.Contacts_SingleOrDefault(ContactId.Value);
            else
                ScreenData =  this.DataWorkspace.ApplicationData.Contacts.AddNew();
            //else

            this.SetDisplayNameFromEntity(this.ScreenData);
            SetContactAddressProperties();

        }

        partial void ContactAddressesAddAndEditNew_CanExecute(ref bool result)
        {
            // Write your code here.

        }

        partial void ContactAddressesAddAndEditNew_Execute()
        {
            // Write your code here.
            this.OpenModalWindow("AddressSearch");
        }

        partial void AddressesAddAndEditNew_CanExecute(ref bool result)
        {
            // Write your code here.

        }

        partial void AddressesAddAndEditNew_Execute()
        {
            // Write your code here.
            this.NewAddress = this.Addresses.AddNew();
            this.OpenModalWindow("CreateNewAddress");
        }

        partial void SaveAddress_Execute()
        {
            // Write your code here.
            this.CloseModalWindow("CreateNewAddress");
        }

        partial void SelectAddress_Execute()
        {
        
            if (!this.ScreenData.ContactAddresses.Any(x => x.Id == this.Addresses.SelectedItem.Id))
            {

                var newContactAddress  = this.ScreenData.ContactAddresses.AddNew();
                newContactAddress.Address = this.Addresses.SelectedItem;

            }
        }

        partial void SetPrimaryAddress_Execute()
        {
            // Write your code here.
            this.ContactAddresses.Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
            this.ContactAddresses.SelectedItem.Primary = true;
            SetContactAddressProperties();
        }



        
    }
}