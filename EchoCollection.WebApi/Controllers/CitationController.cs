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
        public IHttpActionResult GetIEEECitationOfFirstItem()
        {
            string path = HttpContext.Current.Server.MapPath("~") + @"CSL Library\";

            var style = CiteProc.File.Load(path + @"Styles\ieee.csl");

            var processor = CiteProc.Processor.Compile(style);

            processor.DataProviders = CiteProc.Data.DataProvider.Load(path + "cit_item1.json", CiteProc.Data.DataFormat.Json);

            var entries = processor.GenerateBibliography();

            var plainText = entries.First().ToPlainText();

            var html = entries.First().ToHtml();

            return Ok(plainText);
        }
    }
}
