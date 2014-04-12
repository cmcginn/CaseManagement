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
      
        partial void ContactDetail_Created()
        {
            if (ContactId.HasValue)
                ScreenData = this.DataWorkspace.ApplicationData.Contacts_SingleOrDefault(ContactId.Value);
                   // Application.CreateDataWorkspace().ApplicationData.Contacts_SingleOrDefault(ContactId.Value);
            else
                ScreenData =  this.DataWorkspace.ApplicationData.Contacts.AddNew();
            //else

            this.SetDisplayNameFromEntity(this.ScreenData);

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

        
    }
}