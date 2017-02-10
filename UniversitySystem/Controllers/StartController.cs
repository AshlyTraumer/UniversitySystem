using ClassLibrary.Authorization;
using System.Web.Mvc;
using UniversitySystem.Models;
using UniversitySystem.Manager;
using UniversitySystem.Core;

namespace UniversitySystem.Controllers
{
    public class StartController : Controller
    {
        public AuthorizeManager Manager => new AuthorizeManager(HttpContext.GetContextPerRequest());

        /* private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }   */            

        [HttpGet]
        [Route("Start/Singin")]
        public ActionResult Login()
        {
            // var list = new SpecialityMinMaxQuery(new RepositoryContext()).Get(2);
           // Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
           // Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");


            return View();
        }

        

        [HttpPost]
        [Route("Start/Singin")]
        public ActionResult Login(LoginModel model)
        {
            //  var claimsIdentity = new ClaimsIdentity();
            //   claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //  claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            //  AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

            if (ModelState.IsValid)
            {
                var role = Manager.Login(model);

                if (role == null)
                {
                    ModelState.AddModelError("", "Incorrect password");
                    return View();
                }
                
                
                switch ((Role)role.Value.RoleSet)
                {
                    case Role.Admin: return RedirectToAction("Index", "Admin");
                    case Role.Secretary: return RedirectToAction("Index", "Secretary");
                    case Role.Committee: return RedirectToAction("Index", "Committee");
                    default: return RedirectToAction("Index", "Admin");
                }
            }
            else
                return View(model);
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}