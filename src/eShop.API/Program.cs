using eShop.API;
using eShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration, builder.Environment);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "eShop API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "eShop API v1");
        options.RoutePrefix = "swagger"; // localhost/swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.UseMiddlewares();

app.Run();
