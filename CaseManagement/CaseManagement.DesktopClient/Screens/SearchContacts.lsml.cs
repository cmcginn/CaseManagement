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
    public partial class SearchContacts
    {
        partial void gridAddAndEditNew_CanExecute(ref bool result)
        {
            // Write your code here.

        }

        partial void gridAddAndEditNew_Execute()
        {
            // Write your code here.
            Application.ShowContactDetail(null);
        }
    }
}
