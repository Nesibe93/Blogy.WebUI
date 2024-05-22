using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Dashboard/")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogyContext _context;
        public DashboardController(UserManager<AppUser> userManager, BlogyContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var viewModel = new DashboardViewModel
            {
                BlogCount = _context.Articles.Where(x => x.AppUserId == user.Id).Count(),
                InboxMessageCount = _context.Messages.Where(x => x.ReceiverMail == user.Email).Count(),
                CommentCount = _context.Messages.Where(x => x.SenderMail == user.Email).Count(),
                NotificationCount = _context.Notifications.Count(),
                LastBlog = _context.Articles.OrderByDescending(x => x.CreatedDate).FirstOrDefault()
            };

            return View(viewModel);
        }
    }
}
