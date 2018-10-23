using System;
using System.Collections.Generic;
using System.Text;
using static Betrayal.Colors;

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
    }
}
