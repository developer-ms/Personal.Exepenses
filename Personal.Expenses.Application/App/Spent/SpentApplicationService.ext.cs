using Common.Domain.Interfaces;
using Personal.Expenses.Application.Interfaces;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using Personal.Expenses.Domain.Interfaces.Services;
using Personal.Expenses.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using Common.Domain.Model;
using AutoMapper;

namespace Personal.Expenses.Application
{
    public class SpentApplicationService : SpentApplicationServiceBase
    {

        public SpentApplicationService(ISpentService service, IUnitOfWork uow, ICache cache, CurrentUser user, IMapper mapper) :
            base(service, uow, cache, user, mapper)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Spent> dataList)
        {
            return base.MapperDomainToResult<SpentDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
