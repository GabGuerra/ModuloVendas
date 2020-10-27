using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Utils
{
    public static class ConversaoDados
    {
        public static long ToLong(this object val)
        {
            return Convert.ToInt64(val);
        }

        public static int ToInt(this object val)
        {
            return Convert.ToInt32(val);
        }

        public static double ToDouble(this object val)
        {
            return Convert.ToDouble(val);
        }

        public static bool ToBool(this object val)
        {
            return Convert.ToBoolean(val);
        }
    }
}
