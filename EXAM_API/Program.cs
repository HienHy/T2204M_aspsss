using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


////Add Connection Database
var connectionString = builder.Configuration.GetConnectionString("EXAM_API");

EXAM_API.Models.ExamApiContext.ConnectionString = connectionString;
builder.Services.AddDbContext<EXAM_API.Models.ExamApiContext>(
        options => options.UseSqlServer(connectionString)
    );


builder.Services.AddControllers();
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

app.Run();

