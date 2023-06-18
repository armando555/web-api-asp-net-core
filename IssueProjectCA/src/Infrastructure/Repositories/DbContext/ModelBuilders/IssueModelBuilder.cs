using Domain.Issue.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DbContext.ModelBuilders;

public static class IssueModelBuilder
{
    public static void MapIssue(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Issue>(i =>
        {
            i.Property(o=> o.Id).ValueGeneratedOnAdd();
            i.Property(o => o.Name).HasMaxLength(60).IsRequired();
            i.Property(o => o.Email).HasMaxLength(100).IsRequired();
            i.HasKey(o => new { o.Email, o.Id});
        });
    }
}