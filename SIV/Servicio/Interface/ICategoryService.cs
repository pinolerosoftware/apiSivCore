using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interface
{
    public interface ICategoryService
    {
        /// <summary>
        /// Method create category
        /// </summary>
        /// <param name="categoryInput">Data input</param>
        /// <returns>Data Category <see cref="CategoryDtoOutput"/></returns>
        CategoryDtoOutput Create(CategoryDtoInput categoryInput);
        /// <summary>
        /// Method update category
        /// </summary>
        /// <param name="categoryInput">Data category to modify</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        CategoryDtoOutput Update(CategoryDtoInput categoryInput);
        /// <summary>
        /// Method delete category
        /// </summary>
        /// <param name="categoryInput">Data category</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        CategoryDtoOutput Delete(CategoryDtoInput categoryInput);
        /// <summary>
        /// Method find single 
        /// </summary>
        /// <param name="tenantId">Id del tenant</param>
        /// <param name="id">id category</param>
        /// <returns>Data category <see cref="CategoryDtoOutput"/></returns>
        CategoryDtoOutput FindOne(int tenantId, int id);
        /// <summary>
        /// Method to filter category
        /// </summary>
        /// <param name="tenanId">Id del tenant</param>
        /// <returns>Lista de category <see cref="CategoryDtoOutput"/></returns>
        IQueryable<CategoryDtoOutput> Filter(int tenanId);
    }
}
