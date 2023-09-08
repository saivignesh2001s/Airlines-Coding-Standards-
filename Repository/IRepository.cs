namespace Airlines.Repository
{
    public interface IRepository<T> where T : class
    {
        IList<T>? GetAll();
        T? Get(string id);
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity); 
    }
}
