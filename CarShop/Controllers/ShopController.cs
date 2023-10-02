using CarShop.DataAccess;
using CarShop.Models;
using CarShop.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace CarShop.Controllers
{
    public class ShopController : Controller
    {
        public int pageSize = 8;
        private readonly ApplicationDbContext _db;
        public ShopController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? pageNumber)
        {
            return View(PageinatedList<Car>.Create(_db.Cars.ToList(),
               pageNumber ?? 1, pageSize));
        }


        //Action metod för att sortera bilarna via färg
        [HttpGet]
        public IActionResult SortColor(string myData, int? pageNumber) 
        {
           
            List<Car> objCarList = _db.Cars.ToList();
            List<Car> filterCarList = new List<Car>();

            

            for (int i = 0; i < objCarList.Count; i++)
            {
                if (objCarList[i].Colour == myData)
                {
                    filterCarList.Add(objCarList[i]);
                }
                
            }

            ViewBag.ActionName = RouteData.Values["action"].ToString();

            return View("Index", PageinatedList<Car>.Create(filterCarList,
               pageNumber ?? 1, pageSize));
        }

        //Action metod för att sortera bilarna via pris
        public IActionResult SortPrice(string myData, int? pageNumber)
        {
            
            List<Car> objCarList = _db.Cars.ToList();

            if(myData == "Low-to-high")
            {
                //low-to-high
                objCarList.Sort((car1, car2) => car1.Price.CompareTo(car2.Price));
            }

            if(myData == "High-to-low")
            {
                //high-to-low
                objCarList.Sort((car1, car2) => car2.Price.CompareTo(car1.Price));
            }

            ViewBag.ActionName = RouteData.Values["action"].ToString();

            return View("Index", PageinatedList<Car>.Create(objCarList,
               pageNumber ?? 1, pageSize));
        }


        [HttpPost]
        public IActionResult SearchByName(IFormCollection form)
        {
            
            string inputValue = form["HiddenValue1"];
            string PageIndex = form["HiddenValue2"];
            int pageNumber = int.Parse(PageIndex);
            
            inputValue = inputValue.ToLower();

            List<Car> objCarList = _db.Cars.ToList();
            List<Car> filterCarList = new List<Car>();

            foreach (var car in objCarList)
            {
                if (car.Model.ToLower().Contains(inputValue))
                {
                    filterCarList.Add(car);
                }
                else
                {
                    if(inputValue.Length < 2)
                    {
                        return View("Index", PageinatedList<Car>.Create(filterCarList,
                                pageNumber, pageSize));
                    }
                    else
                    {
                       if(inputValue.Length == 2)
                        {
                            string subTwo = inputValue.Substring(0, 2);
                            if (car.Model.ToLower().Contains(subTwo))
                            {
                                filterCarList.Add(car);
                            }
                        }

                        else
                        {
                            string subThree = inputValue.Substring(0, 3);


                            if (car.Model.ToLower().Contains(subThree))
                            {
                                filterCarList.Add(car);
                            }
                        }
                    }
                }
                    
            }

            ViewBag.ActionName = RouteData.Values["action"].ToString();
            ViewBag.Message = inputValue;

            return View("Index", PageinatedList<Car>.Create(filterCarList,
                                pageNumber, pageSize));
        }
    }
}
