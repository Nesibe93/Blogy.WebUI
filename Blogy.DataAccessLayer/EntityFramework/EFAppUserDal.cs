using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
	public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
	{
		public EFAppUserDal(BlogyContext context): base(context)
		{
		}

		public AppUser GetAppUserDetail(int id)
		{
			var context = new BlogyContext();
			var value = context.Articles.Where(x => x.ArticleId == id).Select(y => y.AppUser).FirstOrDefault();
			return value;
		}
	}
}
