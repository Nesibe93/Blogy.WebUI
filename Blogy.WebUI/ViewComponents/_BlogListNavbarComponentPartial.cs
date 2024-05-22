using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents
{
	public class _BlogListNavbarComponentPartial : ViewComponent
	{
		private readonly IArticleService _articleService;

		public _BlogListNavbarComponentPartial(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
