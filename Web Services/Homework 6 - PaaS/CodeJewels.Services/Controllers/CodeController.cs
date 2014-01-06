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
    public class CodeController : ApiController
    {
        private CodeJewelsEntities db = new CodeJewelsEntities();

        // GET api/Code
        public IEnumerable<CodeJewel> GetCodeJewels()
        {
            var codejewels = db.CodeJewels.Include(c => c.Category);
            return codejewels.AsEnumerable();
        }

        // GET api/Code/5
        public CodeJewel GetCodeJewel(int id)
        {
            CodeJewel codejewel = db.CodeJewels.Find(id);
            if (codejewel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return codejewel;
        }

        [HttpGet]
        [ActionName("votedown")]
        public HttpResponseMessage VoteDown(int id)
        {
            var result = db.CodeJewels.Find(id);
            HttpResponseMessage responce;

            if (result != null)
            {
                result.Rating -= 1;
                if (result.Rating < -10)
                {
                    db.CodeJewels.Remove(result);
                }
                db.SaveChanges();
                responce = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                responce = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return responce;
        }

        [HttpGet]
        [ActionName("voteup")]
        public HttpResponseMessage VoteUp(int id)
        {
            var result = db.CodeJewels.Find(id);
            HttpResponseMessage responce;

            if (result != null)
            {
                result.Rating += 1;
                db.SaveChanges();
                responce = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                responce = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return responce;
        }

        [HttpGet]
        [ActionName("search")]
        public IEnumerable<CodeJewel> SearchCode(string code)
        {
            var result = (from c in this.db.CodeJewels
                         where c.Content.Contains(code)
                         select c).AsEnumerable();

            return result;
        }

        [HttpGet]
        [ActionName("search")]
        public IEnumerable<CodeJewel> SearchCategory(int categoryId)
        {
            var result = (from c in this.db.CodeJewels
                         where c.CategoryId == categoryId
                         select c).AsEnumerable();

            return result;
        }


        // POST api/Code
        public HttpResponseMessage PostCodeJewel(CodeJewel codejewel)
        {
            if (ModelState.IsValid)
            {
                db.CodeJewels.Add(codejewel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, codejewel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = codejewel.Id }));
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