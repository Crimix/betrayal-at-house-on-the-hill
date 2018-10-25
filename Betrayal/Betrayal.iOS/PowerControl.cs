using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Betrayal.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(PowerControl))]
namespace Betrayal.iOS
{
    public class PowerControl : IPowerControl
    {
        public void PreventSleep()
        {
            UIApplication.SharedApplication.IdleTimerDisabled = true;
        }
    }
}