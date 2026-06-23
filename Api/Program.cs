using Application.Campania.Queries;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<ICampaniaGetAll, CampaniaGetAll>();
builder.Services.AddScoped<ICampaniaGetById, CampaniaGetById>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    await dbContext.Database.EnsureDeletedAsync();
    await dbContext.Database.EnsureCreatedAsync();
    if (!dbContext.Campanias.Any())
    {
        dbContext.Campanias.AddRange(
            new Domain.Campania { Nombre = "Campaña 1" },
            new Domain.Campania { Nombre = "Campaña 2" },
            new Domain.Campania { Nombre = "Campaña 3" }
        );
        await dbContext.SaveChangesAsync();
    }
}

app.MapGet(
    "/campanias/{id}",
    async (int id, ICampaniaGetById campaniaGetById) =>
    {
        var campania = await campaniaGetById.ExecuteAsync(id);
        if (campania == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(campania);
    }
);

app.MapGet(
        "/campanias",
        async (ICampaniaGetAll campaniaGetAll) =>
        {
            var campanias = await campaniaGetAll.ExecuteAsync();
            return Results.Ok(campanias);
        }
    )
    .WithName("GetAllCampanias");

app.UseHttpsRedirection();

app.Run();
