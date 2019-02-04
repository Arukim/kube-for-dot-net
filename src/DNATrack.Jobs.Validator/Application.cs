using DNATrack.Common.Core;
using DNATrack.Persistence;
using DNATrack.Persistence.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DNATrack.Jobs.Validator
{
    class Application : AbstractApplication<Program>
    {
        protected override string Name => "Validator Job";

        protected override void BootstrapServices(IServiceCollection services) {
            services
                .Configure<MongoDbConfiguration>(configuration.GetSection(Constants.ConfigSections.Mongo));
        }

        protected override async Task DoWorkload()
        {
            using (_ = logger.BeginScope("updating lastValidation field"))
            {
                logger.LogInformation("Started");

                var mongoConfig = serviceProvider.GetService<IOptions<MongoDbConfiguration>>().Value;

                var client = new MongoClient(mongoConfig.Endpoint);
                var database = client.GetDatabase(mongoConfig.Database);
                var collection = database.GetCollection<Trace>("traces");

                var update = Builders<Trace>.Update.CurrentDate("lastValidation");
                await collection.UpdateManyAsync(new BsonDocument(), update);

                logger.LogInformation("Finished");
            }
        }
    }
}
