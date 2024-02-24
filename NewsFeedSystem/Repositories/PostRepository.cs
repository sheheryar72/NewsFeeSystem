using Microsoft.Extensions.Configuration;
using NewsFeedSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace NewsFeedSystem.Repositories
{
    public class PostRepository
    {
        private readonly string _connectionString;
        public PostRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString["ConnectionString:NewsFeeSystem"];
        }
        public List<Posts> GetAllUser()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select p.User_ID, u.Username, p.Post_ID, p.Title, p.Description, p.Image_Url, p.Created_At from Posts p \r\ninner join Users u\r\non p.User_ID = u.User_ID";
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        List<Posts> userList = new List<Posts>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var Post = new Posts();
                            Post.User.User_ID = Convert.ToInt32(dt.Rows[i]["User_ID"]);
                            Post.User.Username = Convert.ToString(dt.Rows[i]["Username"]);
                            Post.Post_ID = Convert.ToInt32(dt.Rows[i]["Post_ID"]);
                            Post.Title = Convert.ToString(dt.Rows[i]["Title"]);
                            Post.Description = Convert.ToString(dt.Rows[i]["Description"]);
                            Post.Image_Url = Convert.ToString(dt.Rows[i]["Image_Url"]);
                            Post.Created_At = Convert.ToDateTime(dt.Rows[i]["Created_At"]);
                            userList.Add(Post);
                        }
                        conn.Close();
                        return userList;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public Posts GetUserById(int Id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select p.User_ID, u.Username, p.Post_ID, p.Title, p.Description, p.Image_Url, p.Created_At from Posts p \r\ninner join Users u\r\non p.User_ID = u.User_ID Where Post_ID = Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var Post = new Posts();
                        Post.User.User_ID = Convert.ToInt32(dt.Rows[o]["User_ID"]);
                        Post.User.Username = Convert.ToString(dt.Rows[0]["Username"]);
                        Post.Post_ID = Convert.ToInt32(dt.Rows[0]["Post_ID"]);
                        Post.Title = Convert.ToString(dt.Rows[0]["Title"]);
                        Post.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        Post.Image_Url = Convert.ToString(dt.Rows[0]["Image_Url"]);
                        Post.Created_At = Convert.ToDateTime(dt.Rows[0]["Created_At"]);
                        return Post;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public string AddUser(Posts Post)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into Posts (Title, Description, Image_Url, Created_At, User_ID) values (@Title, @Description, @Image_Url, @Created_At, @User_ID) select @@IDentity()";
                    cmd.Parameters.AddWithValue("@Title", Post.Title);
                    cmd.Parameters.AddWithValue("@Description", Post.Description);
                    cmd.Parameters.AddWithValue("@Image_Url", Post.Image_Url);
                    cmd.Parameters.AddWithValue("@User_ID", Post.User.User_ID);
                    cmd.Parameters.AddWithValue("@Created_At", Post.Created_At);
                    conn.Open();
                    int rawAffected = cmd.ExecuteNonQuery();

                    if (rawAffected > 0)
                    {
                        return Post.Post_ID.ToString();
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
        public string EditUser(Posts Post)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Update Posts Set Title = @Title, Description = @Description, Image_Url = @Image_Url, Created_At = @Created_At where Post_ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", Post.Post_ID);
                    cmd.Parameters.AddWithValue("@Title", Post.Title);
                    cmd.Parameters.AddWithValue("@Description", Post.Description);
                    cmd.Parameters.AddWithValue("@Image_Url", Post.Image_Url);
                    cmd.Parameters.AddWithValue("@User_ID", Post.User.User_ID);
                    cmd.Parameters.AddWithValue("@Created_At", Post.Created_At);
                    conn.Open();
                    int rawAffected = cmd.ExecuteNonQuery();

                    if (rawAffected > 0)
                    {
                        return Post.Post_ID.ToString();
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
