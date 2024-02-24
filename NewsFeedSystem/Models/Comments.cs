using System;

namespace NewsFeedSystem.Models
{
    public class Comments
    {
        public int Comment_ID { get; set; }
        public int User_ID { get; set; }
        public int Post_ID { get; set; }
        public string Comment { get; set; }
        public DateTime Created_At { get; set; }
    }
}
