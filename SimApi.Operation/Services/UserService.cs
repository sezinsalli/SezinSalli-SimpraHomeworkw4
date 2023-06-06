using AutoMapper;
using SimApi.Base.Response;
using SimApi.Data.Domain;
using SimApi.Data.UnitOfWork;
using SimApi.Schema.UserRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public class UserService : BaseService<User, UserRequest, UserResponse>, IUserService
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitofWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public override ApiResponse Insert(UserRequest request)
        {
            var exist = unitOfWork.Repository<User>().
                Where(x => x.UserName.Equals(request.UserName)).ToList();

            if (exist.Any())
            {
                return new ApiResponse("Username already in use.");
            }

            try
            {
                request.Password = CreateMD5(request.Password);
                var entity = mapper.Map<UserRequest, User>(request);
                entity.CreatedAt = DateTime.UtcNow;
                entity.Status = 1;
                entity.PasswordRetryCount = 0;
                entity.LastActivity = DateTime.UtcNow;

                unitOfWork.Repository<User>().Insert(entity);
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public override ApiResponse Update(int Id, UserRequest request)
        {
            var exist = unitOfWork.Repository<User>().GetById(Id);
            if (exist is null)
            {
                return new ApiResponse("User not found.");
            }

            if (exist.Status == 3 || exist.PasswordRetryCount > 3)
            {
                return new ApiResponse("User cannot be updated.");
            }

            return base.Update(Id, request);
        }

        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes).ToLower();

            }
        }
    }
}
