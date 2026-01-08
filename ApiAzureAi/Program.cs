using ApiAzureAi.Model;
using ApiAzureAi.Model.AppSettings;
using ApiAzureAi.Service.Implementations;
using ApiAzureAi.Service.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJs", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.PropertyNameCaseInsensitive = true;
});

builder.Services.Configure<Endpoints>(
    builder.Configuration.GetSection("Endpoints")
    );

builder.Services.Configure<Azure>(
    builder.Configuration.GetSection("Azure"));

builder.Services.AddScoped<ISearchService, SearchService>();

builder.Services.AddHttpClient<IRestService, RestService>((sp, client) =>
{
    var endpoints = sp
            .GetRequiredService<IOptions<Endpoints>>()
            .Value;
    string url = endpoints.Urls.FirstOrDefault(url => url.Name == EndpointsApi.NameGetData)?
              .Domain ?? throw new Exception("Error getting Endpoint service");

    client.BaseAddress = new Uri(url);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowNextJs");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
