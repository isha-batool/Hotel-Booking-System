using Microsoft.AspNetCore.SignalR;

namespace Hotel_Booking_System_Hub
{
    public class logout : Hub
    {
        public async Task SendMessage(string m)
        {
            await Clients.All.SendAsync("ReceiveMessage", m);
            //await Clients.Caller.SendAsync("ReceiveMessage", m);
            //await Clients.Others.SendAsync("ReceiveMessage", m);
        }
    }
}
