using chatbotv1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? SQLConnectionString = null;
//string? SQLConnectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
string? redisConnectionString = null;
var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
if(SQLConnectionString == null || redisConnectionString == null) {
    SQLConnectionString = config["AZURE_SQL_CONNECTIONSTRING"];
    redisConnectionString = config["AZURE_REDIS_CONNECTIONSTRING"];
}

// Add services to the container.
builder.Services.AddDbContext<MyDBContext>(options => options.UseSqlServer(SQLConnectionString, config => config.EnableRetryOnFailure()));
/*builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnectionString;
    options.InstanceName = "SampleInstance";
});*/
builder.Services.AddHttpClient();
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
