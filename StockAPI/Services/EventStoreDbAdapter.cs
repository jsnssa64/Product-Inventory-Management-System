using CQRSlite.Events;
using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockAPI.Services
{
    public class EventStoreDbAdapter : IEventStore
    {
        public readonly EventStoreClient _client;
        public EventStoreDbAdapter(EventStoreClient client)
        {
            _client = client;
        }
        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default)
        {
            //return Task.FromResult(_context.EventStorage.AsEnumerable().Where(x => x.StreamId == aggregateId && x.Version > fromVersion).Select(s => JsonSerializer.Deserialize<IEvent>(s.Payload)));
            //  TODO: Convert To Client
            //_client.
           throw new NotImplementedException();
        }

        public Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
