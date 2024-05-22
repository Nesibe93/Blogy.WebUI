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
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly BlogyContext _context;

        public EFMessageDal(BlogyContext context)
        {
            _context = context;
        }

        public List<Message> GetMessageListByWriter(string p)
        {
            var values = _context.Messages.Where(x => x.ReceiverMail == p).OrderByDescending(z => z.Date).Take(3).ToList();
            return values;

        }
    }
}
