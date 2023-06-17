using Microsoft.EntityFrameworkCore;
using web_api_asp_net_core.Models;

namespace web_api_asp_net_core.Data{
    public class IssueDbContext: DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            :base(options)
        {

        }

        public DbSet<Issue> Issues{ get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        }
    }
}