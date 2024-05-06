
using Microsoft.AspNetCore.SignalR;
using Microsoft.Owin.Security.Infrastructure;

namespace WebServerDataSync
{
    public class MessagesHub:Hub
    {
        public const string ReceiveMessage = "ReceiveMessage";
        public const string ReceiveDesktopMessage = "ReceiveDesktopMessage";
        public const string ReceiveWebMessage = "ReceiveWebMessage";
        public async Task Send( string message)
        {
            await Clients.Others.SendAsync(ReceiveMessage, message);
        }

        public async Task SendToWebClient(string message)
        {
            await Clients.Others.SendAsync(ReceiveDesktopMessage, message);
        }
        public async Task SendToDesktopClient(string message)
        {
            await Clients.Others.SendAsync(ReceiveWebMessage, message);
        }

        public override Task OnConnectedAsync()
        {
            var clients = Clients;
            var context = Context;

            return Task.CompletedTask;
        }
        //sendsServerWebClietns

        //SendDesktopClients
    }
}
