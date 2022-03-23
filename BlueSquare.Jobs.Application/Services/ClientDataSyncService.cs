using System;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using BlueSquare.Jobs.Application.Commands;
using MediatR;

namespace BlueSquare.Jobs.Application.Services
{
    public class ClientDataSyncService : IHostedService
    {
        private readonly IMediator _mediator;

        public ClientDataSyncService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _mediator.Publish(new SyncClientDataCommand(), cancellationToken);
                await Task.Delay(TimeSpan.FromMinutes(15), cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
