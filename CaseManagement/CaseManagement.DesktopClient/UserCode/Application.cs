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
    public partial class Application
    {
        public delegate void ContactSavedEvent();
        public event ContactSavedEvent ContactSaved;
        public void RaiseContactSavedEvent()
        {
            if (ContactSaved == null)
                return;
            if (this.Details.Dispatcher.CheckAccess())
                ContactSaved();
            else
                this.Details.Dispatcher.BeginInvoke(() => ContactSaved());
        }
    }
}
