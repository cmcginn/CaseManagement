using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        partial void ContactAddresses_Inserting(ContactAddress entity)
        {
            if (entity.Contact.ContactAddresses.Count() == 1)
                entity.Primary = true;
        }

        partial void ContactEmailAddresses_Inserting(ContactEmailAddress entity)
        {
            if (entity.Contact.ContactEmailAddresses.Count() == 1)
                entity.Primary = true;
        }

        partial void ContactPhoneNumbers_Inserting(ContactPhoneNumber entity)
        {
            if (entity.Contact.ContactEmailAddresses.Count() == 1)
                entity.Primary = true;
        }
    }
}
