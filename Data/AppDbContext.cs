using Microsoft.EntityFrameworkCore;
using testAPI_2.Models;

namespace testAPI_2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");
    }
}