using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZavrsnaAplikacija2.Dtos;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private CarRentalEntities db = new CarRentalEntities();
        // GET: api/Rentals
        [HttpGet]
        public IEnumerable<RentalDto> GetRentals()
        {
            return db.Rentals.ToList().Select(Mapper.Map<Rental, RentalDto>);
        }

        // GET: api/Rentals/5
        [HttpGet]
        public IHttpActionResult GetRental(int id)
        {
            var rental = db.Rentals.SingleOrDefault(r => r.RentalId == id);
            if(rental == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        // PUT: api/Rentals/5
        [HttpPut]
        public void UpdateRental(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var rentalInDb = db.Rentals.SingleOrDefault(r => r.RentalId == id);
            if(rentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(rentalDto, rentalInDb);
            db.SaveChanges();

        }

        // POST: api/Rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var rental = Mapper.Map<RentalDto, Rental>(rentalDto);
            db.Rentals.Add(rental);
            db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + rental.RentalId), rentalDto);
        }


        // DELETE: api/Rentals/5
        [HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            var rental = db.Rentals.SingleOrDefault(r => r.RentalId == id);
            if(rental == null)
            {
                return NotFound();
            }
            db.Rentals.Remove(rental);
            db.SaveChanges();

            return Ok(rental);
        }
    }
}
