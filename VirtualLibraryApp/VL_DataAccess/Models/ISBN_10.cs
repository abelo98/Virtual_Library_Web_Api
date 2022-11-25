using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace VL_DataAccess.Models
{
    public class ISBN_10 : ValueOf<string, ISBN_10>
    {
        protected override bool TryValidate()
        {
            if (Value.Length != 10)
                return false;

            int sum = 0;

            for (int i = 0; i < Value.Length - 1; i++)
            {
                int digit = Value[i] - '0';
                if (digit < 0 || digit > 9)
                    return false;

                sum += (digit * (10 - i));
            }

            char last = Value[Value.Length - 1];
            if (last != 'X' && (last < 0 || last > 9)) return false;

            sum += last == 'X' ? 10 : last - '0';

            return sum % 11 == 0;
        }
    }
}
