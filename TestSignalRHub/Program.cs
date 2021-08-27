using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestSignalRHub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string dockerUrl = "http://127.0.0.40:8091/hubs";
                string devUrl = "http://localhost:8091/hubs";

                int input = 0;
                string url = string.Empty;
                while (input != 1 && input != 2)
                {
                    Console.WriteLine("Select your environment: \n1. Development\n2. Docker");
                    var consoleInput = Console.ReadLine();

                    try
                    {
                        input = Convert.ToInt32(consoleInput);
                    }
                    catch (Exception)
                    {
                    }
                }

                if (input == 1)
                {
                    url = devUrl;
                }
                else
                {
                    url = dockerUrl;
                }

                Console.WriteLine("Input correlationId:\n");


                var correlationId = Console.ReadLine();

                var connection = new HubConnectionBuilder()
                    .WithUrl(url)
                    .WithAutomaticReconnect()
                    .Build();

                await connection.StartAsync();

                await connection.InvokeAsync("Register", correlationId);


                connection.On<dynamic>("ReceiveEvent", resp =>
                {
                    Console.WriteLine(resp.ToString());
                    Console.WriteLine();
                });

            }
            catch (Exception ex)
            {


            }

            await Task.Delay(-1);
        }
    }
}
