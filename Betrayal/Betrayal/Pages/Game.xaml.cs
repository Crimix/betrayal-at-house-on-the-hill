using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Betrayal.Resx;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Betrayal.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        private Character character;

        private int currentSpeed = -1;
        private int currentMight = -1;
        private int currentSanity = -1;
        private int currentKnowlagde = -1;

        public Game()
        {
            InitializeComponent();
            canvas.PaintSurface += Canvas_PaintSurface;
            int id = 0;
            bool error = false;
            try
            {
                id = (int)DataStore.Get(DataStoreKeys.Keys.Character_ID);
            }
            catch (Exception)
            {
                error = true;
                DisplayAlert(AppResources.confirm, AppResources.sure, AppResources.yes);
            }

            if (!error)
                character = App.characters.Find(x => x.ID == id);

            if(character != null)
            {
                if (DataStore.Get(DataStoreKeys.Keys.Current_Might) == null)
                    currentMight = character.Base_Might_Index;
                else
                    currentMight = (int)DataStore.Get(DataStoreKeys.Keys.Current_Might);

                if (DataStore.Get(DataStoreKeys.Keys.Current_Speed) == null)
                    currentSpeed = character.Base_Speed_Index;
                else
                    currentSpeed = (int)DataStore.Get(DataStoreKeys.Keys.Current_Speed);

                if (DataStore.Get(DataStoreKeys.Keys.Current_Sanity) == null)
                    currentSanity = character.Base_Sanity_Index;
                else
                    currentSanity = (int)DataStore.Get(DataStoreKeys.Keys.Current_Sanity);

                if (DataStore.Get(DataStoreKeys.Keys.Current_Knowledge) == null)
                    currentKnowlagde = character.Base_Knowledge_Index;
                else
                    currentKnowlagde = (int)DataStore.Get(DataStoreKeys.Keys.Current_Knowledge);
            }
        }


        private void Canvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            if (character != null)
            {
                Assembly assembly = GetType().GetTypeInfo().Assembly;
                string[] images = new string[5];
                images[0] = character.Image;
                images[1] = "Betrayal.Resources.overlays.speed_"+ currentSpeed+ ".png";
                images[2] = "Betrayal.Resources.overlays.might_" + currentMight + ".png";
                images[3] = "Betrayal.Resources.overlays.sanity_" + currentSanity + ".png";
                images[4] = "Betrayal.Resources.overlays.knowledge_" + currentKnowlagde + ".png";

                foreach (string s in images)
                {
                    if(!string.IsNullOrWhiteSpace(s))
                        using (Stream stream = assembly.GetManifestResourceStream(s))
                        {
                            SKBitmap resourceBitmap = SKBitmap.Decode(stream);
                            var pictureFrame = info.Rect;
                            var imageSize = resourceBitmap.Info.Size;
                            var dest = pictureFrame.AspectFit(imageSize); // fit the size inside the rect

                            // draw the image
                            var paint = new SKPaint
                            {
                                FilterQuality = SKFilterQuality.High // high quality scaling
                            };
                            canvas.DrawBitmap(resourceBitmap, dest, paint);
                    }
                }

            }
        }

        async private void Restart_Button_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.confirm, AppResources.surenewgame, AppResources.yes, AppResources.no);
            if (answer)
            {
            }
        }

        private void Reset_Button_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
        }

        private void Info_Button_Clicked(object sender, EventArgs e)
        {

        }

    }
}