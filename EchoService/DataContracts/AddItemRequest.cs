﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EchoService.DataContracts
{
    [DataContract]
    public class AddItemRequest
    {
        [DataMember]
        public Item Item { get; set; }
    }
}