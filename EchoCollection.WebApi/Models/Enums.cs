using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoCollection.WebApi.Models
{
    public enum DocumentType
    {
        Unknown = 0,
        Book =  1,
        Image = 2
    }

    public enum CitationStyleEnum
    {
        IEEE=1,
        Harvard,
        Chicago,
        APA5thEd
    }
}