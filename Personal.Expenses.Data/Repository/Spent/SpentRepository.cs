using Common.Domain.Base;
using Common.Orm;
using Personal.Expenses.Data.Context;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using Personal.Expenses.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using Common.Domain.Model;

namespace Personal.Expenses.Data.Repository
{
    public class SpentRepository : Repository<Spent>, ISpentRepository
    {
        private CurrentUser _user;
        public SpentRepository(DbContextPersonal ctx, CurrentUser user) : base(ctx)
        {
			this._user = user;
        }

      
        public IQueryable<Spent> GetBySimplefilters(SpentFilter filters)
        {
            var querybase = this.GetAll(this.DataAgregation(filters))
								.WithBasicFilters(filters)
								.WithCustomFilters(filters)
								.OrderByDomain(filters)
                                .OrderByProperty(filters);
            return querybase;
        }

        public async Task<Spent> GetById(SpentFilter model)
        {
            var _spent = await this.SingleOrDefaultAsync(this.GetAll(this.DataAgregation(model))
               .Where(_=>_.SpentId == model.SpentId));

            return _spent;
        }

		public async Task<IEnumerable<dynamic>> GetDataItem(SpentFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SpentId,
				Name = _.Description
            })); 

            return querybase;
        }

        public async Task<IEnumerable<dynamic>> GetDataListCustom(SpentFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SpentId

            }));

            return querybase;
        }

		
        public async Task<PaginateResult<dynamic>> GetDataListCustomPaging(SpentFilter filters)
        {
            var querybase = await this.PagingDataListCustom<dynamic>(filters, this.GetBySimplefilters(filters).Select(_ => new
            {
                Id = _.SpentId
            }));
            return querybase;
        }

        public async Task<dynamic> GetDataCustom(SpentFilter filters)
        {
            var querybase = await this.ToListAsync(this.GetBySimplefilters(filters).Select(_ => new
            {
               Id = _.SpentId

            }));

            return querybase;
        }

        protected override dynamic DefineFieldsGetOne(IQueryable<Spent> source, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;
        }

        protected override IQueryable<dynamic> DefineFieldsGetByFilters(IQueryable<Spent> source, FilterBase filters)
        {
			if (filters.QueryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return source.Select(_ => new
                {

                });
            }
            return source;

        }

        protected override IQueryable<Spent> MapperGetByFiltersToDomainFields(IQueryable<Spent> source, IEnumerable<dynamic> result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return result.Select(_ => new Spent
                {

                }).AsQueryable();
            }

            return result.Select(_ => (Spent)_).AsQueryable();

        }

        protected override Spent MapperGetOneToDomainFields(IQueryable<Spent> source, dynamic result, string queryOptimizerBehavior)
        {
            if (queryOptimizerBehavior == "queryOptimizerBehavior")
            {
                return new Spent
                {

                };
            }

            return source.SingleOrDefault();
        }

		protected override Expression<Func<Spent, object>>[] DataAgregation(Expression<Func<Spent, object>>[] includes, FilterBase filter)
        {
            return base.DataAgregation(includes, filter);
        }

    }
}
