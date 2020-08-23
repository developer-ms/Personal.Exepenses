using Common.Api;
using Common.Cripto;
using Common.Domain;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using HangFire.Model;
using Microsoft.Extensions.DependencyInjection;
using Personal.Expenses.HangFire.Base;
using Personal.Expenses.HangFire.Interfaces;

namespace Personal.Expenses.HangFire.Config
{
    public static partial class ConfigContainer
    {
        public static void RegisterOtherComponents(IServiceCollection services)
        {
            services.AddScoped<CurrentUser>();
            services.AddScoped<IRequest, Request>();
            services.AddScoped<ICripto, Cripto>();
            services.AddScoped<ISchedulesContainer, SchedulesContainer>();
            services.AddSingleton<JobExecutionControl>();
        }
    }
}
