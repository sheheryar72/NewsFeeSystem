using Microsoft.Extensions.Configuration;
using NewsFeedSystem.Models;
using System.Collections.Generic;

namespace NewsFeedSystem.IRepositories
{
    public interface IUserRepository
    {
        public List<Users> GetAllUser();
        public Users GetUserById(int Id);
        public string AddUser(Users user);
        public string EditUser(Users user);
    }
}
