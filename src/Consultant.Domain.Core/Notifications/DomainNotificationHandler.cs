﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ConsultTeam.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        } 
    }
}