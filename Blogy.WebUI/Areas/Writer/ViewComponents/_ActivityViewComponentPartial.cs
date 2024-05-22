using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents
{
    public class _ActivityViewComponentPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly BlogyContext _context;
        public _ActivityViewComponentPartial(INotificationService notificationService, BlogyContext context)
        {
            _notificationService = notificationService;
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.a = _context.Notifications.ToList();
            var values = _notificationService.TGetListNotification();
            return View(values);
        }

    }
}
