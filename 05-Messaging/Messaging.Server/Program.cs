using Messaging.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<StockService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", p => p
        .WithOrigins("http://localhost:4200", "other domains")
        .AllowAnyHeader()
        .AllowAnyMethod());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Configure SignalR Client
builder.Services.AddSignalR();
//Add Hosted Service - to enable active listener
builder.Services.AddHostedService<MessageInterceptor>();

var app = builder.Build();
app.UseCors("AllowAnyOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
//Configure Mesaging hub middleware
app.MapHub<MessagingHub>("message-hub");
//Help Url - https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0
app.MapGet("/stock-updates/{userId}", async (string userId, CancellationToken ct, StockService stockService, HttpContext ctx) =>
{
    //Add new response header, which browser can understand
    ctx.Response.Headers.Add("Content-Type", "text/event-stream");

    while (!ct.IsCancellationRequested)
    {
        var stock = await stockService.WaitForNewStock();
        
        //await ctx.Response.WriteAsync($"data:");
        await System.Text.Json.JsonSerializer.SerializeAsync(ctx.Response.Body,new Stock("Microsoft",stock.Price,userId));
       
        await ctx.Response.WriteAsync($"\n\n");
        await ctx.Response.Body.FlushAsync();
        stockService.Reset();
    }
});

app.Run();
