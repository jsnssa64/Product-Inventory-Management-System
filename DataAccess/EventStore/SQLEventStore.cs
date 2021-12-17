using CQRSlite.Events;
using Data.EventStore.SQL;
using Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public interface IAppDbContext
    {
        ESList EventStorage { get; }
    }

    public class FakeSQlEventStore : IAppDbContext
    {
        public ESList EventStorage { get; set; }
    }

    public class ESList : IEnumerable<EventStorage>
    {
        public IEnumerator<EventStorage> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(EventStorage e, CancellationToken cs)
        {
            throw new NotImplementedException();
        }

    }

    public class EventStorage : EventData { }

    public class SQLEventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;
        private readonly IAppDbContext _context;


        public SQLEventStore(IAppDbContext context, IEventPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        public async Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default)
        {
            var dbevents = _context.EventStorage.Where(x => x.StreamId == events.First().Id).ToList();

            foreach (var @event in events)
            {
                EventStorage es = new ()
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
