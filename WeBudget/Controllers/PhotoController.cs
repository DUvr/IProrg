using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;
using WeBudget.Service.Abstract;
using WeBudget.Service.FileService;

namespace WeBudget.Controllers
{
    public class PhotoController : Controller
    {
       String store = ConfigurationManager.AppSettings.Get("Store");
       IPhotoGalery Photoservice;
      

        public PhotoController() {
            if (store == "db")
            {
              Photoservice = new PhotoService();
            }

            if (store == "file")
            {
              Photoservice = new PhotoFileService();
            }
        }

        [HttpGet]
        public ActionResult EditPhoto(int? id)
        {

            if (Photoservice.findById(id) != null)
            {
                return View(Photoservice.findById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditPhoto(Photo Photo)
        {
            Photoservice.Edit(Photo);
            return RedirectToAction("Photos");
        }

        [HttpGet]
        public ActionResult CreatePhoto()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePhoto(Photo Photo)
        {
            Photoservice.Create(Photo);
            return RedirectToAction("Photos");
        }

        public ActionResult DeletePhoto(int id)
        {
            Photoservice.Delete(id);
            return RedirectToAction("Photos");
        }

        public ActionResult Photos()
        {
            return View(Photoservice.getList());
        }
    }
}