using Cobloga.Business.Authentication;
using Cobloga.Business.Services;
using Cobloga.Business.ViewModel;
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
    [Route("api/blogpost/")]
    public class BlogPostApiController : ApiController
    {
        private BlogPostService blogPostService = new BlogPostService();

        public IEnumerable<BlogPostViewModel> Get()
        {
            return blogPostService.FetchAll();
        }

        public BlogPostViewModel Get(Guid id)
        {

            return blogPostService.FetchById(id);
        }

        [HttpPut]
        public IHttpActionResult Post([FromBody]BlogPostViewModel post)
        {
           var result =  blogPostService.Create(post);
           return Json(result);
        }


        [HttpPost]
        public IHttpActionResult Update([FromBody]BlogPostViewModel post)
        {

            blogPostService.Update(post);
            return Json(post.ID);
        }
    }
}
