using Microsoft.AspNetCore.Mvc;
using CarShop.Models;
using CarShop.DataAccess;
using CarShop.Repository.IRepository;

namespace CarShop.Controllers
{
    public class ItemController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public ItemController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index(int myData)
        {
            Car obj = _unitOfWork.Car.Get(U => U.Id == myData);
            return View(obj);
        }
    }
}
