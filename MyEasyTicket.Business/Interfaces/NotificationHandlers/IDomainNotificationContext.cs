using FluentValidation.Results;
using MyEasyTicket.Business.DomainNotificationHandler;
using System.Collections.Generic;

namespace MyEasyTicket.Business.Interfaces.NotificationHandlers
{
    public interface IDomainNotificationContext
    {
        bool HasNotification();
        void AddNotification(DomainNotification notification);
        void AddNotification(string key, string value);
        void AddNotifications(IEnumerable<DomainNotification> notifications);
        void AddNotifications(ValidationResult validation);
    }
}
