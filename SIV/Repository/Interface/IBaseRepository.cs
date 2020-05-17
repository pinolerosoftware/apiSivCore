using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Method create entity BaseRepository
        /// </summary>
        /// <param name="entity">Entity Data Base</param>
        /// <returns><see cref="TModel"/></returns>
        TModel Create(TModel entity);
        /// <summary>
        /// Method update entity
        /// </summary>
        /// <param name="entity">Entity Data Base</param>
        /// <returns><see cref="TModel"/></returns>
        TModel Update(TModel entity);
        /// <summary>
        /// Method delete entity
        /// </summary>
        /// <param name="entity">Entity Data Base</param>
        /// <returns><see cref="TModel"/></returns>
        TModel Delete(TModel entity);
        /// <summary>
        /// Method filter entity in database
        /// </summary>
        /// <param name="expression">Expression filter</param>
        /// <returns>List <see cref="TModel"/></returns>
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> expression);
        /// <summary>
        /// Method filter entity single
        /// </summary>
        /// <param name="id">Id unique entity</param>
        /// <returns><see cref="TModel"/></returns>
        TModel FindById(int id);
    }
}
