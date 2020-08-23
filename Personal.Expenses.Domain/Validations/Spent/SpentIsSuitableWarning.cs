using Common.Validation;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Interfaces.Repository;
using System;

namespace Personal.Expenses.Domain.Validations
{
    public class SpentIsSuitableWarning : WarningSpecification<Spent>
    {
        public SpentIsSuitableWarning(ISpentRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Spent>(Instance of suitable warning specification,"message for user"));
        }

    }
}
