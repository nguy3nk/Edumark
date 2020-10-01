using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EduService.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected EdumarkDBContext db;
        protected DbSet<T> data;

        public Repository()
        {
            db = new EdumarkDBContext();
            data = db.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                data.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            try
            {
                data.AddRange(entities);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T Get(object id)
        {
            return data.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return data;
        }

        public IEnumerable<T> GetBy(Func<T, bool> predicate)
        {
            return data.Where(predicate);
        }

        public T GetBy1(Expression<Func<T, bool>> where)
        {
            try
            {
                return data.Where(where).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Remove(object id)
        {
            try
            {
                data.Remove(Get(id));
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Remove(T entity)
        {
            try
            {
                data.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                data.RemoveRange(entities);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T SingleBy(Func<T, bool> predicate)
        {
            return data.FirstOrDefault(predicate);
        }

        public bool Update(T entity)
        {
            try
            {
                data.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
