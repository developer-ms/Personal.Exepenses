using Common.Domain.Interfaces;
using Personal.Expenses.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Personal.Expenses.Application.Interfaces
{
    public interface ISpentApplicationServiceBase : IApplicationServiceBase<SpentDto>
    {

    }
}
