using EchoCollection.Api.Models;
using EchoCollection.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EchoCollection.Api.Controllers
{
    [RoutePrefix("api/Collection")]
    public class CollectionController : ApiController
    {
        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        [Route("AddCollection")]
        public string AddCollection(Collection collection)
        {
            string result = string.Empty;
            // TODO: Save to database
            return string.Format("Collection {0} successfully added", result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetCollections")]
        public IHttpActionResult GetCollections()
        {
            return Ok(Helper.GetCollectionsMockUp());
        }
    }
}