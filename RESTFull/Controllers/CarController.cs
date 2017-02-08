using Data;
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
        private IRepository<Car> _carRepository;

        public CarController(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        [AcceptVerbs("GET")]
        [Route("{id}")]
        public Car Get(int id)
        {
            return _carRepository.Get(id);
        }
    }
}
