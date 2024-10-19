1. Add a nuGet Dependency
	Microsoft.AspNetCore.SignalR.Client
2. Add new class MessagingHub and implement SignalR Hub interface
	
3. Add Middleware configuration
	//Add SignalR
	builder.Services.AddSignalR();
	//Add Messaging Hub Endpoint mapping
	app.MapHub<MessagingHub>("message-hub");
4. References
	https://github.com/aspnet/SignalR-samples/blob/main/StockTickR/CsharpClient/Program.cs