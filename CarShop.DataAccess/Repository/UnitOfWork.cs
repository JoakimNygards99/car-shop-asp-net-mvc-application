using CarShop.DataAccess;
using CarShop.Repository.IRepository;

namespace CarShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //5:37:41
        private ApplicationDbContext _db;

        //Den är public om man vill hämta den men private om man vill ändra värdet på attributen.
        public ICarRepository Car { get; private set; }
       

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            Car = new CarRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
