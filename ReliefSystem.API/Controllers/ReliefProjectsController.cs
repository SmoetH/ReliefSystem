using Microsoft.AspNetCore.Mvc;
using ReliefSystem.API.Models;

namespace ReliefSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReliefProjectsController : ControllerBase
    {
        private static readonly List<ReliefProject> Projects = new()
        {
            new ReliefProject { ProjectID = 1, ProjectName = "KZN Flood Relief", Location = "Durban, KZN", TargetBudget = 500000, CurrentRaised = 320000, Status = "Active" },
            new ReliefProject { ProjectID = 2, ProjectName = "JHB Fire Support", Location = "JHB South", TargetBudget = 150000, CurrentRaised = 150000, Status = "Completed" }
        };

        [HttpGet]
        public IActionResult GetProjects()
        {
            return Ok(Projects);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ReliefProject newProject)
        {
            if (newProject.TargetBudget <= 0)
                return BadRequest("Target budget must be greater than zero.");

            newProject.ProjectID = Projects.Count + 1;
            Projects.Add(newProject);
            return CreatedAtAction(nameof(GetProjects), new { id = newProject.ProjectID }, newProject);
        }
    }
}