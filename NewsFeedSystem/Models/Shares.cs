using System;

namespace NewsFeedSystem.Models
{
    public class Shares
    {
        public int Share_ID { get; set; }
        public int User_ID { get; set; }
        public int Post_ID { get; set; }
        public DateTime Created_At { get; set; }
    }
}
