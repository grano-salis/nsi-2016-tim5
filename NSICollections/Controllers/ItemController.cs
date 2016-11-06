using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSICollections.Models;

namespace NSICollections.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult AddItem(ItemViewModel model)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult GetItemMetadata(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult ExportItemToPlainText(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult ExportItemToHTML(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult UpdateItemMetadata(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult DeleteItem(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}