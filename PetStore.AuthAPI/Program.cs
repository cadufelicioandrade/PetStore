using Microsoft.EntityFrameworkCore;
using PetStore.AuthAPI.Data.DbContext;
using PetStore.AuthAPI.Services;

var builder = WebApplication.CreateBuilder(args);


#region ConnectionString
builder.Services.AddControllers();
string connectionString = builder.Configuration["SqlConnetion:SqlConnectionString"];

builder.Services.AddDbContext<AuthContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
#endregion 

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<CreateService, CreateService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<TokenService, TokenService>();

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
