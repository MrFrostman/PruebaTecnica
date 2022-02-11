using LoginWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Article> Articles { get; set; }
    }

}

