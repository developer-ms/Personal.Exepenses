using Common.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Personal.Expenses.Data.Map;
using Personal.Expenses.Domain.Entitys;

namespace Personal.Expenses.Data.Context
{
    public class DbContextPersonal : DbContextMultiTenantcy
    {

        public DbContextPersonal(DbContextOptions<DbContextPersonal> options, CurrentUser user, IConfiguration config)
            : base(options, user, config)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SpentMap(modelBuilder.Entity<Spent>());

        }


    }
}
