using Domain.Common;
using Domain.Enums;
using Domain.Issue.Dtos;

namespace Domain.Issue.Entities;

public class Issue: BaseAuditableEntity
{
    public string Email { get;set; }
    public string Name { get;set; }
    public Priority Priority { get;set; }
    
    public static Issue FromIssueDtoToIssue(IssueDto issueDto)
    {
        return new Issue
        {
            Email = issueDto.Email,
            Name = issueDto.Name,
            Priority = issueDto.Priority
        };
    }

    public void Update(IssueUpdateDto issueUpdateDto)
    {
        Name = issueUpdateDto.Name;
        Priority = issueUpdateDto.Priority;
        LastModified = DateTime.Now;
    }
}
