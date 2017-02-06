using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTFull.Controllers
{
    [RoutePrefix("api/car")]
    public class CarController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("{id}")]
        public Car Get(int id)
        {
            return null;
        }
    }
}
