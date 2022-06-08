using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace u21460494_HW03.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }


        //Single File Upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, FormCollection rad)
        {
            //to get radio button data
            string radioSelector = rad["Radio"].ToString();

            //used to check it was working
            //ViewBag.Message = ratioSelector;

            if (radioSelector == "Document")
            {
                // Verify that the user selected a file
                // Not null and has a length

                if (files != null && files.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside "~/Media/Documents/" folder

                    var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                // redirect back to the index action to show the form once again

                return View();
            }





            if (radioSelector == "Images")
            {
                // Verify that the user selected a file
                // Not null and has a length

                if (files != null && files.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside "~/Media/Documents/" folder

                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                // redirect back to the index action to show the form once again

                return View();
            }



            if (radioSelector == "Videos")
            {
                // Verify that the user selected a file
                // Not null and has a length

                if (files != null && files.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside "~/Media/Documents/" folder

                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                // redirect back to the index action to show the form once again

                return View();
            }

            return View();
        }


        public ActionResult About()
        {

            return View();
        }

    }
}


