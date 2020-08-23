using Common.Domain.Model;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using System.Linq;

namespace Personal.Expenses.Data.Repository
{
    public static class SpentOrderCustomExtension
    {

        public static IQueryable<Spent> OrderByDomain(this IQueryable<Spent> queryBase, SpentFilter filters)
        {
            return queryBase.OrderBy(_ => _.SpentId);
        }

    }
}

