var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//  var host = new WebHostBuilder()
//             // .UseKestrel()
//             // .UseContentRoot(Directory.GetCurrentDirectory())
//             // .UseIISIntegration()
//             .UseStartup<Startup>()
//             .UseUrls("http://*:80")
//             .Build();

//         host.Run();


app.Run();
