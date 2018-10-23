using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betrayal.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static Betrayal.Colors;
using Color = Betrayal.Colors.Color;

namespace Betrayal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorSelector : ContentPage
	{
        Dictionary<string, Color> colors = new Dictionary<string, Color>
            {
                { AppResources.blue, Color.BLUE },
                { AppResources.green, Color.GREEN },
                { AppResources.purple, Color.PURPLE },
                { AppResources.red, Color.RED },
                { AppResources.white, Color.WHITE },
                { AppResources.yellow, Color.YELLOW }
            };

        public ColorSelector ()
		{
			InitializeComponent ();

            listView.ItemsSource = colors.Keys;
        }

        async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e?.Item != null)
            {
                var answer = await DisplayAlert(AppResources.confirm, string.Format(AppResources.sure, e.Item), AppResources.yes, AppResources.no);
            }
        }
    }
}