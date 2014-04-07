using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LightSwitchApplication
{
    public partial class CaseManagementDataService
    {
        partial void Cases_Inserting(c_Case entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedOnUtc = System.DateTime.UtcNow;
            entity.LastUpdatedOnUtc = System.DateTime.UtcNow;
            entity.Address.Id = Guid.NewGuid();
            entity.Person.Id = Guid.NewGuid();
        }
    }
}
