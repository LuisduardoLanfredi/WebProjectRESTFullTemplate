using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace Data
{
    public class CarRepository : IRepository<Car, CarCriteria>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["WebProjectRESTFullTemplateConnectionString"].ConnectionString;

        public Car Get(int id)
        {
            var sql = @"SELECT Id, Name, Color FROM Cars WHERE Id = @Id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Car>(sql, new { @Id = id }).SingleOrDefault();
            }
        }

        public Car Insert(Car car)
        {
            Car createdCar;

            var sql = @"INSERT INTO Cars (Name, Color) 
                        OUTPUT Inserted.*
                        VALUES (@Name, @Color)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                createdCar = conn.Query<Car>(sql, car).SingleOrDefault();
            }

            return createdCar;
        }

        public IEnumerable<Car> List(CarCriteria criteria, string[] fields)
        {
            var builder = new SqlBuilder();

            var template = builder.AddTemplate("SELECT /**select**/ FROM Cars /**where**/");

            if (fields.Any())
                builder.Select(string.Join(", ", fields));
            else
                builder.Select("Id");

            if(criteria.Id.Any())
            {
                builder.Where("Id IN @Id", new { @Id = criteria.Id});
            }

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Car>(template.RawSql, template.Parameters);
            }
        }

        public Car Delete(int id)
        {
            var sql = "DELETE From Cars OUTPUT DELETED.* WHERE Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Car>(sql, new { @Id = id }).SingleOrDefault();
            }
        }
    }
}
