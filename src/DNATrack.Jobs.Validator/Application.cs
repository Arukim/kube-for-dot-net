using DNATrack.Common.Core;
using DNATrack.Persistence.Entities;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DNATrack.Jobs.Validator
{
    class Application : AbstractApplication<Program>
    {
        protected override string Name => "Validator Job";

        protected override void BootstrapServices(IServiceCollection services) { }

        protected override async Task DoWorkload()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("dnaTrack");
            var collection = database.GetCollection<Trace>("traces");

            var update = Builders<Trace>.Update.CurrentDate("lastValidation");
            await collection.UpdateManyAsync(new BsonDocument(), update);
        }
    }
}
