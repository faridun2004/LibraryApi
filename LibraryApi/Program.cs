using FluentValidation;
using LibraryApi.Data;
using LibraryApi.UseCases.Books.Commands.CreateBook;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(builder.Configuration)
           .CreateLogger();
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>(con => con
                .UseNpgsql(builder.Configuration["ConnectionString"]));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly
                            (typeof(Program).Assembly));
builder.Services.AddScoped<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
try
{
    Log.Information("Starting Web Host!");
    var app = builder.Build();
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<LibraryDbContext>();
        if (context != null)
        {
            context.Database.Migrate();
        }
        else
        {
            throw new InvalidOperationException("WalletDbContext could not be resolved from the service provider.");
        }
    }
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run(); 
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
    
