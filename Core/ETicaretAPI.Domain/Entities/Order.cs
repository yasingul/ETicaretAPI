using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; } //Product ve Order arasında ki n-n ilişkiyi tanımladık.
        public Customer Customer { get; set; }  //Customer ve Order arasında ki 1-n ilişkiyi tanımladık.
    }
}
