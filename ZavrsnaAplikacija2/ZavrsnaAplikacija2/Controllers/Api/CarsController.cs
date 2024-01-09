using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ZavrsnaAplikacija2.Dtos;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2.Controllers.Api
{
    public class CarsController : ApiController
    {
        private CarRentalEntities db = new CarRentalEntities();

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<CarDto> GetCars()
        {
            return db.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
        }
        // GET: api/Cars/5
        [HttpGet]
        public IHttpActionResult GetCar(int id)
        {
            var car = db.Cars.SingleOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();          
            }
            return Ok(Mapper.Map<Car, CarDto>(car));
        }

        // PUT: api/Cars/5
        [HttpPut]
        public void UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var carInDb = db.Cars.SingleOrDefault(c => c.CarId == id);
            if(carInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(carDto, carInDb);
            db.SaveChanges();
        }

        // POST: api/Cars
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var car = Mapper.Map<CarDto, Car>(carDto);
            db.Cars.Add(car);
            db.SaveChanges();
            carDto.CarId = car.CarId;
            return Created(new Uri(Request.RequestUri + "/" + car.CarId), carDto);
        }


        // DELETE: api/Cars/5
        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.SingleOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CarExists(int id)
        //{
        //    return db.Cars.Count(e => e.CarId == id) > 0;
        //}
    }
}