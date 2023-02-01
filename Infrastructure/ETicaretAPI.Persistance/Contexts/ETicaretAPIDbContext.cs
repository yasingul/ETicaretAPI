using ETicaretAPI.Domain.Entities;
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


    }
}
