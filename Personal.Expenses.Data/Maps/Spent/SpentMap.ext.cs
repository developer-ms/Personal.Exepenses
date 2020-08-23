using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal.Expenses.Domain.Entitys;

namespace Personal.Expenses.Data.Map
{
    public class SpentMap : SpentMapBase
    {
        public SpentMap(EntityTypeBuilder<Spent> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Spent> type)
        {

        }

    }
}