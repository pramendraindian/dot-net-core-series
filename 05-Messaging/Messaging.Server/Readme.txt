Git Hub Repository - https://github.com/pramendraindian/dot-net-core-series/tree/main/05-Messaging
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
	https://www.programiz.com/csharp-programming/online-compiler/
	https://www.programiz.com/online-compiler/2iJOqoz9uPLpV
	Consume SSE inside Angular application
	https://dev.to/icolomina/subscribing-to-server-sent-events-with-angular-ee8
	Congigure middle ware
	app.MapGet()
	https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0

5. Important Tools
	Code Snippet - https://carbon.now.sh/
	Flow Chart Design - https://app.smartdraw.com/