using ShipService.Infrastructure.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using Microsoft.Extensions.Logging;

namespace ShipService.Infrastructure.Core.Service.Imps
{
    public class EventHandlingOrchestrator : MessageHandlingOrchestratorHelper, IEventHandlingOrchestrator, IDisposable
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<EventHandlingOrchestrator> logger;

        public event IEventHandlingOrchestrator.EventReceivedDelegate<DomainEvent> DomainEventReceivedEvent;

        public EventHandlingOrchestrator(IServiceScopeFactory serviceScopeFactory, IContextAccessor contextAccessor, ILogger<EventHandlingOrchestrator> logger)
            : base(contextAccessor)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
            this.DomainEventReceivedEvent += HandleCommandReceivedEventAsync;
        }

        private async void HandleCommandReceivedEventAsync<TEvent>(TEvent @event)
            where TEvent : DomainEvent
        {
            try
            {
                using (var scope = this.serviceScopeFactory.CreateScope())
                {
                    await base.HandleCommandReceivedEventAsync(@event, scope);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
            }
        }

        public void Dispose()
        {
            this.DomainEventReceivedEvent -= HandleCommandReceivedEventAsync;
        }

        public void InitiateEventHandling<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            this.DomainEventReceivedEvent?.Invoke(@event);
        }
    }
}
