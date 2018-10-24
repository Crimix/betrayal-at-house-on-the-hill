using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Betrayal.Colors.Color;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Betrayal.Resx;

namespace Betrayal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterSelector : ContentPage
	{
		public CharacterSelector (Color color)
		{
			InitializeComponent ();
            List<Character> characters = App.characters.FindAll(x => x.Color == color);
            listView.ItemsSource = characters;
        }

        async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e?.Item != null)
            {
                var answer = await DisplayAlert(AppResources.confirm, string.Format(AppResources.confirmcharacter, ((Character)e.Item).Name), AppResources.yes, AppResources.no);
                if (answer)
                {
                    DataStore.Save(DataStoreKeys.Keys.Character_ID, ((Character)e.Item).ID);
                    App.Current.MainPage = new NavigationPage(new Game());
                }

            }
        }
    }
}