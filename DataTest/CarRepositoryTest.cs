using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Model;
using FizzWare.NBuilder;
using Faker;
using Migration;

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
    }
}
