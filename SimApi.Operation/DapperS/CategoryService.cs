using AutoMapper;
using SimApi.Data.Domain;
using SimApi.Data.UnitOfWork;
using SimApi.Schema.CategoryRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.DapperS
{
    public class CategoryService : DapperService<Category, CategoryRequest, CategoryResponse>, ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IUnitofWork unitofWork;

        public CategoryService(IMapper mapper, IUnitofWork unitofWork) : base(unitofWork, mapper)
        {
            this.mapper = mapper;
            this.unitofWork = unitofWork;
        }
    }

}
