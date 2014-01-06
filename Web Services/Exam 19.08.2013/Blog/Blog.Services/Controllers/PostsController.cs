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
    public class PostsController : BaseApiController
    {
        // GET api/Posts?sessionKey=xxxxxxx
        public IQueryable<PostDetailsModel> GetAllPosts(string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                int userId = this.ValidateSessionKey(sessionKey);

                var context = new BlogEntities();
                if (context.Users.Find(userId) == null)
                {
                    throw new ArgumentException("Invalid session key - user not exists");
                }

                var query =
                    (from postEntity in context.Posts
                        select new PostDetailsModel()
                        {
                            Id = postEntity.PostId,
                            Title = postEntity.Title,
                            PostedBy = postEntity.User.DisplayName,
                            PostDate = postEntity.PostDate,
                            Text = postEntity.Text,
                            Tags = (from tagEntity in postEntity.Tags
                                    select tagEntity.TagName),
                            Comments = (from commentEntity in postEntity.Comments
                                        select new CommentDetailsModel()
                                        {
                                            Text = commentEntity.CommentText,
                                            CommentedBy = commentEntity.User.DisplayName,
                                            PostDate = commentEntity.PostDate
                                        })
                        });

                return query.OrderByDescending(p => p.PostDate);
            });
        }

        // GET api/Posts?sessionKey=xxxxxxx&page=5&count=3
        public IQueryable<PostDetailsModel> GetPage(string sessionKey, int page, int count)
        {
            var query = this.GetAllPosts(sessionKey)
                .Skip(page * count)
                .Take(count);
            return query;
        }

        // GET api/Posts?sessionKey=xxxxxxx&keyword=yyyy
        public IQueryable<PostDetailsModel> GetByKeyword(string sessionKey, string keyword)
        {
            var query = this.GetAllPosts(sessionKey)
                .Where(p => p.Title.Contains(keyword));
            return query;
        }

        // GET api/Posts?sessionKey=xxxxxxx&tags=yyyy,zzzz,....
        public IQueryable<PostDetailsModel> GetByTags(string sessionKey, string tags)
        {
            var tagList = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var query = this.GetAllPosts(sessionKey)
                .Where(p => tagList.All(t => p.Tags.Any(k => k == t)));
            return query;
        }
        
        // PUT api/posts/{postId}/comment
        [ActionName("comment")]
        //public HttpResponseMessage PutComment(int Id, [FromUri] string sessionKey, [FromBody] string text)
        public HttpResponseMessage PutComment(int Id, [FromUri] string sessionKey, CommentSimpleModel comment)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Invalid model binding state");
                    // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                int userId = this.ValidateSessionKey(sessionKey);

                if (comment.Text.Length == 0)
                {
                    throw new ArgumentException("Comment text should not be empty");
                }

                using (var context = new BlogEntities())
                {
                    var currentUser = context.Users.Find(userId);
                    if (currentUser == null)
                    {
                        throw new ArgumentException("Invalid session key - user not exists");
                    }

                    using (var scope = new System.Transactions.TransactionScope())
                    {
                        var selectedPost = context.Posts.Find(Id);
                        if (selectedPost == null)
                        {
                            throw new ArgumentException("Invalid post Id - post not exists");                            
                        }

                        var newComment = new Comment()
                        {
                            CommentText = comment.Text,
                            PostDate = DateTime.Now,
                            Post = selectedPost,
                            User = currentUser
                        };

                        context.Comments.Add(newComment);
                        context.SaveChanges();
                        scope.Complete();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            });
        }

        // POST api/Posts
        public HttpResponseMessage PostPost([FromUri] string sessionKey, [FromBody] PostModel post)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("Invalid model binding state");
                    // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                int userId = this.ValidateSessionKey(sessionKey);

                if (post.Title.Length == 0 || post.Text.Length == 0)
                {
                    throw new ArgumentException("Post Title and Text should not be empty");
                }

                // Add title tags to the existing list of tags
                string[] titleTags = post.Title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var tag in titleTags)
                {
                    if (!post.Tags.Contains(tag))                    
                    {
                        post.Tags.Add(tag);
                    }
                }

                using (var context = new BlogEntities())
                {
                    if (context.Users.Find(userId) == null)
                    {
                        throw new ArgumentException("Invalid session key - user not exists");
                    }

                    using (var scope = new System.Transactions.TransactionScope())
                    {
                        var newPost = new Post()
                        {
                            Title = post.Title,
                            Text = post.Text,
                            User = context.Users.Find(userId),
                            PostDate = DateTime.Now
                        };

                        foreach (var tag in post.Tags)
                        {
                            var tagToLower = tag.ToLower();
                            var newTag = context.Tags.FirstOrDefault(t => t.TagName == tagToLower);
                            if (newTag == null)
                            {
                                newTag = new Tag() { TagName = tagToLower };
                                context.Tags.Add(newTag);
                            }

                            newPost.Tags.Add(newTag);
                        }

                        context.Posts.Add(newPost);
                        context.SaveChanges();
                        scope.Complete();

                        return Request.CreateResponse(HttpStatusCode.Created, new
                        {
                            Title = newPost.Title,
                            Id = newPost.PostId
                        });
                    }
                }
            });
        }
    }
}