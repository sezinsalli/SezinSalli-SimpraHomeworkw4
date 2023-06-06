using SimApi.Data.Domain;
using SimApi.Schema.CategoryRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.DapperS
{
    public interface ICategoryService : IDapperService<Category, CategoryRequest, CategoryResponse>
    {
    }
}
