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
        public IHttpActionResult Example()
        {
            string path = HttpContext.Current.Server.MapPath("~") + @"CSL Library\";
            // Load a style from disk (or use one of the overloads for reading
            // from a stream, a text reader or an xml reader).
            var style = CiteProc.File.Load(path + @"Styles\elsevier-harvard.csl");

            // Compile the style to get a processor instance.
            var processor = CiteProc.Processor.Compile(style);

            // Data of the referenced items (books, articles, etc.) is accessed
            // through the IDataProvider interface. CiteProc.NET comes with a
            // default implementation of this interface that supports the
            // CSL JSON format.
            processor.DataProviders = CiteProc.Data.DataProvider.Load(path + "cit_item1.json", CiteProc.Data.DataFormat.Json);

            // Now, you are ready to render citations and bibliographies using
            // the selected style:
            var entries = processor.GenerateBibliography();

            // The result is an instance of a CiteProc.Formatting.Run class.
            // This instance can then be converted to the desired format. CiteProc
            // supports plain text and HTML out-of-the-box; the CiteProc.WpfDemo
            // project contains an example of how to show the result in a WPF
            // TextBlock. Other formats can be added easily.

            // Austen, J. (1995) Pride and Prejudice. New York, NY: Dover Publications.
            var plainText = entries.First().ToPlainText();

            // Austen, J. (1995) <i>Pride and Prejudice</i>. New York, NY: Dover Publications.
            var html = entries.First().ToHtml();

            return Ok();
        }
    }
}
