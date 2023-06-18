using Domain.Issue.Entities;
using Infrastructure.Repositories.DbContext.ModelBuilders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories.DbContext;

public class IssueContext: Microsoft.EntityFrameworkCore.DbContext
{
    public IssueContext(DbContextOptions<IssueContext> options)
        : base(options)
    {
    }

    public DbSet<Issue> Issues { get;set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.MapIssue();
    }


}