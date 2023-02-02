using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Kendi içerisinde temel, base tasarımlar burada olacak.
* Birden fazla veritabanına erişimimizi sağlayan tasarımları buraya ekleyeceğiz.
* IReadRepository ve IWriteRepository'i IRepository'den türeteceğimiz için her iki interface'inde kullanacağı ortak yapıları buraya yazmamız gerekecek.
* Bu yüzden Generic kullanmamız gerekecektir. "T". Buna GenericRepository denir.
* DbSet'in Generic ifadesi sadece 'Class' olan bir türdür.
*/

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : class  //Generic'in alanını sadece 'class' olarak kısalttık.
    {
        DbSet<T> Table { get; }
    }
}
