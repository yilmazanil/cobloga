using Cobloga.Data;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cobloga.WebUI.Controllers
{
    public class PostsController : ApiController
    {
        // GET: api/posts
        public IEnumerable<CbaPost> Get()
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.ToList();
            }
        }

        // GET: api/posts/5
        public CbaPost Get(Guid id)
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.FirstOrDefault(p => p.ID == id);
            }
        }

        //// POST: api/posts
        [HttpPost]
        public IHttpActionResult Post([FromBody]string content)
        {
            var post = new CbaPost { CreatedDate = DateTime.Now, Content = content };
            using (var context = new CoblogaDataContext())
            {
                post = context.CbaPost.Add(post);
                context.SaveChanges();
            }
            return Json(post.ID);
        }

        [HttpPost]
        public void Update([FromBody]Guid postId, [FromBody]string content)
        {
            
            using (var context = new CoblogaDataContext())
            {
                var entry = context.CbaPost.FirstOrDefault(p => p.ID == postId);
                entry.Content = content;
                context.SaveChanges();
            }
        }

        //// PUT: api/posts/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/posts/5
        //public void Delete(int id)
        //{
        //}
    }
}
