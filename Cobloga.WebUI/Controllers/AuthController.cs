using Cobloga.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Cobloga.Data;
using Cobloga.WebUI.CustomLibraries;

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

            using (var context = new CoblogaDataContext())
            {
                var user = context.User.FirstOrDefault(u => u.Email == model.Email);
                var password = user.Password;
                var decryptedPassword = CustomDecrypt.Decrypt(password);

                if (model.Email != null & model.Password == decryptedPassword)
                {
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email)
                }, "CoblogaCookie");

                    var authManager = Request.GetOwinContext().Authentication;
                    authManager.SignIn(identity);

                    return Redirect(GetRedirectUrl(model.ReturnUrl));
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);

        }

        public ActionResult Logout()
        {
            var authManager = Request.GetOwinContext().Authentication;
            authManager.SignOut("CoblogaCookie");
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
                using (var db = new CoblogaDataContext())
                {
                    var encryptedPassword = CustomEncrypt.Encrypt(model.Password);
                    var user = db.User.Create();
                    user.Email = model.Email;
                    user.Password = encryptedPassword;
                    user.Name = model.Name;
                    db.User.Add(user);
                    db.SaveChanges();
                }
                RedirectToAction("Index", "Home");
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