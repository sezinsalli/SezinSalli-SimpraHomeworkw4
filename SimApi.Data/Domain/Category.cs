using SimApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Domain
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
