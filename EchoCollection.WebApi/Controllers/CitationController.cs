using EchoCollection.WebApi.EchoServiceClient;
using EchoCollection.WebApi.Models;
using EchoService.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Http;

namespace EchoCollection.WebApi.Controllers
{
    public class CitationController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/citation/GetIEEECitationOfFirstItem")]
        public IHttpActionResult GetIEEECitationOfFirstItem()
        {
            string path = HttpContext.Current.Server.MapPath("~") + @"CSL Library\";

            var style = CiteProc.File.Load(path + @"Styles\ieee.csl");

            var processor = CiteProc.Processor.Compile(style);

            processor.DataProviders = CiteProc.Data.DataProvider.Load(path + "cit_items.json", CiteProc.Data.DataFormat.Json);

            var entries = processor.GenerateBibliography();

            var plainText = entries.First().ToPlainText();

            var html = entries.First().ToHtml();

            return Ok(plainText);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/citation/GetIEEECitations")]
        public IHttpActionResult GetIEEECitations()
        {
            string path = HttpContext.Current.Server.MapPath("~") + @"CSL Library\";

            var style = CiteProc.File.Load(path + @"Styles\ieee.csl");

            var processor = CiteProc.Processor.Compile(style);

            processor.DataProviders = CiteProc.Data.DataProvider.Load(path + "cit_items.json", CiteProc.Data.DataFormat.Json);

            var entries = processor.GenerateBibliography();

            string allEntries = "";

            foreach (var entry in entries)
            {
                HtmlString htmlstring = new HtmlString(@"<br />");
                allEntries += entry.ToHtml() + htmlstring.ToHtmlString();
            }

            return Ok(allEntries);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/citation/GetHarvardCitations")]
        public IHttpActionResult GetHarvardCitations()
        {
            string path = HttpContext.Current.Server.MapPath("~") + @"CSL Library\";

            var style = CiteProc.File.Load(path + @"Styles\elsevier-harvard.csl");

            var processor = CiteProc.Processor.Compile(style);

            processor.DataProviders = CiteProc.Data.DataProvider.Load(path + "cit_items.json", CiteProc.Data.DataFormat.Json);

            var entries = processor.GenerateBibliography();

            string allEntries = "";

            foreach (var entry in entries)
            {
                HtmlString htmlstring = new HtmlString(@"<br />");
                allEntries += entry.ToHtml() + htmlstring.ToHtmlString();
            }

            return Ok(allEntries);
        }

        [AllowAnonymous]
        [Route("api/citation/GetCitations")]
        public IHttpActionResult GetCitations(int citStyleID)
        {
            string rootPath = HttpContext.Current.Server.MapPath("~") + @"CSL Library\";
            string stylePath = rootPath + @"Styles\";
            string itemsPath = rootPath + @"cit_items.json";

            switch (citStyleID)
            {
                case 1:
                    stylePath += "ieee.csl";
                    break;
                case 2:
                    stylePath += "elsevier-harvard.csl";
                    break;
                case 3:
                    stylePath += "chicago-author-date.csl";
                    break;
                case 4:
                    stylePath += "apa-5th-edition.csl";
                    break;
                default:
                    return BadRequest();
            }

            var style = CiteProc.File.Load(stylePath);

            var processor = CiteProc.Processor.Compile(style);

            GetItemsResponse items = new GetItemsResponse();
            using (var client = new EchoCollectionClient())
            {
                items = client.GetItems();
            }

            List<CSLCompatibleItem> CSLCompatibleItems = new List<CSLCompatibleItem>(items.Items.Count);

            foreach (var item in items.Items)
            {
                CSLCompatibleItem CslItem = new CSLCompatibleItem();
                CslItem.@abstract = "bla";// item.Metadata != null ? item.Metadata.Abstract : string.Empty;
                CslItem.id = "bla";//item.ID.ToString();
                CslItem.issued = "bla";//item.Metadata != null ? item.Metadata.Date.ToString("yyyy-MM-dd") : string.Empty;
                CslItem.language = "bla";//item.Metadata != null ? item.Metadata.Language : string.Empty;
                CslItem.note = "bla";//item.Metadata != null ? item.Metadata.Extra : string.Empty;
                CslItem.publisher = "bla";//item.Metadata != null ? item.Metadata.Publisher : string.Empty;
                CslItem.title = "bla";//item.Metadata != null ? item.Title : string.Empty;
                CslItem.type = "Book";
                CslItem.URL = "bla";//item.Metadata != null ? item.Metadata.Url : string.Empty;
                CslItem.author = "sss";
                CSLCompatibleItems.Add(CslItem);
            }

            using (MemoryStream m = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(m, CSLCompatibleItems);

                processor.DataProviders = CiteProc.Data.DataProvider.Load(m, CiteProc.Data.DataFormat.Json);
            }

            var entries = processor.GenerateBibliography();

            string allEntries = "";

            foreach (var entry in entries)
            {
                HtmlString htmlstring = new HtmlString(@"<br />");
                allEntries += entry.ToHtml() + htmlstring.ToHtmlString();
            }

            return Ok(allEntries);
        }
    }
}
