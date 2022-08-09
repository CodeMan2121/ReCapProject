using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{//IoC = Inversion Of Control yani injectionları kontrol ettiğimiz nokta.
    public static class ServiceTool
    {//Bu kodlar Autofac ve API'deki injectionları oluşturmamızı sağlıyor.
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
