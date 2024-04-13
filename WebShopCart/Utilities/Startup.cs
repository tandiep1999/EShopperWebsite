using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebShopCart.Data;
using WebShopCart.Services;

public class Startup
{

    public void ConfigureServices(WebApplicationBuilder builder)
    {

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
            throw new InvalidOperationException("Default Connection not found");


        var serverVersion = ServerVersion.AutoDetect(connectionString);

        builder.Services.AddDbContext<AppDBContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
              /*  .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()*/
        );  
    }

    public void Initialize(WebApplicationBuilder builder)
    {
		builder.Services.AddScoped<UserService>();
	}
}