using Microsoft.Extensions.DependencyInjection;
using Personal.Expenses.HangFire.Interfaces;
using Personal.Expenses.HangFire.Jobs;

namespace Personal.Expenses.HangFire.Config
{
    public static partial class ConfigContainer
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<ISchedules<SampleJob>, SampleJob>();
            RegisterOtherComponents(services);
        }
    }
}
