using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Interfaces.Repository;
using Personal.Expenses.Domain.Interfaces.Services;

namespace Personal.Expenses.Domain.Services
{
    public class SpentService : SpentServiceBase, ISpentService
    {

        public SpentService(ISpentRepository rep, IValidatorSpecification<Spent> validation, IWarningSpecification<Spent> warning, ICache cache, CurrentUser user) 
            : base(rep, validation, warning, cache, user)
        {


        }
        
    }
}
