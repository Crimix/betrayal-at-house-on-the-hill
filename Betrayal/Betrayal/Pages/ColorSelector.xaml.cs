using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static Betrayal.Colors;
using Color = Betrayal.Colors.Color;

namespace Betrayal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorSelector : ContentPage
	{
		public ColorSelector ()
		{
			InitializeComponent ();
            Dictionary<Color, string> colors = new Dictionary<Color, string>
            {
                { Color.BLUE, "Blue" },
                { Color.GREEN, "Green" },
                { Color.PURPLE, "Purple" },
                { Color.RED, "Red" },
                { Color.WHITE, "White" },
                { Color.YELLOW, "Yellow" }
            };

            listView.ItemsSource = colors;
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine(e.Item);
        }
    }
}