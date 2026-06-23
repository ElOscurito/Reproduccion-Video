using Application.Campania.Queries;
using Domain;
using Infrastructure.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICampaniaGetAll, CampaniaGetAll>();
builder.Services.AddScoped<ICampaniaRepository, CampaniaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/campanias", async (ICampaniaGetAll campaniaGetAll) =>
{
    var campanias = await campaniaGetAll.ExecuteAsync();
    return Results.Ok(campanias);
})
.WithName("GetAllCampanias");


app.UseHttpsRedirection();

app.Run();


