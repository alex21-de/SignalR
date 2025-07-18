using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient;



internal class Program
{
    static HubConnection HubConnection;

    static async Task Main(string[] args)
    {
        HubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7188/notification").Build();

        HubConnection.On<string>("Send", message => Console.WriteLine($"Message from server: {message}"));

        await HubConnection.StartAsync();

        bool isExit = false;

        while (!isExit)
        {
            var message = Console.ReadLine();

            if (message != "isExit")
            {
                await HubConnection.SendAsync("SendMessage", message);
            }
            else
            {
                isExit = true;
            }
        }

        Console.ReadLine();
    }
}