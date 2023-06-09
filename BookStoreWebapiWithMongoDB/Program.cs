using BookStoreWebapiWithMongoDB.Data.Model;
using BookStoreWebapiWithMongoDB.Data.Service;
using BookStoreWebapiWithMongoDB.Data.ServiceInterfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookstore api", Version = "v1" });
});

builder.Services.Configure<BookStoreDatabaseSettings>(builder.Configuration.GetSection("MongoDbConnectionStrings"));
builder.Services.AddTransient<IBookService, BooksService>();

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
