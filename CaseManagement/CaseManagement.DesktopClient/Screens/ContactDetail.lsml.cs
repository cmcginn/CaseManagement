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
        #region Email Addresses
        void SetContactPrimaryEmailAddress()
        {

            var primary = ScreenData.ContactEmailAddresses.FirstOrDefault(x => x.Primary);
            if (primary == null)
            {
                //primary.Primary = true;
                //this.PrimaryContactEmailAddress = primary;
                primary = ScreenData.ContactEmailAddresses.FirstOrDefault();
                if (primary != null)
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

        #endregion

        #region Phone Numbers
        void SetContactPrimaryPhoneNumber()
        {
            var primary = ScreenData.ContactPhoneNumbers.FirstOrDefault(x => x.Primary);
            if (primary == null)
            {
                primary = ScreenData.ContactPhoneNumbers.FirstOrDefault();
                if (primary != null)
                {
                    primary.Primary = true;
                    this.PrimaryContactPhoneNumber = primary;
                }
            }
            else
            {
                this.PrimaryContactPhoneNumber = primary;
            }
        }
        partial void ContactPhoneNumbersAddAndEditNew_Execute()
        {
            // Write your code here.
            this.ContactPhoneNumberEdit = this.ContactPhoneNumbers.AddNew();
            this.OpenModalWindow("ContactPhoneNumberEditModal");
        }
        partial void SaveContactPhoneNumber_Execute()
        {
            // Write your code here.
            if (this.ContactPhoneNumberEdit.Primary)
            {
                this.ContactPhoneNumbers.Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
                this.ContactPhoneNumberEdit.Primary = true;
                SetContactPrimaryPhoneNumber();
            }
            this.CloseModalWindow("ContactPhoneNumberEditModal");

        }
        partial void PrimaryContactPhoneNumber_Changed()
        {
            var selected = this.PrimaryContactPhoneNumber;
            var primary = this.ContactPhoneNumbers.FirstOrDefault(x => x.Primary);
            if (selected != primary)
            {
                this.ContactPhoneNumbers.Except(new List<ContactPhoneNumber> { selected }).Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
                this.PrimaryContactPhoneNumber.Primary = true;
            }

        }
        partial void CancelContactPhoneNumberEdit_Execute()
        {
            // Write your code here.
            this.ContactPhoneNumberEdit.Details.DiscardChanges();
            this.CloseModalWindow("ContactPhoneNumberEditModal");
        }
        #endregion

        #region Addresses
        void SetContactPrimaryAddress()
        {
            var primary = ScreenData.ContactAddresses.FirstOrDefault(x => x.Primary);
            if (primary == null)
            {
                primary = ScreenData.ContactAddresses.FirstOrDefault();
                if (primary != null)
                {
                    primary.Primary = true;
                    this.PrimaryContactAddress = primary;
                }
            }
            else
            {
                this.PrimaryContactAddress = primary;
            }
        }
        partial void SaveContactAddress_Execute()
        {
            // Write your code here.
            if (this.ContactAddressEdit.Primary)
            {
                this.ContactAddresses.Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
                this.ContactAddressEdit.Primary = true;
                SetContactPrimaryAddress();
            }
            this.CloseModalWindow("ContactAddressEditModal");

        }

        partial void CancelContactAddressEdit_Execute()
        {
            // Write your code here.
            this.ContactAddressEdit.Details.DiscardChanges();
            this.CloseModalWindow("ContactAddressEditModal");
        }

        partial void PrimaryContactAddress_Changed()
        {
            var selected = this.PrimaryContactAddress;
            var primary = this.ContactAddresses.FirstOrDefault(x => x.Primary);
            if (selected != primary)
            {
                this.ContactAddresses.Except(new List<ContactAddress> { selected }).Where(x => x.Primary).ToList().ForEach(x => x.Primary = false);
                this.PrimaryContactAddress.Primary = true;
            }
        }
        partial void ContactAddressesAddAndEditNew_Execute()
        {
            // Write your code here.
            this.ContactAddressEdit = this.ContactAddresses.AddNew();
            this.OpenModalWindow("ContactAddressEditModal");
        }
        #endregion

        #region Contact
        partial void Contact_Loaded(bool succeeded)
        {
            this.ScreenData = this.Contact ?? this.DataWorkspace.ApplicationData.Contacts.AddNew();
            this.SetDisplayNameFromEntity(this.ScreenData);


            SetContactPrimaryAddress();
            SetContactPrimaryPhoneNumber();
            SetContactPrimaryEmailAddress();
        }

        partial void ContactDetail_Saving(ref bool handled)
        {
            // Write your code here.
            if (this.ContactEmailAddresses.Any(x => x.Primary) == false && this.ContactEmailAddresses.Any())
                this.ContactEmailAddresses.OrderByDescending(x => x.Modified).First().Primary = true;

            if (this.ContactPhoneNumbers.Any(x => x.Primary) == false && this.ContactPhoneNumbers.Any())
                this.ContactPhoneNumbers.OrderByDescending(x => x.Modified).First().Primary = true;

            if (this.ContactAddresses.Any(x => x.Primary) == false && this.ContactAddresses.Any())
                this.ContactAddresses.OrderByDescending(x => x.Modified).First().Primary = true;

        }

        partial void ContactDetail_Saved()
        {
            // Write your code here.
            Application.RaiseContactSavedEvent();
            this.Close(false);
        }
        #endregion


















      


  






















    }
}