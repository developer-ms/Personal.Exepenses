using System;
using System.Collections.Generic;
using System.Text;

namespace Personal.Expenses.CrossCuting.Auth
{
    public static class SecurityConfig
    {
        public static string GetSalt()
        {
            return "Personal.Expenses321$";
        }

    }
}
