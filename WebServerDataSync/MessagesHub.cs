
using Microsoft.AspNetCore.SignalR;
using Microsoft.Owin.Security.Infrastructure;

namespace WebServerDataSync
{
    public class MessagesHub:Hub
    {
        public const string ReceiveMessage = "ReceiveMessage";
        public async Task Send( string message)
        {


            await Clients.Others.SendAsync(ReceiveMessage, message);
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
