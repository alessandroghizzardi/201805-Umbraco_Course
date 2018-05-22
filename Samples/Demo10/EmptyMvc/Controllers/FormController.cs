using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMvc.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StandardForm()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult StandardForm(MyTestModel model)
        {
            if (!ModelState.IsValid) //Check for validation errors
            {
                return View(model);
            }

            TempData["id"] = model.ID;
            TempData["firstName"] = model.FirstName;
            TempData["lastName"] = model.LastName;

            return RedirectToAction("ThankYou");
        }

        [HttpGet]
        public ActionResult CustomForm()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CustomForm(MyTestModel model)
        {
            if (!ModelState.IsValid) //Check for validation errors
            {
                return View(model);
            }

            foreach (string upload in Request.Files)
            {
                if (!string.IsNullOrEmpty(Request.Files[upload].FileName)) 
               {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/Uploads";
                    string filename = System.IO.Path.GetFileName(Request.Files[upload].FileName);
                    string fullFilePath = System.IO.Path.Combine(path, filename);
                    if (System.IO.File.Exists(fullFilePath)) System.IO.File.Delete(fullFilePath);
                    Request.Files[upload].SaveAs(fullFilePath);


                    TempData["imageName"] = filename;
                }
            }
            
            TempData["id"] = model.ID;
            TempData["firstName"] = model.FirstName;
            TempData["lastName"] = model.LastName;

            return RedirectToAction("ThankYou");
        }


        [HttpGet]
        public ActionResult ThankYou()
        {
            MyTestModel model = new MyTestModel();
            model.ID = (int)TempData["id"];
            model.FirstName = TempData["firstName"].ToString();
            model.LastName = TempData["lastName"].ToString();

            return View(model);
        }

    }
}