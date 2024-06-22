using DOT_NET_CORE_RABBIT_MQ.Data;
using DOT_NET_CORE_RABBIT_MQ.Models;
using DOT_NET_CORE_RABBIT_MQ.Repositories;
using DOT_NET_CORE_RABBIT_MQ.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Configure MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
//Configure DBContext
builder.Services.AddScoped<EFDbContext>();
//Configure Product Dependency
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//Configure Rabbit MQ
builder.Services.AddScoped<IMessageProducer, MessageProducerService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
