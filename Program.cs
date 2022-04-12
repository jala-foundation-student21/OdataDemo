using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(setup =>
        setup.AddRouteComponents(
                "odata",
                ODataExtension.GetEdmModel())
        .Filter()
        .Select()
        .Expand()
        .OrderBy()


    );

// In-Memory database
builder.Services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("DatabaseInMemory")); // new


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
