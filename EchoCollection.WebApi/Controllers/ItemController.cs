using EchoCollection.Api.Models;
using EchoCollection.WebApi.EchoServiceClient;
using EchoCollection.WebApi.Helpers;
using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
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
                DocumentTypeId = item.DocumentType.ID,
                CollectionId = item.CollectionId,
                ID = item.ID,
                IsPrivate = item.IsPrivate,
                Title = item.Title,
                Attachment = item.Attachment,
                Metadata = new Metadata
                {
                    ID = item.Metadata.ID,
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
                if (item.ID == 0)
                    client.AddItem(request);
                else
                    client.UpdateItem(request);
            }

            return string.Format("Item with title: '{0}', Document Type: '{1}' has been added successfully.", item.Title, item.DocumentType);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("AddAttachment")]
        public string AddAttachment(object attachment)
        {
            
            return string.Format("Item with title: '{0}', Document Type: '{1}' has been added successfully.", "" ,"");
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

        [HttpGet]
        [AllowAnonymous]
        [Route("GetDocTypes")]
        public GetDocumentTypeResponse GetDocTypes()
        {
            GetDocumentTypeResponse response = new GetDocumentTypeResponse();
            using (var client = new EchoCollectionClient())
            {
                response = client.GetDocTypes();
            }
            return response;
        }
    }
}