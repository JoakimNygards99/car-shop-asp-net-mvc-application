namespace CarShop.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarRepository Car { get; }
        void Save();
    }
}
