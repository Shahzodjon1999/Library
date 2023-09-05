using Application.RequestModels;
using Application.ResponsModels;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public static class CategoryMap
    {
        public static Category MapToCreateCategory(this CreateCategoryRequestModel createCategoryRequest)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),

                Name = createCategoryRequest.Name,
            };
        }

        public static Category MapToUpdateCategory(this UpdateCategoryRequestModel updateCategoryRequest,Guid id)
        {
            return new Category()
            {
                Id = id,

                Name = updateCategoryRequest.Name,
            };
        }

        public static CategoryResponse MapToCategoryResponse(this Category category)
        {
            return new CategoryResponse()
            {
                Id = category.Id,

                Name = category.Name,

                Books = category.Books,
            };
        }

        public static CategoriesResponse MapToCategoriesResponse(this IEnumerable<Category> categories)
        {
            return new CategoriesResponse()
            {
                CategoriesItems = categories.Select(MapToCategoryResponse)
            };
        }
    }
}
