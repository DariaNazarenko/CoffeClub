using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoffeeClub.Domain.Entities;

namespace CoffeeClub
{
    public static class Validation
    {
        public static bool ValidateEntity(Coffee coffee)
        {
            bool check = false;
            var space = new Regex(@"\s");
            var symbols = new Regex(@"[!,#,\$,%,\^,&,\*,?,~]");
            var numbers = new Regex(@"\d");

            if(!space.IsMatch(coffee.Name) && !symbols.IsMatch(coffee.Name) && !numbers.IsMatch(coffee.Name))
            {
                check = true;
            }

            return check;
        }
    }
}
