using Common.Validation;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Interfaces.Repository;
using System;

namespace Personal.Expenses.Domain.Validations
{
    public class SpentIsSuitableValidation : ValidatorSpecification<Spent>
    {
        public SpentIsSuitableValidation(ISpentRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Spent>(Instance of is suitable,"message for user"));
        }

    }
}
