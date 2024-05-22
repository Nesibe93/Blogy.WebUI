using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.ViewComponents
{
    public class _NotificationViewComponentPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly BlogyContext _context;

        public _NotificationViewComponentPartial(INotificationService notificationService,BlogyContext context)
        {
            _notificationService = notificationService;
            this._context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.n = _context.Notifications.Count();
            var values = _notificationService.TGetListNotification();
            return View(values);
        }
    }
}
