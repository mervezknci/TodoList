using Entities;
using System.Data.Entity;

namespace DAL.Contexts
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> TodoEntities { get; set; }

        public TodoContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TodoContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
