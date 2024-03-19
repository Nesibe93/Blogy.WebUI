using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concreate
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } // Altında yeşil çizgi çıkınca Null olamaz demek
        public List<Article> Articles { get; set; }

    }
}
