using Domain.Issue;
using Domain.Issue.Dtos;

namespace Application.Issue;

using Domain.Issue.Repositories;
using Domain.Issue.Entities;
    
public class IssueProcess: IIssueProcess
{
    private readonly IIssueRepository _issueRepository;
    public IssueProcess(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }
    public async Task<int> AddIssueAsync(Issue issue)
    {
        return await _issueRepository.AddIssueAsync(issue);
    }

    public async Task<int> UpdateIssueAsync(Issue issue, IssueUpdateDto issueUpdateDto)
    {
        issue.Update(issueUpdateDto);
        
        return await _issueRepository.UpdatedIssueAsync(issue);
    }

    public async Task<Issue?> GetIssueByIdAsync(int id)
    {
        return await _issueRepository.GetIssueByIdAsync(id);
    }

    public async Task<IList<Issue?>> GetIssuesAsync()
    {
        return await _issueRepository.GetIssuesAsync();
    }

    public async Task<int> DeleteIssueASync(int id)
    {
        var issue = await _issueRepository.GetIssueByIdAsync(id);
        if (issue is null)
        {
            return 0;
        }
        return await _issueRepository.DeleteIssueAsync(issue);
    }
}