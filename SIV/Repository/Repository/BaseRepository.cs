using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected SivContext db { get;  set;  }

        public BaseRepository(SivContext context)
        {
            db = context;
        }

        /// <summary>
        /// Method create entity BaseRepository
        /// </summary>
        /// <param name="entity">Entity Data Base</param>
        /// <returns><see cref="TModel"/></returns>
        public TModel Create(TModel entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();

            return entity;
        }
        /// <summary>
        /// Method update entity
        /// </summary>
        /// <param name="entity">Entity Data Base</param>
        /// <returns><see cref="TModel"/></returns>
        public TModel Update(TModel entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

            return entity;
        }
        /// <summary>
        /// Method delete entity
        /// </summary>
        /// <param name="entity">Entity Data Base</param>
        /// <returns><see cref="TModel"/></returns>
        public TModel Delete(TModel entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Method filter entity in database
        /// </summary>
        /// <param name="expression">Expression filter</param>
        /// <returns>List <see cref="TModel"/></returns>
        public IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> expression)
        {
            return db.Set<TModel>().Where(expression);
        }
        /// <summary>
        /// Method filter entity single
        /// </summary>
        /// <param name="id">Id unique entity</param>
        /// <returns><see cref="TModel"/></returns>
        public TModel FindById(int id)
        {
            return db.Set<TModel>().Find(id);
        }
    }
}
