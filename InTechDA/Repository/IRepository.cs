namespace InTechDA.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
