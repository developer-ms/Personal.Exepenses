using Personal.Expenses.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Personal.Expenses.Domain.Entitys
{
    public class Spent : SpentBase
    {

        public Spent()
        {

        }

		 public Spent(int spentid, string description) : base(spentid, description) { }


		public class SpentFactory : SpentFactoryBase
        {
            public Spent GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new SpentIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
