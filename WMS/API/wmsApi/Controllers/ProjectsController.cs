using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Projects;
using Microsoft.AspNetCore.Mvc;

namespace wmsApi.Controllers
{

    public class ProjectsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetProjects([FromQuery] ProjectParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }
    }
}