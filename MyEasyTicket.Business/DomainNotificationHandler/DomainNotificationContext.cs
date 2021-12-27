using FluentValidation.Results;
using MyEasyTicket.Business.Interfaces.NotificationHandlers;
using System.Collections.Generic;
using System.Linq;

namespace MyEasyTicket.Business.DomainNotificationHandler
{
    public class DomainNotificationContext : IDomainNotificationContext
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationContext()
        {
            this._notifications = new List<DomainNotification>();
        }

        public void AddNotification(DomainNotification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotification(string key, string value)
        {
            this._notifications.Add(new DomainNotification(key, value));
        }

        public void AddNotifications(IEnumerable<DomainNotification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validation)
        {
            foreach (var erro in validation.Errors)
            {
                this._notifications.Add(new DomainNotification(erro.ErrorCode, erro.ErrorMessage));
            }
        }

        public bool HasNotification()
        {
            return this._notifications.Any();
        }
    }
}
