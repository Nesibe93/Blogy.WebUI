using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly IAppRoleService _roleService;
        private readonly AppRoleManager _roleManager;

        public AdminRoleController(AppRoleManager roleManager, IAppRoleService roleService)
        {
            _roleManager = roleManager;
            _roleService = roleService;
        }

        public IActionResult RoleList()
        {
            var values = _roleService.TGetListAll();
            return View(values);
        }
    }
}
