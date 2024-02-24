using NewsFeedSystem.IRepositories;
using NewsFeedSystem.Models;
using System.Collections.Generic;

namespace NewsFeedSystem.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public List<Posts> GetAllUser()
        {
            return _postRepository.GetAllPost();
        }
        public Posts GetPostById(int Id)
        {
            return _postRepository.GetPostById(Id);
        }
        public string AddPost(Posts post)
        {
            return _postRepository.AddPost(post);
        }
        public string EditPost(Posts post)
        {
            return _postRepository.EditPost(post);
        }
    }
}
