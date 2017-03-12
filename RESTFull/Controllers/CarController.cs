using Data;
using Model;
using System.Web.Http;
using TextResource;

namespace RESTFull.Controllers
{
    [RoutePrefix("api/car")]
    public class CarController : ApiController
    {
        private IRepository<Car, CarCriteria> _carRepository;

        public CarController(IRepository<Car, CarCriteria> carRepository)
        {
            _carRepository = carRepository;
        }

        [AcceptVerbs("GET")]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest(GeneralTextResource.InvalidParameter.ToString());

            var result = _carRepository.Get(id);

            if (result == null)
                return NotFound();

            return Ok(_carRepository.Get(id));
        }

        [AcceptVerbs("POST")]
        [Route("")]
        public IHttpActionResult Create(Car car)
        {
            if (car == null)
                return BadRequest(GeneralTextResource.InvalidParameter.ToString());

            var result = _carRepository.Insert(car);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [AcceptVerbs("POST")]
        [Route("list")]
        public IHttpActionResult List(CarCriteria carCriteria)
        {
            if (carCriteria == null)
                return BadRequest(GeneralTextResource.InvalidParameter.ToString());

            return Ok(_carRepository.List(carCriteria, new string[] { "Name" }));
        }
    }
}
