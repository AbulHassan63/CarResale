using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarResale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CarResale.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDalRep _idalRep;
        public AdminController(IDalRep idalRep)
        {
            _idalRep = idalRep;
        }
        public IActionResult AddManufacturer()
        {
            return View();
        }
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModel()
        {
            CarRegister _carregister = new CarRegister();
            _carregister.CarManinfo = _idalRep.Gatcarmaninfo();
            return View(_carregister);
        }
        [HttpPost]
        public IActionResult AddModel(CarRegister carregister)
        {
            bool resltflag = _idalRep.SaveModel(carregister);
            if (resltflag)
            {
                return RedirectToAction("CarRegister", "Master");
            }
            return View(carregister);
        }
    }
}
