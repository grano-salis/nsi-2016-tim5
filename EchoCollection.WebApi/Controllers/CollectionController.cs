using EchoCollection.Api.Models;
using EchoCollection.WebApi.EchoServiceClient;
using EchoCollection.WebApi.Helpers;
using EchoService.DataContracts;
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
        public string AddCollection(Models.Collection collection)
        {
            string result = string.Empty;
            AddCollectionRequest request = new AddCollectionRequest
            {
                Collection = new EchoService.DataContracts.Collection
                {
                    Description = collection.Description,
                    IsPrivate = collection.IsPrivate,
                    Title = collection.Title
                }
            };
            using (EchoCollectionClient client = new EchoCollectionClient())
            {
                client.SaveCollection(request);
            }
            // TODO: Save to database
            return string.Format("Collection {0} successfully added", result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetCollections")]
        public GetCollectionsResponse GetCollections()
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