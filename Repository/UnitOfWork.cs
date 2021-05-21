using DAL;
using Repository.Implementations;
using Repository.Interfaces;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext _db;
        public UnitOfWork(DatabaseContext db)
        {
            _db = db;
        }
        private IProductRepository _ProductRepo;
        public IProductRepository ProductRepo
        {
            get
            {
                if (_ProductRepo == null)
                    _ProductRepo = new ProductRepository(_db);
                return _ProductRepo;
            }
        }

        private IRepository<Category> _CategoryRepo;
        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (_CategoryRepo == null)
                    _CategoryRepo = new Repository<Category>(_db);
                return _CategoryRepo;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
