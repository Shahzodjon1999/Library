using Application.Repositories;
using Damen.Models;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesInfrastucture
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContractDbContext _contractDbContext;

        public CategoryRepository(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
        }

        public async Task Create(Category category)
        {
            try
            {
                _contractDbContext.Categories.Add(category);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                throw new NullReferenceException("Category Repository has method create null exseption" + ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var category = _contractDbContext.Categories.FirstOrDefault(i => i.Id == id);

                _contractDbContext.Categories.Remove(category);

               await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category Repository has method delete null exseption" + ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                return  _contractDbContext.Categories.AsEnumerable();

            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category Repository has method Getall null exseption" + ex);
            }
        }

        public async Task<Category?> GetById(Guid id)
        {
            try
            {
               return _contractDbContext.Categories.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category Repository has method getByid null exseption" + ex);
            }

        }

        public async Task Update(Category category)
        {
            try
            {
                _contractDbContext.Categories.Update(category);

               await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Category Repository has method update null exseption" + ex);
            }
        }
    }
}
