using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;


namespace UmbracoDemo1.Demo.Demo23
{
    public class ImageGallerySurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index(int galleryId)
        {
            ImageGalleryModel m = new ImageGalleryModel();
            m.GalleryId = galleryId;
            return PartialView("Demo23/ImageGalleryForm", m);
        }

        [HttpPost]
        public ActionResult HandlePost(ImageGalleryModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            foreach (var file in model.Files)
            {
                var media = Services.MediaService.CreateMedia(file.FileName, model.GalleryId, "image");
                media.SetValue("umbracoFile", file);
                Services.MediaService.Save(media);
            }


            TempData["Feedback"] = "Thank you for publishing images";
            return RedirectToCurrentUmbracoPage();
        }
    }
}