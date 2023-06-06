using AutoMapper;
using SimApi.Data.Domain;
using SimApi.Schema.AccountRR;
using SimApi.Schema.CategoryRR;
using SimApi.Schema.CustomerRR;
using SimApi.Schema.ProductRR;
using SimApi.Schema.UserRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Schema.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryRequest, Category>();

            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();

            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User >();

            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerRequest, Customer>();

            CreateMap<Account, AccountResponse>();
            CreateMap<AccountRequest, Account>();

            //CreateMap<Transaction, TransactionResponse>();
            //CreateMap<TransactionView, TransactionViewResponse>();
        }
    }
}
