using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class BaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("our version is v1");
        }
    }
}
