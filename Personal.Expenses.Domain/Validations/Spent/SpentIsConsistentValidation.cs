using Common.Validation;
using Personal.Expenses.Domain.Entitys;
using System;

namespace Personal.Expenses.Domain.Validations
{
    public class SpentIsConsistentValidation : ValidatorSpecification<Spent>
    {
        public SpentIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Spent>(Instance of is consistent specification,"message for user"));
        }

    }
}
