using CarShop.DataAccess;
using CarShop.Models;
using CarShop.Repository.IRepository;

namespace CarShop.Repository
{
    public class CarRepository: Repository<Car>, ICarRepository
    {
        private ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Car obj)
        {
            _db.Cars.Update(obj);
        }
    }
}
