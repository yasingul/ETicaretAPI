using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    //Static olmasnını sebebi içerisinde extention fonksiyon tanımlıyor olmamızdır.
    public static class ServiceRegistration 
    {
        //bu fonksiyon PersistenceServices dediğimiz yapıları IoC konteynıra ekleyecek.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
