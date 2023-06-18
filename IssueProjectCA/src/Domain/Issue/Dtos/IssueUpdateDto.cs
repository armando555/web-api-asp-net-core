namespace Domain.Issue.Dtos;
using Domain.Enums;

public class IssueUpdateDto
{
    public string Name { get;set; }
    public Priority Priority { get;set; }
}