using Cobloga.WebUI.Models;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Cobloga.Business.Authentication;
using Cobloga.Data.DataModel;
using Cobloga.WebUI.Authentication;

namespace Cobloga.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private IAuthenticationProvider authProvider;

        public AuthController()
        {
            authProvider = new AuthenticationProvider(new CustomEncryptor(), Request);
        }

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

            var requestUser = new User { Email = model.Email, Password = model.Password };
            if (authProvider.SignIn(requestUser))
            {
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
       
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }

        public ActionResult Logout()
        {
           authProvider.SignOut();
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
                if (authProvider.Register(user))
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