using Common.Domain.Model;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using System.Linq;

namespace Personal.Expenses.Data.Repository
{
    public static class SpentFilterCustomExtension
    {

        public static IQueryable<Spent> WithCustomFilters(this IQueryable<Spent> queryBase, SpentFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Spent> WithLimitTenant(this IQueryable<Spent> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

