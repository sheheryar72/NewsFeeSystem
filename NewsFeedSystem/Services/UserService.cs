using Microsoft.Extensions.Configuration;
using NewsFeedSystem.IRepositories;
using NewsFeedSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace NewsFeedSystem.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<Users> GetAllUser()
        {
            return _userRepository.GetgetAllUser();
        }
        public Users GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }
        public string AddUser(Users user)
        {
            return _userRepository.AddUser(user);
        }
        public string EditUser(Users user)
        {
            return _userRepository.EditUser(user);
        }
    }
}
