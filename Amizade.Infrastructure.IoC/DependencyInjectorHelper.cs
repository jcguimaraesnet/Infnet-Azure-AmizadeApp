using Amizade.Domain.Model.Interfaces.Infrastructure;
using Amizade.Domain.Model.Interfaces.Repositories;
using Amizade.Domain.Model.Interfaces.Services;
using Amizade.Domain.Services.Services;
using Amizade.Infrastructure.Data.Context;
using Amizade.Infrastructure.Data.Repositories;
using Amizade.Infrastructure.Services.Blob;
using Amizade.Infrastructure.Services.Functions;
using Amizade.Infrastructure.Services.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amizade.Infrastructure.IoC
{
    public class DependencyInjectorHelper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AmizadeContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("AmizadeContext")));

            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<IAmigoService, AmigoService>();

            var connStringStorageAccount = configuration.GetValue<string>("ConnectionStringStorageAccount");

            services.AddScoped<IBlobService, BlobService>(provider => 
                new BlobService(connStringStorageAccount));

            services.AddScoped<IQueueService, QueueService>(provider =>
                new QueueService(connStringStorageAccount));

            services.AddScoped<IFunctionService, FunctionService>(provider =>
                new FunctionService(configuration.GetValue<string>("FunctionBaseAddress")));

        }
    }
}
