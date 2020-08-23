using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Personal.Expenses.Domain.Entitys
{
    public class SpentBase : DomainBase
    {
        public SpentBase()
        {

        }

		public SpentBase(int spentid, string description) 
        {
            this.SpentId = spentid;
            this.Description = description;

        }


		public class SpentFactoryBase
        {
            public virtual Spent GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Spent(data.SpentId,
                                        data.Description);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int SpentId { get; protected set; }
        public virtual string Description { get; protected set; }



    }
}
