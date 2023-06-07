using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base.AttributeR;
using SimApi.Base.Model;
using SimApi.Base.Response;
using SimApi.Data.Domain;
using SimApi.Operation.DapperS;
using SimApi.Schema.CategoryRR;
using System.Collections.Generic;

namespace SimApi.sDersNotarı.Controllers
{
    [EnableMiddlewareLogger]
    [ResponseGuid]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<CategoryResponse>>> GetAllCategories()
        {
            var response = categoryService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<CategoryResponse>> GetCategoryById(int id)
        {
            var response = categoryService.GetById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ApiResponse> CreateCategory(CategoryRequest request)
        {
            var response = categoryService.Insert(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<ApiResponse> UpdateCategory(int id, CategoryRequest request)
        {
            var response = categoryService.Update(id, request);
            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<ApiResponse> DeleteCategory(int id)
        {
            var response = categoryService.Delete(id);
            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }


}
