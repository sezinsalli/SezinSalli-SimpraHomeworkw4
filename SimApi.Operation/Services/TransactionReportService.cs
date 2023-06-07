using AutoMapper;
using Serilog;
using SimApi.Base.Response;
using SimApi.Data.Domain;
using SimApi.Data.UnitOfWork;
using SimApi.Schema.TransactıonRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public class TransactionReportService : ITransactionReportService
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;

        public TransactionReportService(IUnitofWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ApiResponse<List<TransactionViewResponse>> GetAll()
        {
            try
            {
                var entityList = unitOfWork.TransactionReportRepository.GetAll();
                var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>(entityList);
                return new ApiResponse<List<TransactionViewResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
            }
        }

        public ApiResponse<List<TransactionViewResponse>> GetByAccountId(int accountId)
        {
            try
            {
                var entityList = unitOfWork.TransactionReportRepository.GetByAccountId(accountId);
                var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>(entityList);
                return new ApiResponse<List<TransactionViewResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
            }
        }

        public ApiResponse<List<TransactionViewResponse>> GetByCustomerId(int customerId)
        {

            try
            {
                var entityList = unitOfWork.TransactionReportRepository.GetByCustomerId(customerId);
                var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>(entityList);
                return new ApiResponse<List<TransactionViewResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
            }
        }

        public ApiResponse<TransactionViewResponse> GetById(int id)
        {
            try
            {
                var entityList = unitOfWork.TransactionReportRepository.GetById(id);
                var mapped = mapper.Map<TransactionView, TransactionViewResponse>(entityList);
                return new ApiResponse<TransactionViewResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<TransactionViewResponse>(ex.Message);
            }
        }

        public ApiResponse<List<TransactionViewResponse>> GetByReferenceNumber(string referenceNumber)
        {
            try
            {
                var entityList = unitOfWork.TransactionReportRepository.GetByReferenceNumber(referenceNumber);
                var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>(entityList);
                return new ApiResponse<List<TransactionViewResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
            }
        }
    }
}
