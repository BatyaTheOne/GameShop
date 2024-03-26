using GameShop.Services;
using GameShop;
using Microsoft.EntityFrameworkCore;
using GameShop.Mappers;
using GameShop.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IBuyService, BuyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountReplenishmentService, AccountReplenishmentService>();

builder.Services.AddAutoMapper(typeof(AppMappersProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseCors("AllowAllOrigins");

app.UseStaticFiles();

app.MapControllers();

app.Run();