using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betrayal.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Betrayal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Game : ContentPage
	{
		public Game ()
		{
			InitializeComponent ();
		}

        async private void Restart_Button_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.confirm, AppResources.surenewgame, AppResources.yes, AppResources.no);
            if (answer)
            {
            }
        }
    }
}