using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Personal.Expenses.Application;
using Personal.Expenses.Application.Interfaces;
using Personal.Expenses.Data.Context;
using Personal.Expenses.Data.Repository;
using Personal.Expenses.Domain.Interfaces.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Personal.Expenses.Domain.Interfaces.Services;
using Personal.Expenses.Domain.Services;
using Common.Domain.Model;
using Common.Api;

namespace Personal.Expenses.Api
{
    public static partial class ConfigContainerPersonal 
    {

        public static void RegisterOtherComponents(IServiceCollection services)
        {
			services.AddScoped<ICache, RedisComponent>();
			services.AddScoped<CurrentUser>();
			services.AddScoped<IStorage, Storage>();
        }
    }
}
