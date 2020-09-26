using EShopWebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebAPI1.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        private EShopEntities eshopentities = new EShopEntities();
        public HttpResponseMessage Get()
        {
            try
            {
                var result = eshopentities.Customers.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // GET: api/Customer/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Customer customer = eshopentities.Customers.Find(id);
                return customer != null ? Request.CreateResponse(HttpStatusCode.Found, customer) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Customer
        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            try
            {
                Customer cus = eshopentities.Customers.Add(customer);
                eshopentities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, cus);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Customer/5
        public HttpResponseMessage Put(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer cus = eshopentities.Customers.Find(id);
                cus.Fullname = customer.Fullname;
                cus.Gender = customer.Gender;
                cus.Birthday = customer.Birthday;
                cus.Address = customer.Address;
                cus.Email = customer.Email;
                cus.PhoneNumber = customer.PhoneNumber;
                eshopentities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Customer/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Customer customer = eshopentities.Customers.Find(id);
                if (customer != null)
                {
                    eshopentities.Customers.Remove(customer);
                    eshopentities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Search
        public HttpResponseMessage GetCustomerByAddress(string address)
        {
            try
            {
                eshopentities = new EShopEntities();
                IQueryable<Customer> result = eshopentities.Customers.Where(cus => cus.Address.ToLower().IndexOf(address.ToLower()) >= 0);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
