using System;

namespace NewsFeedSystem.Models
{
    public class Posts
    {
        public int Post_ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image_Url { get; set; }
        public DateTime Created_At { get; set; }
        public Users User { get; set; }
    }
}
