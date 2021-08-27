using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Infrastructure.Utilities.Abstractions;
using System;
using System.Collections.Generic;

namespace ShipService.Infrastructure.Core
{
    public abstract class AggregateRoot : IEntityBase
    {
        private List<DomainEvent> domainEvents;

        protected void AddEvent(DomainEvent @event)
        {
            if (domainEvents == null)
            {
                domainEvents = new List<DomainEvent>();
            }

            domainEvents.Add(@event);
            this.Version++;
        }

        public Guid Id { get; protected set; }

        public int Version { get; private set; }

        public Guid CreatedBy { get; protected set; }

        public Guid LastUpdatedBy { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime LastUpdatedDate { get; protected set; }

        public bool IsMarkedToDelete { get; protected set; }

        public IReadOnlyCollection<DomainEvent> DomainEvents => domainEvents;

        protected void SetDefaultValues(UserContext userContext, IDateTimeProvider dateTimeProvider)
        {
            this.LastUpdatedBy = userContext.UserId;
            this.LastUpdatedDate = dateTimeProvider.GetUtcDateTime();
            if (this.CreatedBy == Guid.Empty)
            {
                this.CreatedBy = userContext.UserId;
                this.CreatedDate = dateTimeProvider.GetUtcDateTime();
                this.Version++;
            }
        }
    }
}
