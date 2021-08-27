using ShipService.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.External.NotificationHost.Models
{
    public class NotificationClient : ViewModelBase
    {
        public NotificationClient(
            int version,
            Guid createdBy,
            Guid lastUpdatedBy,
            DateTime createdDate,
            DateTime lastUpdatedDate,
            bool isMarkedToDelete,
            Guid correlationId,
            string clientId)
        {
            this.Version = version;
            this.CreatedBy = createdBy;
            this.LastUpdatedBy = lastUpdatedBy;
            this.CreatedDate = createdDate;
            this.LastUpdatedDate = lastUpdatedDate;
            this.IsMarkedToDelete = isMarkedToDelete;
            this.CorrelationId = correlationId;
            this.ClientId = clientId;
        }


        public Guid CorrelationId { get; protected set; }

        public string ClientId { get; protected set; }

    }
}
