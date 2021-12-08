using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MassTransitMessagingTestService.Workers
{
    public class MessageProducer : BackgroundService
    {
        readonly IBus _bus;

        public MessageProducer(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new Message { Text = $"The time is {DateTimeOffset.Now}" });
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
