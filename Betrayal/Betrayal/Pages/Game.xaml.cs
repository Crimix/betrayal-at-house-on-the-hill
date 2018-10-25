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
                images[1] = "Betrayal.Resources.might_dead.png";

                foreach(string s in images)
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
            Console.WriteLine("reset");
        }

        private void Info_Button_Clicked(object sender, EventArgs e)
        {

        }

    }
}