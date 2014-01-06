using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CodeJewels.Models;
using CodeJewels.DataLayer;

namespace CodeJewels.Services.Controllers
{
    public class CategoryController : ApiController
    {
        private CodeJewelsEntities db = new CodeJewelsEntities();

        // GET api/Category
        public IEnumerable<Category> GetCategories()
        {
            return db.JewelCategories.AsEnumerable();
        }

        // GET api/Category/5
        public Category GetCategory(int id)
        {
            Category category = db.JewelCategories.Find(id);
            if (category == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return category;
        }

        // POST api/Category
        public HttpResponseMessage PostCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.JewelCategories.Add(category);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, category);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = category.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}