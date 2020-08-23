using Common.Domain.Interfaces;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;

namespace Personal.Expenses.Domain.Interfaces.Services
{
    public interface ISpentService : IServiceBase<Spent, SpentFilter>
    {

        
    }
}
