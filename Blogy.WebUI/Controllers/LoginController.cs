using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel model)
        {
            maleef:( istersen projeyi bana gönderebilirsen kendi pc'imde bakıyım çok teşekkür ederim göndereyim vaktini daha fazla almak istemem. çözerim hemen. githubda var mı link atabilrsen
                olur atayım')
            if (model.Username != null && model.Password != null) 
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("BlogList","Blog");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı");
                }
                    }
            else
            {
                ModelState.AddModelError("", "Lütfen alanları boş geçmeyiniz");
            }
            return View();
        }
    }
}
