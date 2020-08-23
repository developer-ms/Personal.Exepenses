using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Filter;
using Personal.Expenses.Domain.Interfaces.Repository;
using Personal.Expenses.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal.Expenses.Domain.Services
{
    public class SpentServiceBase : ServiceBase<Spent>
    {
        protected readonly ISpentRepository _rep;
        protected readonly IValidatorSpecification<Spent> _validation;
        protected readonly IWarningSpecification<Spent> _warning;


        public SpentServiceBase(ISpentRepository rep, IValidatorSpecification<Spent> validation, IWarningSpecification<Spent> warning, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
            this._user = user;
            this._validation = validation;
            this._warning = warning;
        }

        public virtual async Task<Spent> GetOne(SpentFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Spent>> GetByFilters(SpentFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Spent>> GetByFiltersPaging(SpentFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Spent spent)
        {
            this._rep.Remove(spent);
        }

        public virtual Summary GetSummary(PaginateResult<Spent> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

        public override async Task<Spent> Save(Spent spent, bool questionToContinue = false)
        {
			var spentOld = await this.GetOne(new SpentFilter { SpentId = spent.SpentId, QueryOptimizerBehavior = "OLD" });
			var spentOrchestrated = await this.DomainOrchestration(spent, spentOld);

            if (questionToContinue)
            {
                if (this.Continue(spentOrchestrated, spentOld) == false)
                    return spentOrchestrated;
            }

            return this.SaveWithValidation(spentOrchestrated, spentOld);
        }

        public override async Task<Spent> SavePartial(Spent spent, bool questionToContinue = false)
        {
            var spentOld = await this.GetOne(new SpentFilter { SpentId = spent.SpentId, QueryOptimizerBehavior = "OLD" });
			var spentOrchestrated = await this.DomainOrchestration(spent, spentOld);

            if (questionToContinue)
            {
                if (this.Continue(spentOrchestrated, spentOld) == false)
                    return spentOrchestrated;
            }

            return SaveWithOutValidation(spentOrchestrated, spentOld);
        }

        protected override Spent SaveWithOutValidation(Spent spent, Spent spentOld)
        {
            spent = this.SaveDefault(spent, spentOld);
			this._cacheHelper.ClearCache();

			if (!spent.IsValid())
			{
				this._validationResult = spent.GetDomainValidation();
				this._validationWarning = spent.GetDomainWarning();
				return spent;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return spent;
        }

		protected override Spent SaveWithValidation(Spent spent, Spent spentOld)
        {
            if (!this.IsValid(spent))
				return spent;
            
            spent = this.SaveDefault(spent, spentOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return spent;
        }
		
		protected virtual bool IsValid(Spent entity)
        {
            var isValid = true;
            if (!this.DataAnnotationIsValid() || !entity.IsValid())
            {
                if (this._validationResult.IsNull())
                    this._validationResult = entity.GetDomainValidation();
                else
                    this._validationResult.Merge(entity.GetDomainValidation());

                if (this._validationWarning.IsNull())
                    this._validationWarning = entity.GetDomainWarning();
                else
                    this._validationWarning.Merge(entity.GetDomainWarning());

                isValid = false;
            }

            this.Specifications(entity);
            if (!this._validationResult.IsValid)
                isValid = false;

            return isValid;
        }

		protected virtual void Specifications(Spent spent)
        {
            this._validationResult  = this._validationResult.Merge(this._validation.Validate(spent));
			this._validationWarning  = this._validationWarning.Merge(this._warning.Validate(spent));
        }

        protected virtual Spent SaveDefault(Spent spent, Spent spentOld)
        {
			

            var isNew = spentOld.IsNull();			
            if (isNew)
                spent = this.AddDefault(spent);
            else
				spent = this.UpdateDefault(spent);

            return spent;
        }
		
        protected virtual Spent AddDefault(Spent spent)
        {
            spent = this._rep.Add(spent);
            return spent;
        }

		protected virtual Spent UpdateDefault(Spent spent)
        {
            spent = this._rep.Update(spent);
            return spent;
        }
				
		public virtual async Task<Spent> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Spent.SpentFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Spent> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Spent.SpentFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
