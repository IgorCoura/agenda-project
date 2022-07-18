using Agenda.MVC.Notifications;

namespace Agenda.MVC.Interfaces
{
    public interface INotificator
    {
        void Handle(Notification notification);
        void Handle(IEnumerable<Notification> notification);

        List<Notification> GetNotifications();

        bool HasNotifications();
    }
}
