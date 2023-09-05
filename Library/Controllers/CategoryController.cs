using Application.Mapping;
using Application.RequestModels;
using Application.ResponsModels;
using Application.Services.AllServicesInterfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(ApiEndPoints.Category.Create)]
        public async Task<IActionResult> create([FromBody] CreateCategoryRequestModel createCategoryRequest)
        {
            try
            {
                if (createCategoryRequest.Name != null)
                {
                    await _categoryService.Create(createCategoryRequest);

                    return Ok("Seccesfull added");
                }
                return BadRequest("createCategoryRequest.Name has null");
            }
            catch (Exception)
            {
                throw new NullReferenceException("CategoryController has null exception in the method Create()");
            }
        }

        [HttpGet(ApiEndPoints.Category.GetAll)]
        public async Task<CategoriesResponse> GetAll()
        {
            try
            {
               var categories = await _categoryService.GetCategories();

                return categories;
            }
            catch (Exception)
            {
                throw new NullReferenceException("CategoryController has null exception in the method Getall()");
            }
        }

        [HttpGet(ApiEndPoints.Category.Get)]
        public async Task<CategoryResponse> GetById([FromRoute] Guid id)
        {
            try
            {
                var category = await _categoryService.GetById(id);

                return category;
            }
            catch (Exception)
            {
                throw new NullReferenceException("CategoryController has null exception in the method GetById()");
            }
        }

        [HttpPut(ApiEndPoints.Category.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequestModel updateCategoryRequest,Guid id)
        {
            try
            {
                if (updateCategoryRequest.Name != null)
                {
                    await _categoryService.Update(updateCategoryRequest, id);

                    return Ok("Seccessfull update");
                }
                return BadRequest("CategoryController has null in the update() method ");
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("CategoryController has null exception in the method update");
            }
        }

        [HttpDelete(ApiEndPoints.Category.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            try
            {
                await _categoryService.Delete(id);

                return Ok("Seccessfull delete");
            }
            catch (Exception)
            {
                throw new NullReferenceException("CategoryController has null exception in the method Delete()");
            }
        }
    }
}
