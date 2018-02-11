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
                return context.CbaPost.Where(p=>p.Content != null && p.Content != "").ToList();
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
        [HttpPut]
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
        public IHttpActionResult Update([FromBody]CbaPost post)
        {

            using (var context = new CoblogaDataContext())
            {
                var entry = context.CbaPost.FirstOrDefault(p => p.ID == post.ID);
                entry.Content = post.Content;
                context.SaveChanges();
            }
            return Json(post.ID);
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
