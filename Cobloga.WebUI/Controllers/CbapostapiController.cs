using Cobloga.Data;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cobloga.WebUI.Controllers
{
    public class CbapostapiController : ApiController
    {
        // GET: api/Cbapostapi
        public IEnumerable<CbaPost> Get()
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.ToList();
            }
        }

        // GET: api/Cbapostapi/5
        public CbaPost Get(Guid id)
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.FirstOrDefault(p => p.ID == id);
            }
        }

        //// POST: api/Cbapostapi
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

        //// PUT: api/Cbapostapi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Cbapostapi/5
        //public void Delete(int id)
        //{
        //}
    }
}
