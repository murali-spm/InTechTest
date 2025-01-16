using Microsoft.EntityFrameworkCore;

namespace InTechDA.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InTechDBContext _context ;
        private readonly DbSet<T> _dbSet;

        public Repository(InTechDBContext context)
        {   
            _context = context;
            _dbSet = context.Set<T>();
        }

        public InTechDBContext Context { get { return _context; } }

        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int Insert(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
