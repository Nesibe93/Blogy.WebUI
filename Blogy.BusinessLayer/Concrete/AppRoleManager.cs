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
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public AppRole TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppRole> TGetListAll()
        {
            return _appRoleDal.GetListAll();
        }

        public void TInsert(AppRole entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
