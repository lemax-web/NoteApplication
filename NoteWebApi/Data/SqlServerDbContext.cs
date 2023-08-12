using Microsoft.EntityFrameworkCore;
using NoteWebApi.Model;

namespace RecipeWebApi.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
      : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
