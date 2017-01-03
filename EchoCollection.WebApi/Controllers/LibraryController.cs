using EchoCollection.WebApi.EchoServiceClient;
using EchoCollection.WebApi.Helpers;
using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EchoCollection.WebApi.Controllers
{
    [RoutePrefix("api/Library")]
    public class LibraryController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCollectionItems")]
        public GetCollectionsResponse GetCollectionItems()
        {
            GetCollectionsResponse response = new GetCollectionsResponse();
            using (EchoCollectionClient client = new EchoCollectionClient())
            {
                response = client.GetCollections();
            }
            return response;
        }
    }
}
