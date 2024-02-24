using Microsoft.Extensions.Configuration;
using NewsFeedSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace NewsFeedSystem.Repositories
{
    public class CommentRepository
    {
        private readonly string _connectionString;
        public CommentRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString["ConnectionString:NewsFeeSystem"];
        }
    }
}
