using Cobloga.Data;
using Cobloga.Data.DataModel;
using Cobloga.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Cobloga.WebUI.Controllers
{
    public class PostsController : ApiController
    {
        // GET: api/posts
        public IEnumerable<CbaPostViewModel> Get()
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.Where(p => p.Content != null && p.Content != "")
                    .Select(p=>new CbaPostViewModel {  Content = p.Content, CreatedDate= p.CreatedDate, UserId = p.UserId, ID = p.ID }).ToList();
            }
        }

        // GET: api/posts/5
        public CbaPostViewModel Get(Guid id)
        {

            using (var context = new CoblogaDataContext())
            {
                var model =  context.CbaPost.FirstOrDefault(p => p.ID == id);
                return new CbaPostViewModel { Content = model.Content, CreatedDate = model.CreatedDate, UserId = model.UserId, ID = model.ID };
            }
        }

        //// POST: api/posts
        [HttpPut]
        public IHttpActionResult Post([FromBody]string content)
        {
            Claim sessionEmail = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Email);
            string userEmail = sessionEmail.Value;
            using (var context = new CoblogaDataContext())
            {
                var user = context.User.FirstOrDefault(u => u.Email == userEmail);

                var post = new CbaPost { CreatedDate = DateTime.Now, Content = content };
                if (user != null)
                {
                    post.UserId = user.Id;
                }
                post = context.CbaPost.Add(post);
                context.SaveChanges();
                return Json(post.ID);
            }
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
