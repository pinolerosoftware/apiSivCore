using Data;
using Data.Entities;
using Repository.Interface;
using Repository.Repository;
using Services.Dto;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class CategoryService : ICategoryService
    {
        protected readonly SivContext db;

        public IBaseRepository<Category> CategoryRepository { get; set; }

        public CategoryService(SivContext context)
        {
            db = context;
            CategoryRepository = new BaseRepository<Category>(context);
        }
        /// <summary>
        /// Method create category
        /// </summary>
        /// <param name="categoryInput">Data input</param>
        /// <returns>Data Category <see cref="CategoryDtoOutput"/></returns>
        public CategoryDtoOutput Create(CategoryDtoInput categoryInput)
        {
            try
            {
                Category newCategory = new Category();
                newCategory.Name = categoryInput.name;
                newCategory.Description = categoryInput.description;
                newCategory.TenantId = categoryInput.tenantId;
                var result = CategoryRepository.Create(newCategory);
                return new CategoryDtoOutput
                {
                    id = result.Id,
                    name = result.Name,
                    description = result.Description,
                    tenantId = result.TenantId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method update category
        /// </summary>
        /// <param name="categoryInput">Data category to modify</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        public CategoryDtoOutput Update(CategoryDtoInput categoryInput)
        {
            try
            {
                Category newCategory = new Category();
                newCategory.Name = categoryInput.name;
                newCategory.Description = categoryInput.description;                
                var result = CategoryRepository.Update(newCategory);
                return new CategoryDtoOutput
                {
                    id = result.Id,
                    name = result.Name,
                    description = result.Description,
                    tenantId = result.TenantId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method delete category
        /// </summary>
        /// <param name="categoryInput">Data category</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        public CategoryDtoOutput Delete(CategoryDtoInput categoryInput)
        {   
            var categoryDelete = CategoryRepository.FindById(categoryInput.id);
            var result = CategoryRepository.Delete(categoryDelete);
            return new CategoryDtoOutput
            {
                id = result.Id,
                name = result.Name,
                description = result.Description,
                tenantId = result.TenantId
            };
        }
        /// <summary>
        /// Method find single 
        /// </summary>
        /// <param name="tenantId">Id del tenant</param>
        /// <param name="id">id category</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        public CategoryDtoOutput FindOne(int tenantId, int id)
        {
            var result = CategoryRepository
                            .FindBy(category => category.TenantId == tenantId && category.Id == id)
                            .Select(category => new CategoryDtoOutput
                            {
                                id = category.Id,
                                name = category.Name,
                                description = category.Description,
                                tenantId = category.TenantId,

                            });
            if (result == null)
                return null;
            return result.FirstOrDefault();
        }
        /// <summary>
        /// Method to filter category
        /// </summary>
        /// <param name="tenanId">Id del tenant</param>
        /// <returns>Lista de category <see cref="CategoryDtoOutput"/></returns>
        public IQueryable<CategoryDtoOutput> Filter(int tenanId)
        {
            var categorys = CategoryRepository
                                .FindBy(category => category.TenantId == tenanId)
                                .Select(category => new CategoryDtoOutput 
                                {
                                    id = category.Id,
                                    name = category.Name,
                                    description = category.Description,
                                    tenantId = category.TenantId,
                                    
                                });
            return categorys;
        }
    }
}
