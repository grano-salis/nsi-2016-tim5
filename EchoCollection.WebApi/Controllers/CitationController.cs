using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
