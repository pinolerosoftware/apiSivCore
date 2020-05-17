using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        protected readonly IMapper Mapper;

        public IBaseRepository<Category> CategoryRepository { get; set; }

        public CategoryService(SivContext context)
        {
            db = context;
            CategoryRepository = new BaseRepository<Category>(context);
            Mapper = Mappers.GetMapper();
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
                var newCategory = Mapper.Map<CategoryDtoInput, Category>(categoryInput);                
                var result = CategoryRepository.Create(newCategory);
                var categoryResult = Mapper.Map<Category, CategoryDtoOutput>(result);
                return categoryResult;
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
                var updateCategory = Mapper.Map<CategoryDtoInput, Category>(categoryInput);                
                var result = CategoryRepository.Update(updateCategory);
                var category = Mapper.Map<Category, CategoryDtoOutput>(updateCategory);
                return category;
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
            var category = Mapper.Map<Category, CategoryDtoOutput>(categoryDelete);
            return category;
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
                            .FindBy(category => category.TenantId == tenantId && category.Id == id);
            if (result == null)
                return null;
            var category = Mapper.Map<Category, CategoryDtoOutput>(result.FirstOrDefault());
            return category;
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
                                .ProjectTo<CategoryDtoOutput>(Mapper.ConfigurationProvider)
                                .AsQueryable();                                
            return categorys;
        }
    }
}
