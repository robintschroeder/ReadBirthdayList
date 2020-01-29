using System;

namespace ReadBirthdays.Models
{
    public class Item
    {
        public DateTime Birthday { get; set; }
        public string BirthdayDisplay { get { return Birthday.ToShortDateString(); } }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}