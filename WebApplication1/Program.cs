using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1.Application.Services;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Infrastructure.Data;
using WebApplication1.Infrastructure.Repositories;
using Mapster;
using MapsterMapper;
using WebApplication1.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(MappingConfig).Assembly);
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IManutencaoRepository, ManutencaoRepository>();

builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<ManutencaoService>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebApplication1 API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Item}/{action=Index}/{id?}"
);

app.Run();