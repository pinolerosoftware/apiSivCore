using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data;
using Repository.Interface;

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
        /// <param name="entity">ModelDb to insert</param>
        /// <returns></returns>
        public TModel Create(TModel entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();

            return entity;
        }
    }
}
