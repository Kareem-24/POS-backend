using Core.Repository;
using Infrastructure.Repository;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);




builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
  builder.WithOrigins("http://localhost:4200")
  .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

var applicationAssembly = Assembly.Load("Application"); 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

builder.Services.AddAutoMapper(typeof(Application.MaperProfiles.AutoMapper).Assembly);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use PascalCase (default behavior)
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthinticationManager, AuthiticationManager>();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
