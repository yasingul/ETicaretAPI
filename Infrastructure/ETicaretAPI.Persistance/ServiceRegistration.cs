using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Persistence
{
    //Static olmasının sebebi içerisinde extention fonksiyon tanımlıyor olmamızdır.
    public static class ServiceRegistration 
    {
        //bu fonksiyon PersistenceServices dediğimiz yapıları IoC konteynıra ekleyecek.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
