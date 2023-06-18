namespace Domain.Issue.Repositories;

public interface IIssueRepository
{
    public Task<int> AddIssueAsync(Entities.Issue issue);
    public Task<Entities.Issue?> GetIssueByIdAsync(int id);
    public Task<IList<Entities.Issue?>> GetIssuesAsync();
    public Task<int> DeleteIssueAsync(Entities.Issue issue);
    public Task<int> UpdatedIssueAsync(Entities.Issue issue);
}
