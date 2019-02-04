using DNATrack.Common.Core;
using DNATrack.Common.Messaging;
using DNATrack.Persistence;
using DNATrack.Services.Analysis.Consumers;
using Microsoft.Extensions.DependencyInjection;

namespace DNATrack.Services.Analysis
{
    class Application : BaseServiceApplication<Program, AnalysisService>
    {
        protected override string Name => "Analysis Service";

        protected override void BootstrapServices(IServiceCollection services)
        {
            services
                .AddScoped<NewTraceConsumer>()
                .AddSingleton<AnalysisService>()
                .Configure<MongoDbConfiguration>(configuration.GetSection(Constants.ConfigSections.Mongo))
                .Configure<RabbitMQConfiguration>(configuration.GetSection(Constants.ConfigSections.Rabbit));
        }
    }
}
