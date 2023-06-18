using Application.Issue;
using Domain.Issue;
using Domain.Issue.Dtos;
using Domain.Issue.Entities;

namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class IssueController: ControllerBase
{
    private readonly IIssueProcess _issueProcess;
    private readonly ILogger<IssueController> _logger;
    public IssueController(ILogger<IssueController> iLogger, IIssueProcess issueProcess)
    {
        _issueProcess = issueProcess;
        _logger = iLogger;
    }

    [HttpGet]
    public async Task<IEnumerable<Issue?>> Get() => await _issueProcess.GetIssuesAsync();
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var issue = await _issueProcess.GetIssueByIdAsync(id);
        return issue == null ? NotFound() : Ok(issue);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Issue), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(IssueDto issue)
    {
        var id = await _issueProcess.AddIssueAsync(Issue.FromIssueDtoToIssue(issue));
        return CreatedAtAction(nameof(GetById), new { id}, id);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Issue), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(IssueUpdateDto issueUpdateDto,int id)
    {
        var issue = await _issueProcess.GetIssueByIdAsync(id);
        if (issue is null)
        {
            return NotFound();
        }
        await _issueProcess.UpdateIssueAsync(issue,issueUpdateDto);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Issue), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _issueProcess.DeleteIssueASync(id);
        return NoContent();
    }
}