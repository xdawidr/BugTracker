using BugTracker.Application.Projects.Commands.CreateProject;
using BugTracker.Application.Projects.Commands.DeleteProject;
using BugTracker.Application.Projects.Queries.GetProjectDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetProjectDetailQuery() { ProjectId = id });
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(DeleteProjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
