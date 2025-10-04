using DataAccess.Models.IdentityModule;
using Demo.Presentation.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager) : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Regist(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var user = new ApplicationUser()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Username,
                        Email = model.Email,

                    };
                    var res = _userManager.CreateAsync(user, model.Password).Result;
                    if (res.Succeeded)
                        return RedirectToAction("Login");
                    else
                    {
                        foreach (var item in res.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Account can not created");
                }
            }

            return View(model);


        }
        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {
            if (ModelState.IsValid) { 
                
                var user= _userManager.FindByEmailAsync(model.Email).Result;
                if(user is not null)
                {
                    var flag= _userManager.CheckPasswordAsync(user, model.Password).Result;

                    if (flag)
                    {
                     var result =   _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,false).Result;

                        if (result.IsNotAllowed)
                            ModelState.AddModelError("", "your account is not allowed");
                        if (result.IsLockedOut)
                            ModelState.AddModelError("", "your account is locked");
                        if (result.Succeeded)
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                    
                    }
                }
                ModelState.AddModelError("", "Login Invalid");
            }
                return View(model);
        }
        #endregion

        #region SignOut

        [HttpGet]
        public new IActionResult SignOut()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(Login));
        }
        #endregion
    }
}
