namespace Domain.Issue.Dtos;
using Domain.Enums;

public class IssueDto
{
    public string Email { get;set; }
    public string Name { get;set; }
    public Priority Priority { get;set; }
}