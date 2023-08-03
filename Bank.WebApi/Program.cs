using Bank.Application;
using Bank.Application.Common.Mappings;
using Bank.Application.Interfaces;
using Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(conf =>
{
    conf.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
    conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", policy => 
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.AllowAnyOrigin();
}));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using (var scoped = app.Services.CreateScope()) 
{
    IServiceProvider serviceProvider = scoped.ServiceProvider;
    try 
    {
        ApplicationDbContext dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initialize(dbContext);
    }
    catch (Exception ex) 
    {
    
    }

}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
