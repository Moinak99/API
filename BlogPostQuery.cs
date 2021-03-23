using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace BlogPostApi
{
    public class BlogPostQuery
    {
        public AppDb Db { get; }

        public BlogPostQuery(AppDb db)
        {
            Db = db;
        }

        //public async Task<ActionResult> QueryExecute(string query)
        //{
        //    Console.WriteLine(query);
        //    using var cmd = Db.Connection.CreateCommand();
        //    cmd.CommandText = query;

        //    var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
        //    return Ok(result);
        //}

      

        public async Task<List<BlogPost>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<BlogPost>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new BlogPost(Db)
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Content = reader.GetString(2),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}