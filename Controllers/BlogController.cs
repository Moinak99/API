using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace BlogPostApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        public BlogController(AppDb db)
        {
            Db = db;
        }

        // GET api/blog/5
        [HttpGet("{queryString}")]
        public async Task<IActionResult> GetOne(string queryString)
        {
            Console.WriteLine(queryString);
            string[] formattedString = queryString.Split('=');
            await Db.Connection.OpenAsync();
            var query = new BlogPostQuery(Db);
            //var result = await query.QueryExecute(formattedString[1]);
            //if (result is null)
            //    return new NotFoundResult();
            //return new OkObjectResult(result);

            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = formattedString[1];

            var result = await query.ReadAllAsync(await cmd.ExecuteReaderAsync());
            // return result.Count > 0 ? result : null;

            return Ok(result);
        }

        public AppDb Db { get; }
    }
}