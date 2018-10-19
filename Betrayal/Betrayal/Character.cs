using System;
using System.Collections.Generic;
using System.Text;

namespace Betrayal
{
    public class Character
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public int Base_Speed { get; private set; }
        public int Base_Might { get; private set; }
        public int Base_Sanity { get; private set; }
        public int Base_Knowledge { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Hobbies { get; private set; }
        public int Age { get; private set; }
        public string Height { get; private set; }
        public int Weight { get; private set; }

        public Character(string Name, int ID, int Base_Speed, int Base_Might, int Base_Sanity, int Base_Knowledge, DateTime Birthday, string Hobbies, int Age, string Height, int Weight)
        {

        }
    }
}
