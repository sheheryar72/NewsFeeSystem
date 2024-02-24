using Microsoft.Extensions.Hosting;
using NewsFeedSystem.Models;
using System.Collections.Generic;

namespace NewsFeedSystem.IRepositories
{
    public interface IPostRepository
    {
        public List<Posts> GetAllPost();
        public Posts GetPostById(int Id);
        public string AddPost(Posts post);
        public string EditPost(Posts post);
    }
}
