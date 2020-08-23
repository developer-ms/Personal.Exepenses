using Common.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Personal.Expenses.Application.Interfaces;
using Personal.Expenses.Domain.Filter;
using Personal.Expenses.Dto;
using Personal.Expenses.CrossCuting;
using System;

namespace Personal.Expenses.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SpentController : ControllerBase<SpentDto>
    {
        public SpentController(ISpentApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
            : base(app, logger, env, new ErrorMapCustom())
        {



        }

        [Authorize(Policy = "CanReadAll")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SpentFilter filters)
        {
            return await base.Get<SpentFilter>(filters, "Personal.Expenses - Spent");
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CanReadOne")]
        public async Task<IActionResult> Get(int id, [FromQuery] SpentFilter filters)
        {
            if (id.IsSent()) filters.SpentId = id;
            return await base.GetOne(filters, "Personal.Expenses - Spent");
        }

        [Authorize(Policy = "CanSave")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SpentDtoSpecialized dto)
        {
            return await base.Post(dto, "Personal.Expenses - Spent");
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SpentDtoSpecialized dto)
        {
            return await base.Put(dto, "Personal.Expenses - Spent");
        }
        [Authorize(Policy = "CanDelete")]
        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, SpentDtoSpecialized dto)
        {
            if (id.IsSent()) dto.SpentId = id;
            return await base.Delete(dto, "Personal.Expenses - Spent");
        }
    }
}
