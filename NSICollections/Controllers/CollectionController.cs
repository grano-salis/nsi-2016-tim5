using NSICollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NSICollections.Controllers
{
    public class CollectionController : Controller
    {
        public ActionResult CreateCollection(CollectionViewModel model)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult AddItemToCollection(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);  
        }

        public ActionResult GetCollection(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        
        public ActionResult RemoveItemFromCollection(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public ActionResult DeleteCollection(int id)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}