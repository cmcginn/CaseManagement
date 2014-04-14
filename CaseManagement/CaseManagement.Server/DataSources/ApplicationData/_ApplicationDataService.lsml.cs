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

        //void SetPrimaryContactAddress(Contact contact)
        //{
        //    if (contact.ContactAddresses.Count() == 1)
        //        contact.ContactAddresses.First().Primary = true;
        //}
        //void SetPrimaryContactEmailAddress(Contact contact)
        //{
        //    if (contact.ContactEmailAddresses.Where(x=>x.Primary).Count() == 0 && contact.ContactEmailAddresses.Any())
        //        contact.ContactEmailAddresses.First().Primary = true;
        //}
        //void SetPrimaryContactPhoneNumber(Contact contact)
        //{
        //    if (contact.ContactPhoneNumbers.Count() == 1)
        //       contact.ContactPhoneNumbers.First().Primary = true;
        //}
        //partial void ContactAddresses_Inserting(ContactAddress entity)
        //{
        //    SetPrimaryContactAddress(entity.Contact);
        //}

        //partial void ContactEmailAddresses_Inserting(ContactEmailAddress entity)
        //{
        //    SetPrimaryContactEmailAddress(entity.Contact);
        //}

        //partial void ContactPhoneNumbers_Inserting(ContactPhoneNumber entity)
        //{
        //    SetPrimaryContactPhoneNumber(entity.Contact);
        //}

        //partial void ContactEmailAddresses_Deleting(ContactEmailAddress entity)
        //{
        //    SetPrimaryContactEmailAddress(entity.Contact);
        //}
        //partial void ContactEmailAddresses_Deleting(ContactEmailAddress entity)
        //{
        //    if(entity.Primary)
        //    {
        //        if(entity.Contact.ContactEmailAddresses.Except(entity).Where(x=>x.Primary).Count() == 0)
        //        {
        //            if (entity.Contact.ContactEmailAddresses.Except(entity).Count() > 0)
        //                entity.Contact.ContactEmailAddresses.Except(entity).First().Primary = true;
        //        }
        //    }

        //}

        partial void SaveChanges_Executed()
        {
            var x = "Y";
        }

        partial void ContactEmailAddresses_Inserting(ContactEmailAddress entity)
        {

        }

        //partial void ContactEmailAddresses_Deleting(ContactEmailAddress entity)
        //{
        //  if(entity.Primary)
        //  {
        //      //set first as primary if exists
        //      //if()
        //      //var x = "Y";
        //      var primary = entity.Contact.ContactEmailAddresses.Except(new List<ContactEmailAddress> {entity}).FirstOrDefault();
        //      if (primary != null)
        //          primary.Primary = true;
        //  }
        //}

        partial void ContactEmailAddresses_Validate(ContactEmailAddress entity, EntitySetValidationResultsBuilder results)
        {
            if (entity.Contact.ContactEmailAddresses.Count(x => x.Primary) > 1)
                results.AddEntityError("Only one primary contact email address is allowed.");
        }
    }
}
