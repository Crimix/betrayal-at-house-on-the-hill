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
        private int currentKnowledge = -1;

        private int max = 7;
        private int min = -1;

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
                    currentKnowledge = character.Base_Knowledge_Index;
                else
                    currentKnowledge = (int)DataStore.Get(DataStoreKeys.Keys.Current_Knowledge);
            }
            DependencyService.Get<IPowerControl>().PreventSleep();
            DisableControls();
            EnableControls();
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
                images[4] = "Betrayal.Resources.overlays.knowledge_" + currentKnowledge + ".png";

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
                EnableControls();
            }
        }

        private void EnableControls()
        {
            Console.WriteLine(currentSpeed);
            if(currentSpeed != max)
                speedPlus.IsEnabled = true;
            if (currentSpeed != min)
                speedMinus.IsEnabled = true;
            if (currentMight != max)
                mightPlus.IsEnabled = true;
            if (currentMight != min)
                mightMinus.IsEnabled = true;
            if (currentSanity != max)
                sanityPlus.IsEnabled = true;
            if (currentSanity != min)
                sanityMinus.IsEnabled = true;
            if (currentKnowledge != max)
                knowledgePlus.IsEnabled = true;
            if (currentKnowledge != min)
                knowledgeMinus.IsEnabled = true;
        }

        private void DisableControls()
        {
            speedPlus.IsEnabled = false;
            speedMinus.IsEnabled = false;
            mightPlus.IsEnabled = false;
            mightMinus.IsEnabled = false;
            sanityPlus.IsEnabled = false;
            sanityMinus.IsEnabled = false;
            knowledgePlus.IsEnabled = false;
            knowledgeMinus.IsEnabled = false;
        }

        private void Speed_Plus(object sender, EventArgs e)
        {
            if (currentSpeed < max)
            {
                currentSpeed++;
                DataStore.Save(DataStoreKeys.Keys.Current_Speed, currentSpeed);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Speed_Minus(object sender, EventArgs e)
        {
            if (currentSpeed > min)
            {
                currentSpeed--;
                DataStore.Save(DataStoreKeys.Keys.Current_Speed, currentSpeed);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Might_Plus(object sender, EventArgs e)
        {
            if (currentMight < max)
            {
                currentMight++;
                DataStore.Save(DataStoreKeys.Keys.Current_Might, currentMight);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Might_Minus(object sender, EventArgs e)
        {
            if (currentMight > min)
            {
                currentMight--;
                DataStore.Save(DataStoreKeys.Keys.Current_Might, currentMight);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Sanity_Plus(object sender, EventArgs e)
        {
            if (currentSanity < max)
            {
                currentSanity++;
                DataStore.Save(DataStoreKeys.Keys.Current_Sanity, currentSanity);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Sanity_Minus(object sender, EventArgs e)
        {
            if (currentSanity > min)
            {
                currentSanity--;
                DataStore.Save(DataStoreKeys.Keys.Current_Sanity, currentSanity);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Knowledge_Plus(object sender, EventArgs e)
        {
            if (currentKnowledge < max)
            {
                currentKnowledge++;
                DataStore.Save(DataStoreKeys.Keys.Current_Knowledge, currentKnowledge);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        private void Knowledge_Minus(object sender, EventArgs e)
        {
            if (currentKnowledge > min)
            {
                currentKnowledge--;
                DataStore.Save(DataStoreKeys.Keys.Current_Knowledge, currentKnowledge);
                DisableControls();
                Device.BeginInvokeOnMainThread(() => { canvas.InvalidateSurface(); });
            }
        }

        async private void NewGame_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(AppResources.confirm, AppResources.surenewgame, AppResources.yes, AppResources.no);
            if (answer)
            {
                DataStore.Remove(DataStoreKeys.Keys.Character_ID);
                DataStore.Remove(DataStoreKeys.Keys.Current_Knowledge);
                DataStore.Remove(DataStoreKeys.Keys.Current_Might);
                DataStore.Remove(DataStoreKeys.Keys.Current_Sanity);
                DataStore.Remove(DataStoreKeys.Keys.Current_Speed);
                App.Current.MainPage = new NavigationPage(new ColorSelector());
            }
        }
    }
}