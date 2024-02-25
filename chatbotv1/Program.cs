using chatbotv1.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
string SQLConnectionString = config["AZURE_SQL_CONNECTIONSTRING"];
string redisConnectionString = config["AZURE_REDIS_CONNECTIONSTRING"];

builder.Services.AddDbContext<MyDBContext>(options => options.UseSqlServer(SQLConnectionString));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnectionString;
    options.InstanceName = "SampleInstance";
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
