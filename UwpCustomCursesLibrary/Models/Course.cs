﻿using System;
using System.Collections.Generic;

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
        public string UsersPoints { get; set; }
        public string SubscribedUsers { get; set; }
    }
}
