using Common.API;
using Common.Domain.Base;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Personal.Expenses.CrossCuting
{
    public class ImportExcelCustom<T> : ImportExcel<T>
    {
        public ImportExcelCustom(FilterBase filter) : base(filter)
        {
        }
    }
}

