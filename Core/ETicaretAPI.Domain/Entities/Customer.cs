using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        //1 kullanıcının birden fazla siparişi olabileceği için Order(n) ve Customer(1) arasında 1-n ilişki vardır.
        public ICollection<Order> Orders { get; set; }  //Order ve Customer arasında ki 1-n ilişkinin Customer ayağını tanımladık.
    }
}
