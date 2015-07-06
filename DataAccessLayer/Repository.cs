using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> where T : class
    {
        IObjectContextAdapter _context;
        IObjectSet<T> _objectSet;

        public Repository()
        {

            _context = new TelefonDeftContext();
            _objectSet = _context.ObjectContext.CreateObjectSet<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return _objectSet;
        }

        public T First(Expression<Func<T, bool>> where)
        {

            return _objectSet.First(where);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where);
        }

        public void Delete(T entity)
        {
            _objectSet.DeleteObject(entity);
            _context.ObjectContext.SaveChanges();
        }

        public bool Add(T entity)
        {
            _objectSet.AddObject(entity);
            _context.ObjectContext.SaveChanges();
            return true;
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
            _context.ObjectContext.SaveChanges();
        }

        public List<T> Listele()
        {
            List<T> liste = _objectSet.ToList();
            return liste;
        }

        public bool UpdateSaveChanges()
        {
            _context.ObjectContext.SaveChanges();
            return true;
        }
        // İçerisine aldığı order by sorgusuna göre sıralama yapar
        public List<T> Listele2<F>(Expression<Func<T, F>> where)
        {
            return _objectSet.OrderBy(where).ToList();
        }
        //Aldığı sorguya göre listeleme yapar
        public List<T> SorguyaGoreListele(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }


        public int Count(Expression<Func<T, bool>> where)
        {
            return _objectSet.Count(where);
        }
    }
}
