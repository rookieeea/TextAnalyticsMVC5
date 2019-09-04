using System.Data.Entity;

namespace DemoTwitterSA.Models
{
    public class TweetContext : DbContext
    {
        public TweetContext()
        {

        }

        public DbSet<TweetResult> TweetResults { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}