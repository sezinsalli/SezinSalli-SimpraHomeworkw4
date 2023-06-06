using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Base.ReferenceNumber
{
    public class ReferenceNumberGenerator
    {
        public static string Get()
        {
            return Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 10);
        }
    }
}
