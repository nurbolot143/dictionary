using System.Reflection;
using Autofac;
using Infrastructure.AspNetCore;
using Infrastructure.AspNetCore.Extensions;
using Infrastructure.AspNetCore.Nh;
using Infrastructure.Seedwork.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Site.API;

WebApplicationBoostrap.Create(args)
                      .ContainerBuilder((_, containerBuilder) => //
                      {
                          containerBuilder.RegisterAssemblyModules(Assembly.Load("Site.API"));

                          containerBuilder.RegisterInstance(NhSessionFactory.Instance);
                      })
                      .Build(builder =>
                      {
                          var services      = builder.Services;
                          var configuration = builder.Configuration;

                          services.AddHttpLogging(logging =>
                          {
                              logging.LoggingFields        = HttpLoggingFields.All;
                              logging.RequestBodyLogLimit  = 4096;
                              logging.ResponseBodyLogLimit = 4096;
                          });

                          services.AddMvcCore(options => //
                          {
                              options.Filters.Add<DbSessionAttributeActionFilter>();
                          });

                          services.AddControllers();
                          services.AddSwaggerGen();

                          services.AddHttpClient("Site.API");

                          builder.RegisterConfiguration<SystemEnvironmentConfiguration>("SystemEnvironment");
                      })
                      .Configure(app =>
                      {
                          app.UseHttpLogging();

                          app.UseForwardedHeaders();


                          app.MapControllers();
                      })
                      .Start("Site.API");