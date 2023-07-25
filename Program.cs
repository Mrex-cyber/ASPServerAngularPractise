using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(e => e.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

List<Driver> drivers = new List<Driver>()
{
    new Driver(1, "Tom", 25),
    new Driver(2, "Bob", 39),
    new Driver(3, "Nick", 41),
    new Driver(4, "Dan", 19),
    new Driver(5, "Kim", 32),
};

app.MapGet("/api/drivers", () => {
    return drivers;
});
app.Run();


class Driver
{
    public Driver(int id, string name, int age) 
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}