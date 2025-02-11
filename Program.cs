using FluentMappingApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

var connectionString = builder.Configuration.GetConnectionString("Banco");
builder.Services.AddDbContext<ContextApp>(op => op.UseSqlServer(connectionString));
var app = builder.Build();
app.MapControllers();

app.Run();
