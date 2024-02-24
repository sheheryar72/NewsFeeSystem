using NewsFeedSystem.Models;
using System.Collections.Generic;

namespace NewsFeedSystem.IServices
{
    public interface IPostService
    {
        public List<Posts> GetAllPost();
        public Posts GetPostById(int Id);
        public string AddPost(Posts post);
        public string EditPost(Posts post);
    }
}
