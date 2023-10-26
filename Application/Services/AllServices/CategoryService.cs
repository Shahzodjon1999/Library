using Application.Mapping;
using Application.Repositories;
using Application.RequestModels;
using Application.ResponsModels;
using Application.Services.AllServicesInterfase;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Application.Services.AllServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(CreateCategoryRequestModel category)
        {
            try
            {
                var categoryMap = category.MapToCreateCategory();

                await _categoryRepository.Create(categoryMap);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category service has exception in Create method()" + ex.Message);
            }

        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _categoryRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new NullReferenceException("category service has exception in delete method()" + ex.Message);
            }
        }

        public async Task<CategoryResponse?> GetById(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetById(id);

                var categoryMapRespons = category.MapToCategoryResponse();

                return categoryMapRespons;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category service has exception in getById method()" + ex.Message);
            }

        }

        public async Task<CategoriesResponse> GetCategories()
        {
            try
            {
                var categorRespons = await _categoryRepository.GetAll();

                var result = categorRespons.MapToCategoriesResponse();

                return result;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category service has exception in GetAll method()" + ex.Message);
            }
        }

        public async Task Update(UpdateCategoryRequestModel updateCategoryRequest, Guid id)
        {
            try
            {
                var categoryRequest = updateCategoryRequest.MapToUpdateCategory(id);

                await _categoryRepository.Update(categoryRequest);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category service has exception in delete method()" + ex.Message);
            }
        }
    }
}
