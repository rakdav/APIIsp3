using APIIsp3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.
    GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ModelDB>(opt =>
        opt.UseSqlServer(connection)); 
builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
