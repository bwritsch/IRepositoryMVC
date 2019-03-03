using RepositoryMvc.Contract;
using RepositoryMvc.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositoryMvc.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        internal DbSet<T> dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var t = Get(id);
            Delete(t);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T SingleOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
//-------------------------------------------------------------------------
        private void Example(T temp)
        {
            Func<int, int> ex = FuncExample;
            Func<int, int> example = n => n * 10;

            dbSet.Where(PredicateMethod(temp));
            dbSet.Where(x => x == null);

        }

        private int FuncExample(int a)
        {
            return a * 10;
        }

        private T SingleOrDefault(Func<T, bool> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }


        //Predicate
        private Func<T,bool> PredicateMethod(T a)
        {
            return x => a == null;
        }

    }
}