using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace BlogPostApi
{
    public class BlogPost
    {
        public dynamic Id { get; set; }
        public dynamic Title { get; set; }
        public dynamic Content { get; set; }
      

        internal AppDb Db { get; set; }

        public BlogPost()
        {
        }

        internal BlogPost(AppDb db)
        {
            Db = db;
        }

    }
}