using Common.Gen;
using Personal.Expenses.Gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Expenses.Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperFlow.Flow(args, () =>
            {

                return new ConfigExternalResources().GetConfigExternarReources();

            }, new HelperSysObjects(new ConfigContext().GetConfigContext()));
        }

    }
}
