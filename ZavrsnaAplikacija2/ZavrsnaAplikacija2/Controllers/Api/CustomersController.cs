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
    public class CustomersController : ApiController
    {
        private CarRentalEntities db = new CarRentalEntities();
        // GET: api/Customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return db.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET: api/Customers/5
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.CustomerId == id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // PUT: api/Customers/5
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = db.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDb);
            db.SaveChanges();
        }
        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.CustomerId), customerDto);

        }


        // DELETE: api/Customers/5
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.CustomerId == id);
            if(customer == null)
            {
                return BadRequest();
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok(customer);
        }
    }
}
