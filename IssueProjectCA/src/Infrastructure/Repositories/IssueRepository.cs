using Domain.Issue.Entities;
using Domain.Issue.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class IssueRepository: IIssueRepository
{
    private readonly IssueContext _issueContext;

    public IssueRepository(IssueContext issueContext)
    {
        _issueContext = issueContext;
    }

    public async Task<int> AddIssueAsync(Issue issue)
    {
        if (issue is null)
        {
            throw new ArgumentNullException(nameof(issue),"Error the entity doesn't exist");
        }
        if ( string.IsNullOrEmpty( issue.Email ))
        {
            throw new ArgumentNullException(nameof(issue), "Error the email field is null");
        }
        await _issueContext.Issues.AddAsync(issue);
        await _issueContext.SaveChangesAsync();
        return issue.Id;
    }

    public async Task<Issue?> GetIssueByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentNullException(nameof(id), "Error the id is negative number");
        }

        return await _issueContext.Issues.FirstOrDefaultAsync(i => i.Id == id);
        
    }

    public async Task<IList<Issue?>> GetIssuesAsync()
    {
        return await _issueContext.Issues.ToListAsync();
    }

    public async Task<int> DeleteIssueAsync(Issue issue)
    {
        _issueContext.Issues.Remove(issue);
        return await _issueContext.SaveChangesAsync();
    }

    public async Task<int> UpdatedIssueAsync(Issue issue)
    {
        _issueContext.Entry(issue).State = EntityState.Modified; 
        return await _issueContext.SaveChangesAsync();
    }
}