using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        //bu constructor'ı IoC konteynırda dolduracağımız için bestpractice açısında oluşturuyoruz.
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        { }

        //Entity'lerimize ait veritabanımızda tabloların oluşmasını bu kod blokları sayesinde yapabiliyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entitiyler üzerinden yapılan değişikliklerin ya da yeni eklenen verilerin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch       //Discard (_) ile burada bir atama işlemi yapılmasını istemediğimizi belirttik.
                {
                    EntityState.Added => data.Entity.CreatedDay = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                };

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
