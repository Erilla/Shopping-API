using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Business;
using ShoppingAPI.EntityFramework;
using ShoppingAPI.ExceptionFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessServices();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ObjectNotFoundExceptionFilter>();
    options.Filters.Add<ArgumentExceptionFilter>();
});

// Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ShoppingMappingProfile());
    mc.AddProfile(new ShoppingApiMappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ShoppingDbContext>();
    db.Database.Migrate();
}

app.Run();
