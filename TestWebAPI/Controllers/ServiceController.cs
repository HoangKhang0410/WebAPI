using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebAPI.Controllers
{
    public class ServiceController : ApiController
    {
        // GET api/ServiceController/HelloWebAPI
        [Route("api/ServiceController/HelloWebAPI")][HttpGet]
        public IHttpActionResult HelloWebAPI()
        {
            return Ok("Chao mung ban den voi Web API!");
        }
    }
}
