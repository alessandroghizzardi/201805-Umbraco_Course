using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoDemo1.Demo.Demo23
{
    public class ImageGalleryModel
    {
        public int GalleryId { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}