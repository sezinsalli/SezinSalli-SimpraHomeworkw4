using SimApi.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Services
{
    public interface IBaseService<TEntity, TRequest, TResponse>
    {
        //butun servıselerın ortak bır servıceden calısması ıcın
        ApiResponse<List<TResponse>> GetAll();
        ApiResponse<TResponse> GetById(int id);
        ApiResponse Insert(TRequest request);
        ApiResponse Update(int Id, TRequest request);
        ApiResponse Delete(int Id);
    }
}
