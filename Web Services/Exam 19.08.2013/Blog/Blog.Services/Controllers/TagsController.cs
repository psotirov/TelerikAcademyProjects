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
using Blog.Models;
using Blog.Services.Models;
using Blog.Data;

namespace Blog.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        private BlogEntities db = new BlogEntities();

        // GET api/Tags
        public IQueryable<TagModel> GetTags(string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                int userId = this.ValidateSessionKey(sessionKey);

                var context = new BlogEntities();
                if (context.Users.Find(userId) == null)
                {
                    throw new ArgumentException("Invalid session key - user not exists");
                }

                var query = (from tagEntity in context.Tags
                                select new TagModel()
                                {
                                    Id = tagEntity.TagId,
                                    Name = tagEntity.TagName,
                                    Posts = tagEntity.Posts.Count()
                                }).AsQueryable();

                return query.OrderBy(t => t.Id);
            });
        }

        // GET api/Tags/5
        public Tag GetTag(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tag;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}