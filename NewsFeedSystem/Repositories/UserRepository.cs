using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using NewsFeedSystem.IRepositories;
using NewsFeedSystem.Models;
using System.Data.SqlClient;

namespace NewsFeedSystem.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString["ConnectionString:NewsFeeSystem"];
        }
        public List<Users> GetAllUser()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * from Users";
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        List<Users> userList = new List<Users>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var user = new Users();
                            user.User_ID = Convert.ToInt32(dt.Rows[i]["User_ID"]);
                            user.Username = Convert.ToString(dt.Rows[i]["Username"]);
                            user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                            user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                            user.Created_At = Convert.ToDateTime(dt.Rows[i]["Created_at"]);
                            userList.Add(user);
                        }
                        conn.Close();
                        return userList;
                    }
                    return null;
                }
                catch(Exception e)
                {
                    throw;
                }
            }
        }
        public Users GetUserById(int Id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * from Users Where User_ID = @id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var user = new Users();
                        user.User_ID = Convert.ToInt32(dt.Rows[0]["User_ID"]);
                        user.Username = Convert.ToString(dt.Rows[0]["Username"]);
                        user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                        user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                        user.Created_At = Convert.ToDateTime(dt.Rows[0]["Created_at"]);
                        return user;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public string AddUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into Users (Username, Email, Password, Created_At) values (@Username, @Email, @Password, @Created_At) select @@IDentity()";
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Created_At", user.Created_At);
                    conn.Open();
                    int rawAffected = cmd.ExecuteNonQuery();

                    if (rawAffected > 0)
                    {
                        return user.Username;
                        conn.Close();
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public string EditUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Update Users Set Username = @Username, Email = @Email, Password = @Password, Created_At = @Created_At where User_ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", user.User_ID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Created_At", user.Created_At);
                    conn.Open();
                    int rawAffected = cmd.ExecuteNonQuery();

                    if (rawAffected > 0)
                    {
                        return user.User_ID.ToString();
                        conn.Close();
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}
