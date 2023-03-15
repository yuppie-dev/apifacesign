using DinkToPdf;
using DinkToPdf.Contracts;
using Facesign.Services.Application.AppService;
using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces;
using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Domain.PDF;
using Facesign.Services.Domain.Security;
using Facesign.Services.Entities.Configuration;
using Facesign.Services.Infra.Data.Core;
using Facesign.Services.Infra.Data.Data;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Repository.Client;
using Facesign.Services.Infra.Data.Repository.Laudos;
using Facesign.Services.Infra.Data.Repository.Signature;
using Facesign.Services.Infra.Data.Repository.SingleSignOn;
using Facesign.Services.Infra.Data.Repository.User;
using Facesign.Services.Infra.ExternalServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Facesign.Services.Infra.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var context = new CustomAssemblyLoadContext();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DllsPdf\\libwkhtmltox.dll");
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "DllsPdf\\libwkhtmltox.dll"));

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddDbContextFactory<SqlServerContext>(options => options.
                           UseSqlServer(new Database().IniciaConexao()));            

            services.AddSingleton<ISignatureRepositoryApp, SignatureRespositoryApp>();
            services.AddSingleton<ISignatureRepository, SignatureRepository>();


            services.AddSingleton<IClientsRepository, ClientsRepository>();
            services.AddSingleton<IClientsRepository, ClientsRepository>();
            services.AddSingleton<IClientsFunctionalitiesRepository, ClientsFunctionalitiesRepository>();
            services.AddSingleton<IClientsLayoutsRepository, ClientsLayoutsRepository>();


            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ISingleSignOnRepository, SingleSignOnRepository>();

            services.AddSingleton<ITokenApp, TokenApp>();
            services.AddSingleton<IToken, Token>();

            services.AddSingleton<IPdfGeneratorApp, PdfGeneratorApp>();
            services.AddSingleton<IPdfGenerator, PDFGenerator>();

            #region MongoDB
            services.AddScoped(typeof(IDbContext), typeof(MongoDBContext));
            services.AddScoped<ILaudoRepositoryApp, LaudoRepositoryApp>();
            services.AddScoped<ILaudoRepository, LaudoRepository>();
            #endregion

            services.AddSingleton<IExternalService, FacetecExternalService>();
            services.AddSingleton<IExternalServiceApp, ExternalServiceApp>();


            return services;
        }
    }
}