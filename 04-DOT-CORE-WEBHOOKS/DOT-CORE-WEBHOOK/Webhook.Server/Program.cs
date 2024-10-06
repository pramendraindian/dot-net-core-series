using Webhook.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WebhookService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapPost("/subscribe", (WebhookService ws, Subscription sub)
    => ws.Subscribe(sub));

app.MapPost("/publish", async (WebhookService ws, PublishRequest req)
    => await ws.PublishMessage(req.Topic, req.Message));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
