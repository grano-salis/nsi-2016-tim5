﻿using EchoCollection.WebApi.Helpers;
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
        public IHttpActionResult GetCollectionItems()
        {
            return Ok(Helper.GetCollectionsMockUp());
        }
    }
}