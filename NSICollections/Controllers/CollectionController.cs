using NSICollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NSICollections.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Save(CollectionViewModels model)
        {
            return View(model);
        }
    }
}