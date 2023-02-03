using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/* Okuma işlemlerinin yapıldığı yerdir. Db'den bir sorgu sonucunda veri elde edeceğimiz işlemlere Read işlemleri deriz.
 * Select işlemleri burada yer alır.*/

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();         //Hangi türdeyse o türde ki tüm verileri getirir.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);       //Şarta uygun olan birden fazla veri elde edilir.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);      //Şarta uygun ilk veriyi getirir. Asenkron çalışırlar bunu isimlendirme de belirtiriz.
        Task<T> GetByIdAsync(string id);                           //Id'si verilen veriyi getirir. Asenkron çalışırlar bunu isimlendirme de belirtiriz.
    }
}
