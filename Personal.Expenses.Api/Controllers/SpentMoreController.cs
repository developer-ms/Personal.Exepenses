using Common.API;
using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Personal.Expenses.Application.Interfaces;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using Personal.Expenses.Domain.Interfaces.Repository;
using Personal.Expenses.Dto;
using Personal.Expenses.CrossCuting;


namespace Personal.Expenses.Api.Controllers
{
    [Authorize]
    [Route("api/Spent/more")]
    public class SpentMoreController : ControllerMoreBase<SpentDto, SpentFilter, Spent>
    {
        public SpentMoreController(ISpentRepository rep, ISpentApplicationService app, ILoggerFactory logger, EnviromentInfo env, CurrentUser user, ICache cache) 
            : base(rep, app, logger, env, user, cache, new ExportExcel<dynamic>(), new ErrorMapCustom())
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SpentFilter filters)
        {
            return await base.Get(filters,typeof(Spent).Name, "Personal.Expenses - Spent");
        }

        [Authorize(Policy = "CanWrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<SpentDtoSpecialized> dtos)
        {
            return await base.Post(dtos,  "Personal.Expenses - Spent");
        }

        [Authorize(Policy = "CanWrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<SpentDtoSpecialized> dtos)
        {
            return await base.Put(dtos, "Personal.Expenses - Spent");
        }

    }
}
