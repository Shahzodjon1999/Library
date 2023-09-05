using Application.RequestModels;
using Application.ResponsModels;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AllServicesInterfase
{
    public interface ICategoryService
    {
        Task<CategoriesResponse> GetCategories();

        Task Create(CreateCategoryRequestModel  category);

        Task Update(UpdateCategoryRequestModel category, Guid id);

        Task Delete(Guid id);

        Task<CategoryResponse?> GetById(Guid id);
    }
}
