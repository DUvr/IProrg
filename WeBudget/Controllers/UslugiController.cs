﻿using System;
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
    public class UslugiController : Controller
    {
        String store = ConfigurationManager.AppSettings.Get("Store");
        IPhotoGalery Uslugiservice;


        public UslugiController()
        {
            if (store == "db")
            {
                Uslugiservice = new UslugiService();
            }

            if (store == "file")
            {
                Uslugiservice = new UslugiFileService();
            }
        }
      

        [HttpGet]
        public ActionResult EditUslugi(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (Uslugiservice.findById(id) != null)
            {
                return View(Uslugiservice.findById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditUslugi(Uslugi Uslugi)

        {
            Uslugiservice.Edit(Uslugi);
            return RedirectToAction("Uslugis");
        }

        [HttpGet]
        public ActionResult CreateUslugi()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUslugi(Uslugi Uslugi)
        {
            Uslugiservice.Create(Uslugi);
            return RedirectToAction("Uslugis");
        }


        public ActionResult DeleteUslugi(int id)
        {
            Uslugiservice.Delete(id);
            return RedirectToAction("Uslugis");
        }


        public ActionResult Uslugis()
        {          
             return View(Uslugiservice.getList());
           
        }
       
    }
}