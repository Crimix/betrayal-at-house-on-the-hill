using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Betrayal.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(PowerControl))]
namespace Betrayal.Droid
{
    public class PowerControl : IPowerControl
    {
        public void PreventSleep()
        {
            Window window = (Forms.Context as Activity).Window;
            window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
        }
    }
}