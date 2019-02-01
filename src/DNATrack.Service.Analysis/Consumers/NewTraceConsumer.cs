using DNATrack.Common.Messaging.Commands;
using DNATrack.Persistence.Entities;
using MassTransit;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DNATrack.Services.Analysis.Consumers
{
    class NewTraceConsumer : IConsumer<NewTrace>
    {
        public async Task Consume(ConsumeContext<NewTrace> context)
        {
            var msg = context.Message;
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();


            Console.WriteLine($"Consuming {msg.BatchId}:{msg.TraceNumber} trace");

            var data = new byte[0];
            using (var sha256Hash = SHA256.Create())
            {
                do
                {
                    var tData = Encoding.UTF8.GetBytes(DateTime.UtcNow.Ticks.ToString());

                    data = data.Concat(tData).ToArray();
                    data = sha256Hash.ComputeHash(data);

                } while (sw.ElapsedMilliseconds < 1000);
            }

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("dnaTrack");
            var collection = database.GetCollection<Trace>("traces");


            await collection.InsertOneAsync(new Trace { DNA = data, BatchId = msg.BatchId, TraceNumber = msg.TraceNumber});

            Console.WriteLine($"Consumed {msg.BatchId}:{msg.TraceNumber} trace");
        }
    }
}
