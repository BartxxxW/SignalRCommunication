
using Microsoft.AspNetCore.SignalR;
using Microsoft.Owin.Security.Infrastructure;

namespace WebServerDataSync
{
    public class MessagesHub:Hub
    {
        public const string ReceiveDesktopMessage = "ReceiveDesktopMessage";
        public const string ReceiveWebMessage = "ReceiveWebMessage";

        public async Task SendToWebClient(string message)
        {
            await Clients.Others.SendAsync(ReceiveDesktopMessage, message);
        }
        public async Task SendToDesktopClient(string message)
        {
            await Clients.Others.SendAsync(ReceiveWebMessage, message);
        }

    }
}
