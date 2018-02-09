using Cobloga.Data;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cobloga.WebUI.Controllers
{
    public class CbaPostController : ApiController
    {
        // GET: api/CbaPost
        public IEnumerable<CbaPost> Get()
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.ToList();
            }
        }

        // GET: api/CbaPost/5
        public CbaPost Get(Guid id)
        {
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.FirstOrDefault(p => p.ID == id);
            }
        }

        //// POST: api/CbaPost
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/CbaPost/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/CbaPost/5
        //public void Delete(int id)
        //{
        //}
    }
}
