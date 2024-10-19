using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var connection = new HubConnectionBuilder().WithUrl("https://localhost:7247/message-hub", options => {
    options.Transports = HttpTransportType.WebSockets;
}).WithAutomaticReconnect().Build();
await connection.StartAsync();
string newMessage1;
connection.On<object>("onClientConnect", (message) => {
    Console.WriteLine(message); //write in the debug console
    //var newMessage = JsonConvert.DeserializeObject<dynamic>(message.ToString());
    //newMessage1 = $"{newMessage.chainTip}";
});

connection.On<object>("onClientDisconnection", (message) => {
    Console.WriteLine(message); //write in the debug console
});

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (sender, a) =>
{
    a.Cancel = true;
    cts.Cancel();
};

connection.Closed += e =>
{
    Console.WriteLine("Connection closed with error: {0}", e);

    cts.Cancel();
    return Task.CompletedTask;
};


Console.ReadLine();
