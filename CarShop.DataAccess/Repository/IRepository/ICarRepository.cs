using CarShop.Models;

namespace CarShop.Repository.IRepository
{
    public interface ICarRepository : IRepository<Car>
    {
       void Update(Car obj);
    }
}
