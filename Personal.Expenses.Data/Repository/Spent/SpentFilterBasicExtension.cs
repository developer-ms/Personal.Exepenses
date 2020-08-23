using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using System.Linq;

namespace Personal.Expenses.Data.Repository
{
    public static class SpentFilterBasicExtension
    {

        public static IQueryable<Spent> WithBasicFilters(this IQueryable<Spent> queryBase, SpentFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.SpentId));

            if (filters.SpentId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SpentId == filters.SpentId);
			}
            if (filters.Description.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Description.Contains(filters.Description));
			}


            return queryFilter;
        }

		
    }
}