using System;

namespace NewsFeedSystem.Models
{
    public class Users
    {
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created_At { get; set; }
    }
}
