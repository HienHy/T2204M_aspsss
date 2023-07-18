using Microsoft.EntityFrameworkCore;
using System.Text;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);
//add cors

builder.Services.AddCors(
    opstions =>
    {
        opstions.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();

            });
    });



//Add connection database

var connectionString = builder.Configuration.GetConnectionString("T2204M_API");

builder.Services.AddDbContext<T2204M_API.Entities.T2204mApiContext>(
    options => options.UseSqlServer(connectionString)

    );

// Add services to the container.

builder.Services.AddControllers().
    AddNewtonsoftJson(jsonOptions => jsonOptions.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore
    
    );



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseCors();

app.Run();

