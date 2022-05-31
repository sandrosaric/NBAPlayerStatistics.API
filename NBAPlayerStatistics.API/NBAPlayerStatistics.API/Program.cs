using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NBAPlayerStatistics.API.DataModels;
using NBAPlayerStatistics.API.DataModels.Repositories;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IPlayerRepository,SqlPlayerRepository>();
builder.Services.AddScoped<IPositionRepository,SqlPositionRepository>();
builder.Services.AddScoped<IClubRepository,SqlClubRepository>();
builder.Services.AddScoped<IImageRepository,LocalStorageRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AngularUIApplication", opt =>
     {
         opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
     });
});
builder.Services.AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<Program>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Resources")),
    RequestPath = "/Resources"
});
app.UseCors("AngularUIApplication");
app.UseAuthorization();

app.MapControllers();

app.Run();
