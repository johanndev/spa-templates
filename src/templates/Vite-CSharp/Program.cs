var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

#if (RequiresHttps)
app.UseHttpsRedirection();
#endif

app.UseAuthorization();

app.MapControllers();

app.Run();
