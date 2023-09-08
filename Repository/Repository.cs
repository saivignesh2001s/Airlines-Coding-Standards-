using Airlines.AirDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AirlineDbContext _airlineDbContext;
        public Repository(AirlineDbContext airlineDbContext)
        {
            _airlineDbContext = airlineDbContext;
        }
        public bool Add(T entity)
        {
            try
            {
                _airlineDbContext.Set<T>().Add(entity);
                _airlineDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T? Get(string id)
        {
            return _airlineDbContext.Set<T>().Find(id);
        }

        public IList<T>? GetAll()
        {
            return _airlineDbContext.Set<T>().ToList();
        }

        public bool Remove(T entity)
        {
            try
            {
                _airlineDbContext.Set<T>().Remove(entity);
                _airlineDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool  Update(T entity)
        {
            try
            {
                _airlineDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
                _airlineDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
