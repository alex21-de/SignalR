using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(string message)
        {
            return Clients.Others.SendAsync("Send", message);
        }
    }
}
