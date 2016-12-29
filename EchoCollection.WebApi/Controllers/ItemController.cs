using EchoCollection.Api.Models;
using EchoCollection.WebApi.EchoServiceClient;
using EchoCollection.WebApi.Helpers;
using EchoService.DataContracts;
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
        public string AddItem(Api.Models.Item item)
        {
            item.Metadata.Date = DateTime.Now;
            AddItemRequest request = new AddItemRequest();
            request.Item = new EchoService.DataContracts.Item
            {
                DocumentTypeId = 2,
                IsPrivate = item.IsPrivate,
                Title = item.Title,
                Metadata = new Metadata
                {
                    Abstract = item.Metadata.Abstract,
                    Author = item.Metadata.Author,
                    Date = item.Metadata.Date,
                    Extra = item.Metadata.Extra,
                    Language = item.Metadata.Language,
                    Publisher = item.Metadata.Publisher,
                    Rights = item.Metadata.Rights,
                    Url = item.Metadata.Url
                }
            };
            using (var client = new EchoCollectionClient())
            {
                client.SaveItem(request);
            }

            return string.Format("Item with title: '{0}', Document Type: '{1}' has been added successfully.", item.Title, item.DocumentType);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetItems")]
        public GetItemsResponse GetItems()
        {
            GetItemsResponse response = new GetItemsResponse();
            using (var client = new EchoCollectionClient())
            {
                response = client.GetItems();
            }
            return response;
        }
    }
}