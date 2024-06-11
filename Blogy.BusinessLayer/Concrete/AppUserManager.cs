using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;

		public AppUserManager(IAppUserDal appUserDal)
		{
			_appUserDal = appUserDal;
		}

		public void TDelete(int id)
		{
			throw new NotImplementedException();
		}

		public AppUser TGetAppUserDetail(int id)
		{
			return _appUserDal.GetAppUserDetail(id);
		}

		public AppUser TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public void TInsert(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(AppUser entity)
		{
			throw new NotImplementedException();
		}
	}
}
