using AutoMapper;
using SimApi.Base.Response;
using SimApi.Data.Domain;
using SimApi.Data.UnitOfWork;
using SimApi.Schema.CustomerRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public class CustomerService : BaseService<Customer, CustomerRequest, CustomerResponse>, ICustomerService
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;
        public CustomerService(IUnitofWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public override ApiResponse<List<CustomerResponse>> GetAll()
        {
            //Bu şekilde, bu metot tüm müşterilerin ve bunlara ilişkin hesapların ve işlemlerin dönüştürülmüş haliyle birlikte döndürülmesini sağlar.
            try
            {
                var entityList = unitOfWork.Repository<Customer>().GetAllWithInclude("Accounts.Transactions");
                var mapped = mapper.Map<List<Customer>, List<CustomerResponse>>(entityList);
                return new ApiResponse<List<CustomerResponse>>(mapped);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<CustomerResponse>>(ex.Message);
            }
        }

        public override ApiResponse<CustomerResponse> GetById(int id)
        {
            //Bu şekilde, bu metot belirli bir müşteri öğesini ve ona bağlı olan hesapların ve işlemlerin dönüştürülmüş haliyle birlikte döndürür. Eğer belirli bir ID'ye sahip müşteri öğesi bulunamazsa, "Record not found" mesajıyla birlikte bir hata yanıtı döndürülür.
            try
            {
                var entity = unitOfWork.Repository<Customer>().GetByIdWithInclude(id, "Accounts.Transactions");
                if (entity is null)
                {
                    return new ApiResponse<CustomerResponse>("Record not found");
                }

                var mapped = mapper.Map<Customer, CustomerResponse>(entity);
                return new ApiResponse<CustomerResponse>(mapped);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CustomerResponse>(ex.Message);
            }
        }

    }
}
