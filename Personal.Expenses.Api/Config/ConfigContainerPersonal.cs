using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using Personal.Expenses.Application;
using Personal.Expenses.Application.Interfaces;
using Personal.Expenses.Data.Context;
using Personal.Expenses.Data.Repository;
using Personal.Expenses.Domain.Entitys;
using Personal.Expenses.Domain.Interfaces.Repository;
using Personal.Expenses.Domain.Interfaces.Services;
using Personal.Expenses.Domain.Services;
using Personal.Expenses.Domain.Validations;

namespace Personal.Expenses.Api
{
    public static partial class ConfigContainerPersonal
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextPersonal>>();
            
			services.AddScoped<IValidatorSpecification<Spent>,SpentIsSuitableValidation>();
			services.AddScoped<IWarningSpecification<Spent>, SpentIsSuitableWarning>();
			services.AddScoped<ISpentApplicationService, SpentApplicationService>();
			services.AddScoped<ISpentService, SpentService>();
			services.AddScoped<ISpentRepository, SpentRepository>();



            RegisterOtherComponents(services);
        }
    }
}
