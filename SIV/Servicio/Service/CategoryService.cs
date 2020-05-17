using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Repository.Interface;
using Repository.Repository;
using Services.Interface;
using System;
using System.Linq;
using Dto;
using Singleton;

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
            if (string.IsNullOrEmpty(categoryInput.name))
                throw new ArgumentException("Tiene que ingresar el nombre de la categoria");
            if (categoryInput.tenantId == default(int))
                throw new ArgumentException("Los datos proporcionados estan incompletos");
            var newCategory = MapperSingleton.Mapper.Map<CategoryDtoInput, Category>(categoryInput);
            newCategory.CreateAt = DateTime.Now;                
            var result = CategoryRepository.Create(newCategory);
            var categoryResult = MapperSingleton.Mapper.Map<Category, CategoryDtoOutput>(result);
            return categoryResult;
        }
        /// <summary>
        /// Method update category
        /// </summary>
        /// <param name="categoryInput">Data category to modify</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        public CategoryDtoOutput Update(CategoryDtoInput categoryInput)
        {
            if (string.IsNullOrEmpty(categoryInput.name))
                throw new ArgumentException("Tiene que ingresar el nombre de la categoria");
            if (categoryInput.tenantId == default)
                throw new ArgumentException("Los datos proporcionados estan incompletos");
            if(categoryInput.id == default)
                throw new ArgumentException("Los datos proporcionados estan incompletos falta el id");
            var updateCategory = CategoryRepository
                                    .FindBy(category => category.Id == categoryInput.id && category.TenantId == categoryInput.tenantId)
                                    .FirstOrDefault();
            if(updateCategory == null)
                throw new ArgumentException("No se encontro registro para modificar");
            updateCategory.Name = categoryInput.name;
            updateCategory.Description = categoryInput.description;
            updateCategory.UpdateAt = DateTime.Now;
            var result = CategoryRepository.Update(updateCategory);
            var category = MapperSingleton.Mapper.Map<Category, CategoryDtoOutput>(updateCategory);
            return category;
        }
        /// <summary>
        /// Method delete category
        /// </summary>
        /// <param name="categoryInput">Data category</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        public CategoryDtoOutput Delete(CategoryDtoInput categoryInput)
        {
            if (categoryInput.tenantId == default)
                throw new ArgumentException("Los datos proporcionados estan incompletos");
            if (categoryInput.id == default)
                throw new ArgumentException("Los datos proporcionados estan incompletos falta el id");
            var categoryDelete = CategoryRepository
                                    .FindBy(category => category.Id == categoryInput.id && category.TenantId == categoryInput.tenantId)
                                    .FirstOrDefault();
            if (categoryDelete == null)
                throw new ArgumentException("No se encontro registro para eliminar");
            categoryDelete.Active = false;
            var result = CategoryRepository.Update(categoryDelete);
            var category = MapperSingleton.Mapper.Map<Category, CategoryDtoOutput>(result);
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
            var category = MapperSingleton.Mapper.Map<Category, CategoryDtoOutput>(result.FirstOrDefault());
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
                                .ProjectTo<CategoryDtoOutput>(MapperSingleton.Mapper.ConfigurationProvider)
                                .AsQueryable();                                
            return categorys;
        }
    }
}
