using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Model;
using FizzWare.NBuilder;
using Faker;
using Migration;
using System.Linq;

namespace DataTest
{
    [TestClass]
    public class CarRepositoryTest
    {
        private WebProjectRESTFullTemplate _dbContext;
        public CarRepositoryTest()
        {
            _dbContext = new WebProjectRESTFullTemplate();
        }

        [TestMethod]
        public void Should_AddNewCar()
        {
            var target = new CarRepository();

            var car = Builder<Car>.CreateNew().Build();

            var result = target.Insert(car);

            Assert.IsNotNull(car?.Id);
            Assert.AreEqual(car.Color, result.Color);
            Assert.AreEqual(car.Name, result.Name);
        }

        [TestMethod]
        public void Should_GetExistentCar()
        {
            var target = new CarRepository();

            var car = Builder<Car>.CreateNew().Build();

            var existingCar = _dbContext.Car.Add(car);

            var result = target.Get(existingCar.Id);

            Assert.AreEqual(existingCar.Id, result.Id);
            Assert.AreEqual(existingCar.Color, result.Color);
            Assert.AreEqual(existingCar.Name, result.Name);
        }

        [TestMethod]
        public void Should_DeleteAExistentCar()
        {
            var existingCar = Builder<Car>.CreateNew().Build();

            existingCar = _dbContext.Car.Add(existingCar);
            _dbContext.SaveChanges();

            var target = new CarRepository();

            target.Delete(existingCar.Id);

            existingCar = _dbContext.Car.Where(x => x.Id == existingCar.Id).SingleOrDefault();
            Assert.IsNull(existingCar);
        }

        [TestMethod]
        public void Should_ListExistentCar()
        {
            var target = new CarRepository();

            var existingCars = Builder<Car>.CreateListOfSize(5).Build();

            existingCars = _dbContext.Car.AddRange(existingCars.ToArray()).ToList();
            _dbContext.SaveChanges();

            var criteria = new CarCriteria()
            {
                Id = existingCars.Select(x => x.Id)
            };

            var result = target.List(criteria, new string[] {"Id", "Name", "Color"}).ToList();

            Assert.AreEqual(existingCars.Count(), result.Count());

            for(int i = 0; i < existingCars.Count(); i++)
            {
                Assert.AreEqual(existingCars[i].Id, result[i].Id);
                Assert.AreEqual(existingCars[i].Name, result[i].Name);
                Assert.AreEqual(existingCars[i].Color, result[i].Color);
            }
        }
    }
}
