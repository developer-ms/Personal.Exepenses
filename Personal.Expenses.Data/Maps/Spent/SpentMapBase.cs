using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal.Expenses.Domain.Entitys;

namespace Personal.Expenses.Data.Map
{
    public abstract class SpentMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Spent> type);

        public SpentMapBase(EntityTypeBuilder<Spent> type)
        {
            
            type.ToTable("Spent");
            type.Property(t => t.SpentId).HasColumnName("SpentId");
           

            type.Property(t => t.Description).HasColumnName("Description").HasColumnType("varchar(250)");


            type.HasKey(d => new { d.SpentId, }); 

			CustomConfig(type);
        }
		
    }
}