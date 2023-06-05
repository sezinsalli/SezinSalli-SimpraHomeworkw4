using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Domain
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
    }
}
