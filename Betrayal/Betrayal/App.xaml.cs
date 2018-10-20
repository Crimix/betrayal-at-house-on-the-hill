using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = Betrayal.Colors.Color;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Betrayal
{
    public partial class App : Application
    {
        public static List<Character> characters = new List<Character>();

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        private void CreateCharacters()
        {
            characters.Add(new Character()
            {
                ID = 1,
                Name = "Madame Zostra",
                Age = 37,
                Birthday = new DateTime(DateTime.Now.Year, 12, 10),
                Color = Color.BLUE,
                Height = "5'0",
                Weight = 150,
                Hobbies = "Astrology, Cooking, Baseball",
                Speed = new[] { 2, 3, 3, 5, 5, 6, 6, 7 },
                Might = new[] { 2, 3, 3, 4, 5, 5, 5, 6 },
                Sanity = new[] { 4, 4, 4, 5, 6, 7, 8, 8 },
                Knowledge = new[] { 1, 3, 4, 4, 4, 5, 6, 6 },
                Base_Speed_Index = 2,
                Base_Might_Index = 3,
                Base_Sanity_Index = 2,
                Base_Knowledge_Index = 3
            });

            characters.Add(new Character()
            {
                ID = 2,
                Name = "Vivian Lopez",
                Age = 42,
                Birthday = new DateTime(DateTime.Now.Year, 1, 1),
                Color = Color.BLUE,
                Height = "5'5",
                Weight = 142,
                Hobbies = "Old Movies, Horses",
                Speed = new[] { 3, 4, 4, 4, 4, 6, 7, 8 },
                Might = new[] { 2, 2, 2, 4, 4, 5, 6, 6 },
                Sanity = new[] { 4, 4, 4, 5, 6, 7, 8, 8 },
                Knowledge = new[] { 4, 5, 5, 5, 5, 6, 6, 7 },
                Base_Speed_Index = 3,
                Base_Might_Index = 2,
                Base_Sanity_Index = 2,
                Base_Knowledge_Index = 3
            });

            characters.Add(new Character()
            {
                ID = 3,
                Name = "Brandon Jaspers",
                Age = 12,
                Birthday = new DateTime(DateTime.Now.Year, 5, 21),
                Color = Color.GREEN,
                Height = "5'1",
                Weight = 109,
                Hobbies = "Computers, Camping, Hockey",
                Speed = new[] { 3, 4, 4, 4, 5, 6, 7, 8 },
                Might = new[] { 2, 3, 3, 4, 5, 6, 6, 7 },
                Sanity = new[] { 3, 3, 3, 4, 5, 6, 7, 8 },
                Knowledge = new[] { 1, 3, 3, 5, 5, 6, 6, 7 },
                Base_Speed_Index = 2,
                Base_Might_Index = 3,
                Base_Sanity_Index = 3,
                Base_Knowledge_Index = 2
            });

            characters.Add(new Character()
            {
                ID = 4,
                Name = "Peter Akimboto",
                Age = 13,
                Birthday = new DateTime(DateTime.Now.Year, 9, 3),
                Color = Color.GREEN,
                Height = "4'11",
                Weight = 98,
                Hobbies = "Bugs, Basketball",
                Speed = new[] { 3, 3, 3, 4, 6, 6, 7, 7 },
                Might = new[] { 2, 3, 3, 4, 5, 5, 6, 8 },
                Sanity = new[] { 3, 4, 4, 4, 5, 6, 6, 7 },
                Knowledge = new[] { 3, 4, 4, 5, 6, 7, 7, 8 },
                Base_Speed_Index = 3,
                Base_Might_Index = 2,
                Base_Sanity_Index = 3,
                Base_Knowledge_Index = 2
            });

            characters.Add(new Character()
            {
                ID = 5,
                Name = "Heather Granville",
                Age = 18,
                Birthday = new DateTime(DateTime.Now.Year, 8, 2),
                Color = Color.PURPLE,
                Height = "5'2",
                Weight = 120,
                Hobbies = "Television, Shiopping",
                Speed = new[] { 3, 3, 4, 5, 6, 6, 7, 8 },
                Might = new[] { 3, 3, 3, 4, 5, 6, 7, 8 },
                Sanity = new[] { 3, 3, 3, 4, 5, 6, 6, 6 },
                Knowledge = new[] { 2, 3, 3, 4, 5, 6, 7, 8 },
                Base_Speed_Index = 2,
                Base_Might_Index = 2,
                Base_Sanity_Index = 2,
                Base_Knowledge_Index = 4
            });

            characters.Add(new Character()
            {
                ID = 6,
                Name = "Jenny LeClerc",
                Age = 21,
                Birthday = new DateTime(DateTime.Now.Year, 3, 4),
                Color = Color.PURPLE,
                Height = "5'7",
                Weight = 142,
                Hobbies = "Reading, Soccer",
                Speed = new[] { 2, 3, 4, 4, 4, 5, 6, 8 },
                Might = new[] { 3, 4, 4, 4, 4, 5, 6, 8 },
                Sanity = new[] { 1, 1, 2, 4, 4, 4, 5, 6 },
                Knowledge = new[] { 2, 3, 3, 4, 4, 5, 6, 8 },
                Base_Speed_Index = 3,
                Base_Might_Index = 2,
                Base_Sanity_Index = 4,
                Base_Knowledge_Index = 2
            });

            characters.Add(new Character()
            {
                ID = 7,
                Name = "Darrin \"Flash\" Williams",
                Age = 20,
                Birthday = new DateTime(DateTime.Now.Year, 6, 6),
                Color = Color.RED,
                Height = "5'11",
                Weight = 188,
                Hobbies = "Track, Music, Shakespearean Litterature",
                Speed = new[] { 4, 4, 4, 5, 6, 7, 7, 8 }, 
                Might = new[] { 2, 3, 3, 4, 5, 6, 6, 7 },
                Sanity = new[] { 1, 2, 3, 4, 5, 5, 5, 7 },
                Knowledge = new[] { 2, 3, 3, 4, 5, 5, 5, 7 },
                Base_Speed_Index = 4,
                Base_Might_Index = 2,
                Base_Sanity_Index = 2,
                Base_Knowledge_Index = 2
            });

            characters.Add(new Character()
            {
                ID = 8,
                Name = "Ox Bellows",
                Age = 23,
                Birthday = new DateTime(DateTime.Now.Year, 6, 6),
                Color = Color.RED,
                Height = "6'4",
                Weight = 288,
                Hobbies = "Football, Shiny Objects",
                Speed = new[] { 2, 2, 2, 3, 4, 5, 5, 6 },
                Might = new[] { 4, 5, 5, 6, 6, 7, 8, 8 },
                Sanity = new[] { 2, 2, 3, 4, 5, 5, 6, 7 },
                Knowledge = new[] { 2, 2, 3, 3, 5, 5, 6, 6 },
                Base_Speed_Index = 4,
                Base_Might_Index = 2,
                Base_Sanity_Index = 2,
                Base_Knowledge_Index = 2
            });

            characters.Add(new Character()
            {
                ID = 9,
                Name = "Professor Longfellow",
                Age = 57,
                Birthday = new DateTime(DateTime.Now.Year, 7, 27),
                Color = Color.WHITE,
                Height = "5'11",
                Weight = 153,
                Hobbies = "Gaelic Music, Drama, Fine Wines",
                Speed = new[] { 2, 2, 4, 4, 5, 5, 6, 6 },
                Might = new[] { 1, 2, 3, 4, 5, 5, 6, 6 },
                Sanity = new[] { 1, 3, 3, 4, 5, 5, 6, 7 },
                Knowledge = new[] { 4, 5, 5, 5, 5, 6, 7, 8 },
                Base_Speed_Index = 3,
                Base_Might_Index = 2,
                Base_Sanity_Index = 2,
                Base_Knowledge_Index = 4
            });
        }
    }
}
