using CarShop.DataAccess;
using CarShop.Models;
using CarShop.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Dynamic;
using System.Web;

namespace CarShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        
        public AdminController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
           
        }
        public IActionResult Index()
        {
            List<Car> objCategoryList = _unitOfWork.Car.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Upload()
        {
            return View();
        }

        // POST: /YourController/UploadImage
        [HttpPost]
        public async Task<IActionResult> UploadImage(ImageUploadModel model)
        {
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(model.ImageFile.FileName);

                string path2 = "~/uploads/" + fileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }


                TempData["ID"] = path2;
                // You can save the 'path' in your database or use it as needed.
                return RedirectToAction("Create", "Admin");
            }

            // Handle errors
            ModelState.AddModelError("ImageFile", "Please select an image file.");
            return View("Upload", model);
        }


        public IActionResult Create(object values)
        {
            
            return View();
        }

        //En ActionMetod för att posta datan
        [HttpPost]
        public IActionResult Create(Car? obj, object values)
        {
            var pathFromPreviusAction = TempData["ID"].ToString();
            obj.Path = pathFromPreviusAction;


            _unitOfWork.Car.add(obj);
            //Sparar ändringarna till databasen
           _unitOfWork.Save();

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //Kör en sql query från databasen som hämtar ett objekt med det id man skickar in
            Car? CarFromDb = _unitOfWork.Car.Get(U => U.Id == Id);

            if (CarFromDb == null)
            {
                return NotFound();
            }

            return View(CarFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Car obj)
        {
                _unitOfWork.Car.Update(obj);
               
                _unitOfWork.Save();

                return RedirectToAction("Index", "Admin");
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //Kör en sql query från databasen som hämtar ett objekt med det id man skickar in
            Car? CarFromDb = _unitOfWork.Car.Get(U => U.Id == Id);

            if (CarFromDb == null)
            {

                return NotFound();
            }

            return View(CarFromDb);
        }

        //En ActionMetod för att posta datan
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Car obj = _unitOfWork.Car.Get(U => U.Id == Id);
            
            if (obj == null)
            {
                return NotFound(Id);
            }
            _unitOfWork.Car.Remove(obj);

            _unitOfWork.Save();

            //När koden ovanför har körts så dirigerar vi om routen till metoden index som kör sin kod
            return RedirectToAction("Index", "Admin");
        }
    }
}
