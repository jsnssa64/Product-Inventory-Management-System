using CQRSlite.Events;
using Data.EventStore.SQL;
using Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class SQLEventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;
        private readonly AppDbContext _context;


        public SQLEventStore(AppDbContext context, IEventPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            var dbevents = _context.EventStorage.Where(x => x.StreamId == events.First().Id).ToList();

            foreach (var @event in events)
            {
                EventStorage es = new EventStorage()
                {
                    @Type = @event.GetType().FullName,
                    StreamId = @event.Id,
                    //  Where controlled???
                    Version = @event.Version,
                    Created = DateTime.Now,
                    Payload = JsonSerializer.Serialize(@event)
                };
                await _context.EventStorage.AddAsync(es, cancellationToken);
                await _publisher.Publish(@event, cancellationToken);
            }
        }

        //  Rehydrate Event Store
        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default)
        {
            //.AsAsyncEnumerable().WithCancellation(cancellationToken).ConfigureAwait(false);
            return Task.FromResult(_context.EventStorage.AsEnumerable().Where(x => x.StreamId == aggregateId && x.Version > fromVersion).Select(s => JsonSerializer.Deserialize<IEvent>(s.Payload)));
        }
    }
}
