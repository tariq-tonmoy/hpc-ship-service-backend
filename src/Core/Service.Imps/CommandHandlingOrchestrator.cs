using ShipService.Infrastructure.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using ShipService.Infrastructure.Core.UserContextProvider.Abstractions;
using Microsoft.Extensions.Logging;

namespace ShipService.Infrastructure.Core.Service.Imps
{
    public class CommandHandlingOrchestrator : MessageHandlingOrchestratorHelper, ICommandHandlingOrchestrator, IDisposable
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<CommandHandlingOrchestrator> logger;

        public event ICommandHandlingOrchestrator.CommandReceivedDelegate<Command> CommandReceivedEvent;

        public CommandHandlingOrchestrator(IServiceScopeFactory serviceScopeFactory, IContextAccessor contextAccessor, ILogger<CommandHandlingOrchestrator> logger)
            : base(contextAccessor)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
            this.CommandReceivedEvent += HandleCommandReceivedEventAsync;
        }

        protected async void HandleCommandReceivedEventAsync<TCommand>(TCommand command)
            where TCommand : Command
        {
            try
            {
                using (var scope = this.serviceScopeFactory.CreateScope())
                {
                    await base.HandleCommandReceivedEventAsync(command, scope);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
            }
        }

        public void InitiateCommandHandling<TCommand>(TCommand command)
            where TCommand : Command
        {
            this.CommandReceivedEvent?.Invoke(command);
        }

        public void Dispose()
        {
            this.CommandReceivedEvent -= HandleCommandReceivedEventAsync;
        }
    }
}
