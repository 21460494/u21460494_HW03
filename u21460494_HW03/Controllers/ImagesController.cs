using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using u21460494_HW03.Models;

namespace u21460494_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            //Fetch all files in the Images Folder .

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> images = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                images.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(images);
            
        }


        public FileResult DownloadImage(string fileName) 
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Images/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream/", fileName);
        }

        public ActionResult DeleteImage(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Images/") + fileName;

             byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}