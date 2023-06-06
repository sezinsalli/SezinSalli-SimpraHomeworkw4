using AutoMapper;
using SimApi.Base.Model;
using SimApi.Base.Response;
using SimApi.Data.UnitOfWork;
using SimApi.Operation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.DapperS
{
    public class DapperService<TEntity, TRequest, TResponse> : IDapperService<TEntity, TRequest, TResponse> where TEntity : BaseModel
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;

        public DapperService(IUnitofWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ApiResponse Delete(int id)
        {
            try
            {
                unitOfWork.DapperRepository<TEntity>().DeleteById(id);
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                // Handle exception and return error response
                return new ApiResponse($"Error deleting entity: {ex.Message}");
            }
        }

        public ApiResponse<List<TResponse>> GetAll()
        {
            try
            {
                var entities = unitOfWork.DapperRepository<TEntity>().GetAll();
                var response = mapper.Map<List<TResponse>>(entities);
                return new ApiResponse<List<TResponse>>(response);
            }
            catch (Exception ex)
            {
                // Handle exception and return error response
                return new ApiResponse<List<TResponse>>($"Error getting entities: {ex.Message}");
            }
        }

        public ApiResponse<TResponse> GetById(int id)
        {
            try
            {
                var entity = unitOfWork.DapperRepository<TEntity>().GetById(id);
                if (entity == null)
                {
                    return new ApiResponse<TResponse>("Entity not found");
                }

                var response = mapper.Map<TResponse>(entity);
                return new ApiResponse<TResponse>(response);
            }
            catch (Exception ex)
            {
                // Handle exception and return error response
                return new ApiResponse<TResponse>($"Error getting entity: {ex.Message}");
            }
        }

        public ApiResponse Insert(TRequest request)
        {
            try
            {
                var entity = mapper.Map<TEntity>(request);
                unitOfWork.DapperRepository<TEntity>().Insert(entity);
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                // Handle exception and return error response
                return new ApiResponse($"Error inserting entity: {ex.Message}");
            }
        }

        public ApiResponse Update(int id, TRequest request)
        {
            try
            {
                var entity = unitOfWork.DapperRepository<TEntity>().GetById(id);
                if (entity == null)
                {
                    return new ApiResponse("Entity not found");
                }

                mapper.Map(request, entity);
                unitOfWork.DapperRepository<TEntity>().Update(entity);
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                // Handle exception and return error response
                return new ApiResponse($"Error updating entity: {ex.Message}");
            }
        }
    }

}
