using BugTracker.Application.Bugs.Commands.CreateBug;
using BugTracker.Application.Bugs.Commands.DeleteBug;
using BugTracker.Application.Bugs.Commands.UpdateBug;
using BugTracker.Application.Bugs.Queries.GetBugDetail;
using BugTracker.Application.Projects.Commands.DeleteProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    [Route("api/bugs")]
    [Authorize]
    public class BugsController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BugDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetBugDetailQuery() { BugId = id });
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBug(CreateBugCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBug(UpdateBugCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBug(DeleteBugCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
