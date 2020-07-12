using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarResale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CarResale.Controllers
{
    public class MasterController : Controller
    {
        private readonly IDalRep _idalRep;
        CarRegister _carregister = new CarRegister();
        Dashboardview _dashview = new Dashboardview();
        public MasterController(IDalRep idalRep)
        {
            _idalRep=idalRep;
        }


        [HttpGet]
        public IActionResult CarRegister()
        {
            _carregister.CarManinfo = _idalRep.Gatcarmaninfo();
            return View(_carregister);
        }       

        [HttpPost]
        public IActionResult CarRegister(CarRegister carregister, IFormFile[] Images)
        {
            if (Images == null || Images.Length == 0)
            {
                //return Content("File(s) not selected");
            }
            else
            {
                carregister.DtImages = new DataTable();
                carregister.DtImages.Columns.Add("ImagePath");
                carregister.Images = new List<string>();
                foreach (IFormFile photo in Images)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream);
                    carregister.Images.Add(photo.FileName);
                    carregister.DtImages.Rows.Add("../images/"+ photo.FileName);
                }
            }
            bool resltflag= _idalRep.SaveRegister(carregister);
            if(resltflag)
            {
                _carregister = new CarRegister();
            }           
            _carregister.CarManinfo = _idalRep.Gatcarmaninfo();
            return View(_carregister);
        }




        [HttpGet]
        public IActionResult Dashboard1()
        {
            _dashview.DashCarRegister = _idalRep.Getrecordsbyfilter(0,0,0).ToList();
            _dashview.CarManinfo = _idalRep.Gatcarmaninfo();
            return View(_dashview);
        }

        [HttpPost]
        public IActionResult Dashboard1(Dashboardview dashboardview)
        {
            _dashview.DashCarRegister = _idalRep.Getrecordsbyfilter(dashboardview.Man_id,dashboardview.Brand_id,dashboardview.Model_id).ToList();
            _dashview.CarManinfo = _idalRep.Gatcarmaninfo();
            return View(_dashview);
        }



        public JsonResult GetBrand(int Man_id)
        {
            //var getbrand= _idalRep.GetCarbrand(Man_id);
            return Json(new SelectList(_idalRep.GetCarbrand(Man_id), "Brand_id", "Brand_name"));
        }

        public JsonResult GetModel(int Brand_id)
        {
            return Json(new SelectList(_idalRep.GetCarmodel(Brand_id), "Model_id", "Model_name"));
        }
    }
}
