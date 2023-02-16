
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRKlient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5221/hubs/chat")
                .Build();

            await connection.StartAsync();

            Console.WriteLine("Podaj nazwe: ");
            string CUsername = Console.ReadLine();
            Console.WriteLine("Rozmawiaj: ");


            connection.On<string, string>("ShowMessage", async (username, message) =>
            {
                Console.WriteLine($"{username}: {message}");
            });
            while (true)
            {
                string CMessage = Console.ReadLine();
                await connection.SendAsync("SendMessage", CUsername, CMessage);
            }
        }
    }
}