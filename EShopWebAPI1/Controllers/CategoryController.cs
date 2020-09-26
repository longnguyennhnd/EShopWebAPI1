using EShopWebAPI1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopWebAPI1.Models;
namespace EShopWebAPI1.Controllers
{
    public class CategoryController : ApiController
    {
        private EShopEntities eshopentities = new EShopEntities();
        // GET: api/Category
        public HttpResponseMessage Get()
        {
            try
            {
                var result = eshopentities.Categories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        // GET: api/Category/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Category category = eshopentities.Categories.Find(id);
                return category!= null ? Request.CreateResponse(HttpStatusCode.Found, category) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Category
        public HttpResponseMessage Post([FromBody] Category category)
        {
            try
            {
                Category cate = eshopentities.Categories.Add(category);
                eshopentities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, cate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Category/5
        public HttpResponseMessage Put(int id, [FromBody] Category category)
        {
            try
            {
                Category cate = eshopentities.Categories.Find(id);
                cate.CategoryName = category.CategoryName;
                cate.Description = category.Description;
                eshopentities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Category category = eshopentities.Categories.Find(id);
                if (category != null)
                {
                    eshopentities.Categories.Remove(category);
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
