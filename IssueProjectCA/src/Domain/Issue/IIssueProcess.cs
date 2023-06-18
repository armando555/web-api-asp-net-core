using Domain.Issue.Dtos;

namespace Domain.Issue;
using Entities;

public interface IIssueProcess
{
    public Task<int> AddIssueAsync(Issue issue);

    public Task<int> UpdateIssueAsync(Issue issue, IssueUpdateDto issueUpdateDto);

    public Task<Issue?> GetIssueByIdAsync(int id);

    public Task<IList<Issue?>> GetIssuesAsync();

    public Task<int> DeleteIssueASync(int id);
}