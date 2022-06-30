using Microsoft.OpenApi.Models;
using WebApplication2.Abstraction;
using WebApplication2.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>  
{  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.FileUpload.Api", Version = "v1" });  
    c.OperationFilter<SwaggerFileOperationFilter>();  
});
builder.Services.AddTransient<IStudentHelper, StudentHelper1>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();