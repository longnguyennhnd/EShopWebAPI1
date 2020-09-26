using EShopWebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebAPI1.Controllers
{
    public class ProductController : ApiController
    {
        private EShopEntities eshopentities = new EShopEntities();
        // GET: api/Product
        public HttpResponseMessage Get()
        {
            try
            {
                var result = eshopentities.Products.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // GET: api/Product/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Product Product = eshopentities.Products.Find(id);
                return Product != null ? Request.CreateResponse(HttpStatusCode.Found, Product) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody] Product product)
        {
            try
            {
                Product pro = eshopentities.Products.Add(product);
                eshopentities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, pro);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Product/5
        public HttpResponseMessage Put(int id, [FromBody] Product product)
        {
            try
            {
                Product pro = eshopentities.Products.Find(id);
                pro.ProductName = product.ProductName;
                pro.CategoryID = product.CategoryID;
                pro.UnitPrice = product.UnitPrice;
                pro.Quantity = product.Quantity;
                eshopentities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Product product = eshopentities.Products.Find(id);
                if (product != null)
                {
                    eshopentities.Products.Remove(product);
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
    }
}
