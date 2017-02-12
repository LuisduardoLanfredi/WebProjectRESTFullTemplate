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
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest("Invalid parameter");

            var result = _carRepository.Get(id);

            if (result == null)
                return NotFound();

            return Ok(_carRepository.Get(id));
        }

        [AcceptVerbs("POST")]
        [Route("car")]
        public IHttpActionResult Create(Car car)
        {
            if (car == null)
                return BadRequest("Invalid parameter");

            var result = _carRepository.Insert(car);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }
    }
}
