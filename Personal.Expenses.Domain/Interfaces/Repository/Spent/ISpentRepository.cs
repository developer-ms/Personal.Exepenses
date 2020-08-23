using Common.Domain.Interfaces;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal.Expenses.Domain.Interfaces.Repository
{
    public interface ISpentRepository : IRepository<Spent>, IRepositoryExtensions<Spent, SpentFilter>
    {

    }
}
