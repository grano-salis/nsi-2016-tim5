using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EchoCollection.WebApi.Controllers
{
    public class AttachmentController : Controller
    {
        // GET: Attachment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var file = Request.Files[0];
            var path = Path.Combine(Server.MapPath("~/Photos/") + file.FileName);
            file.SaveAs(path);

            // prepare a relative path to be stored in the database and used to display later on.
            path = Url.Content(Path.Combine("~/Photos/" + file.FileName));
            // save to db
            return Json(path.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}