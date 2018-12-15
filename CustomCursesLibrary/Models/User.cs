using System.Collections.Generic;

namespace CustomCursesLibrary.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string SubscribeCourses { get; set; }
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        User,
        Lector,
        Admin
    }
}