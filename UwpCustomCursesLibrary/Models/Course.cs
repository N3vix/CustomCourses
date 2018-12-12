using System;

namespace UwpCustomCursesLibrary.Models
{
    public class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
        public string Lector { get; set; }
        public int MaximumSubs { get; set; }
        public User[] SubscribedUsers { get; set; }
    }
}
