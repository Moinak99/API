using System;
using System.Collections;
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
            ArrayList arlists= new ArrayList();
            IDictionary<string, string> vals;
            var posts = new List<BlogPost>();
            using (reader)
            {
               
                while (await reader.ReadAsync())
                {
                    vals = new Dictionary<string, string>();
                    for(int i =0; i< reader.FieldCount; i++)
                    {
                        var a = reader.GetName(i).ToString() + ":" + reader.GetValue(i).ToString();
                        vals.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());


                    }

                    arlists.Add(vals);
                   
                }

                

            }
            return posts;
        }
    }
}