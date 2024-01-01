using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetStore.Authorization.Data.Context;
using PetStore.Authorization.Models;
using PetStore.Authorization.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Add connection string
builder.Services.AddDbContext<AuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration["SqlConnection:SqlConnectionString"]);
});
#endregion

#region Add Identity
builder.Services
    .AddIdentity<User, IdentityRole>() //IdentityRole vai gerenciar o papel do usuário no sistema pelo identity
    .AddEntityFrameworkStores<AuthContext>() //Indica qual a classe vai se comunicar com o DB p/ identity
    .AddDefaultTokenProviders();//Utilizado para autentificação
#endregion

#region Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<TokenServices>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
