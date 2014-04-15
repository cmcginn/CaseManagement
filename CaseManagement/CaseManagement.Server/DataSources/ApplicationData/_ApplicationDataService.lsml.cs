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


        partial void Contacts_Validate(Contact entity, EntitySetValidationResultsBuilder results)
        {
            if(entity.ContactAddresses.Count(x=>x.Primary)>1)
                results.AddEntityError("Only one primary contact address is allowed.");
            if (entity.ContactEmailAddresses.Count(x => x.Primary) > 1)
                results.AddEntityError("Only one primary contact email address is allowed.");
            if (entity.ContactPhoneNumbers.Count(x => x.Primary) > 1)
                results.AddEntityError("Only one primary contact phone number is allowed.");
            if(String.IsNullOrEmpty(entity.FirstName) && String.IsNullOrEmpty(entity.LastName) && String.IsNullOrEmpty(entity.Company))
                results.AddEntityError("First Name and Last Name, or Company must be specified.");
            else if(String.IsNullOrEmpty(entity.Company))
            {
                if(String.IsNullOrEmpty(entity.FirstName))
                    results.AddEntityError("Contact First Name must be specified.");
                if(string.IsNullOrEmpty(entity.LastName))
                    results.AddEntityError("Contact Last Name must be specified.");
            }
        }
    }
}
