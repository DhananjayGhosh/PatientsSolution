using PatientAPI.App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServiceContainer(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Default Render port
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/", () => "Hello from .NET on Render!");

app.UseAuthorization();

app.MapControllers();

app.Run();
