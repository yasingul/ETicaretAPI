using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }        //Guid = Unique identify'dır
        public DateTime CreatedDay { get; set; }
        public DateTime UpdatedDate { get; set;}

    }
}
