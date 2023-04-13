using Radzen;
public static class ext
{
    public static void ShowNotification(this NotificationService notify, string mensaje, string title, NotificationSeverity severity = NotificationSeverity.Success)
    {
        var message = new NotificationMessage
        {
            Severity = severity,
            Summary = title,
            Detail = mensaje
        };
        notify.Notify(message);
    }
}