


using Advert.Domain.Interfaces;

namespace Advert.View
{
    public static class IocConfiguration
    {
        public static void RegisterAllDependencies(IServiceCollection services, IConfiguration config)
        {

            services.Scan(scan =>
            {
                scan.FromApplicationDependencies(a => a.GetName().Name.StartsWith("Advert"))
                .AddClasses(classes => classes.AssignableTo<ITansientDependency>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IScopedDependency>())
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonDependency>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime();

            });

        }

    }


}
