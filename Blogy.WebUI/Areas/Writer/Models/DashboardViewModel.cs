using Blogy.EntityLayer.Concrete;

namespace Blogy.WebUI.Areas.Writer.Models
{
    public class DashboardViewModel
    {
        public int BlogCount { get; set; }
        public int InboxMessageCount { get; set; }
        public int CommentCount { get; set; }
        public int NotificationCount { get; set; }
        public Article LastBlog { get; set; }
    }
}
