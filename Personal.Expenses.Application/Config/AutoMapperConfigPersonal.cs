using System;
using System.Collections.Generic;

namespace Personal.Expenses.Application.Config
{
	public class AutoMapperConfigPersonal
    {
        public static Type[] RegisterMappings()
        {
            return new List<Type>
            {
                typeof(DominioToDtoProfilePersonal),
                typeof(DominioToDtoProfilePersonalCustom)
            }.ToArray();
        }
	}
}
