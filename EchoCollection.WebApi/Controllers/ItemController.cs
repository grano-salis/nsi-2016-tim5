using EchoCollection.Api.Models;
using EchoCollection.WebApi.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EchoCollection.WebApi.Controllers
{ 
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {
        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        [Route("AddItem")]
        public string AddItem(Item item)
        {
            item.Metadata.Date = DateTime.Now;
            // Save To Database
            return string.Format("Item with title: '{0}', Document Type: '{1}' has been added successfully.", item.Title, item.DocumentType);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetItems")]
        public IHttpActionResult GetItems()
        {
            return Ok(Helper.GetItemsMockUp());
        }
    }
}