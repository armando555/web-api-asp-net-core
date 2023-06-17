using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_asp_net_core.Data;
using web_api_asp_net_core.Models;
using System.Collections.Generic;

namespace web_api_asp_net_core.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController: ControllerBase
    {
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get() => await _context.Issues.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = issue.Id}, issue);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update(Issue issue,int id)
        {
            if (id != issue.Id) return BadRequest();
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);
            if (issueToDelete == null) return NotFound();
            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("bulk")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status201Created)]
        public async Task<IActionResult> Bulk(List<Issue> issues)
        {
            await _context.AddRangeAsync(issues);
            await _context.SaveChangesAsync();
            return Created("Creado en espanol",null);
            
        }
    }
}