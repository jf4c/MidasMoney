using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using MidasMoney.Api.Infra;
using MidasMoney.Core.Models;

var builder = WebApplication.CreateSlimBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<AddDbContext>(x => { x.UseSqlServer(cnnStr); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddScoped<Handler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.MapPost("/v1/categories", (Request request, Handler hendler) => hendler.Handle(request)).Produces<Response>();

app.Run();

//request
public record Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

// response
public record Response
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}

//handler

public class Handler(AddDbContext context)
{
    public Response Handle(Request request)
    {
        var category = new Category()
        {
            Title = request.Title,
            Description = request.Description
        };
        context.Categories.Add(category);
        context.SaveChanges();

        return new Response
        {
            Id = category.Id,
            Title = category.Title
        };
    }
}