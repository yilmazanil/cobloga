using Cobloga.WebUI.Models;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Cobloga.Business.Authentication;
using Cobloga.Data.DataModel;

namespace Cobloga.WebUI.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (AuthenticationHelper.Authenticate(model.Email, model.Password))
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, model.Email) }, "CoblogaCookie");
                Request.GetOwinContext().Authentication.SignIn(identity);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
       
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }

        public ActionResult Logout()
        {
           Request.GetOwinContext().Authentication.SignOut("CoblogaCookie"); ;
           return RedirectToAction("Index", "Home");
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                };
                if (AuthenticationHelper.Register(user))
                {
                    RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password");
            }
            return View(model);
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }
    }
}