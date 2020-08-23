using Common.Domain.Base;
using Common.Domain.CompositeKey;
using Common.Domain.Model;
using System;

namespace Personal.Expenses.Domain.Filter
{
    public class SpentFilterBase : FilterBase
    {

        public virtual int SpentId { get; set;} 
        public virtual string Description { get; set;} 


        public override string CompositeKey(CurrentUser user) {
            return CompositeKeyExtensions.CompositeKey(this, $"{user.GetSubjectId<int>()}");
        }

    }
}
