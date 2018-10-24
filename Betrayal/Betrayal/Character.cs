using System;
using System.Collections.Generic;
using System.Text;
using Betrayal.Resx;
using Xamarin.Forms;
using Color = Betrayal.Colors.Color;

namespace Betrayal
{
    public class Character
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int ID { get; set; }
        public int[] Speed { get; set; }
        public int[] Might { get; set; }
        public int[] Sanity { get; set; }
        public int[] Knowledge { get; set; }
        public int Base_Speed_Index { get; set; }
        public int Base_Might_Index { get; set; }
        public int Base_Sanity_Index { get; set; }
        public int Base_Knowledge_Index { get; set; }
        public DateTime Birthday { get; set; }
        public string Hobbies { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }

        public Character()
        {

        }

        public int GetDaysToBirthDay
        {
            get
            {
                DateTime today = DateTime.Today;
                DateTime next = Birthday.AddYears(today.Year - Birthday.Year);

                if (next < today)
                    next = next.AddYears(1);

                return (next - today).Days;
            }
        }

        public string FormattedBirthday
        {
            get
            {
                DateTime bd = Birthday.AddYears(-Age);

                return bd.ToString("d");
            }
        }

        public FormattedString FormattedMight
        {
            get
            {
                FormattedString fs = new FormattedString();
                fs.Spans.Add(new Span { Text = AppResources.might + ": [ " });
                int l = Might.Length;
                for(int i = 0; i < l; i++){
                    if(i == Base_Might_Index)
                    {
                        fs.Spans.Add(new Span { Text = Might[i].ToString() + " ", TextColor = Xamarin.Forms.Color.Green });
                    }
                    else
                    {
                        fs.Spans.Add(new Span { Text = Might[i].ToString() + " " });
                    }
                }
                fs.Spans.Add(new Span { Text = "]" });

                return fs;
            }
        }

        public FormattedString FormattedSpeed
        {
            get
            {
                FormattedString fs = new FormattedString();
                fs.Spans.Add(new Span { Text = AppResources.speed + ": [ " });
                int l = Speed.Length;
                for (int i = 0; i < l; i++)
                {
                    if (i == Base_Speed_Index)
                    {
                        fs.Spans.Add(new Span { Text = Speed[i].ToString() + " ", TextColor = Xamarin.Forms.Color.Green });
                    }
                    else
                    {
                        fs.Spans.Add(new Span { Text = Speed[i].ToString() + " " });
                    }
                }
                fs.Spans.Add(new Span { Text = "]" });

                return fs;
            }
        }

        public FormattedString FormattedSanity
        {
            get
            {
                FormattedString fs = new FormattedString();
                fs.Spans.Add(new Span { Text = AppResources.sanity + ": [ " });
                int l = Sanity.Length;
                for (int i = 0; i < l; i++)
                {
                    if (i == Base_Sanity_Index)
                    {
                        fs.Spans.Add(new Span { Text = Sanity[i].ToString() + " ", TextColor = Xamarin.Forms.Color.Green });
                    }
                    else
                    {
                        fs.Spans.Add(new Span { Text = Sanity[i].ToString() + " " });
                    }
                }
                fs.Spans.Add(new Span { Text = "]" });

                return fs;
            }
        }

        public FormattedString FormattedKnowledge
        {
            get
            {
                FormattedString fs = new FormattedString();
                fs.Spans.Add(new Span { Text = AppResources.knowledge + ": [ " });
                int l = Knowledge.Length;
                for (int i = 0; i < l; i++)
                {
                    if (i == Base_Knowledge_Index)
                    {
                        fs.Spans.Add(new Span { Text = Knowledge[i].ToString() + " ", TextColor = Xamarin.Forms.Color.Green });
                    }
                    else
                    {
                        fs.Spans.Add(new Span { Text = Knowledge[i].ToString() + " " });
                    }
                }
                fs.Spans.Add(new Span { Text = "]" });

                return fs;
            }
        }
    }
}
