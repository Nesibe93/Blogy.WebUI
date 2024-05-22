using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
private readonly IMessageService _messageService;
        private readonly BlogyContext _blogyContext;
        public MessageController(UserManager<AppUser> userManager,IMessageService messageService,BlogyContext blogyContext)
        {
            _userManager = userManager;
            _messageService = messageService;
            _blogyContext = blogyContext;
        }

        public async Task<IActionResult> MessageList(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user == null)
			{
				return NotFound("Kullanıcı bulunamadı.");
			}
            p = user.Email;
            var messageList = _messageService.TGetMessageListByWriter(p);
            return View(messageList);
        }
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("MessageList");

        }
    }
}
