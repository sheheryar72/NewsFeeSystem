using NewsFeedSystem.Models;
using System.Collections.Generic;

namespace NewsFeedSystem.IServices
{
    public interface IUserService
    {
        public List<Users> GetAllUser();
        public Users GetUserById(int Id);
        public string AddUser(Users user);
        public string EditUser(Users user);
    }
}
