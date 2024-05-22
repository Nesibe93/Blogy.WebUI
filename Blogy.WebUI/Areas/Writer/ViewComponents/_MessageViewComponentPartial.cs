using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Blogy.WebUI.Areas.Writer.ViewComponents
{
    public class _MessageViewComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly BlogyContext _context;
        public _MessageViewComponentPartial(UserManager<AppUser> userManager, IMessageService messageService, BlogyContext context)
        {
            _userManager = userManager;
            _messageService = messageService;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string p)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                p = user.Email;
                var messagelist = _messageService.TGetMessageListByWriter(p);
                ViewBag.m = _messageService.TGetMessageListByWriter(p).Count();
                return View(messagelist);
            }

            else
            {

            }
            return View();
            
        }
    }
}