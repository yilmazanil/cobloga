using Cobloga.Data;
using Cobloga.Data.DataModel;
using Cobloga.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cobloga.WebUI.Controllers
{
    public class PostController : Controller
    {
        // GET: CbaPost
        public ActionResult Index(Guid postId)
        {
            using (var context = new CoblogaDataContext())
            {
                var model = context.CbaPost.FirstOrDefault(p => p.ID == postId);
                return View(model);
            }
           
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(Guid postId)
        {
            using (var context = new CoblogaDataContext())
            {
                var entry = context.CbaPost.FirstOrDefault(p => p.ID == postId);
                return View(entry);
            }
        }
    }
}