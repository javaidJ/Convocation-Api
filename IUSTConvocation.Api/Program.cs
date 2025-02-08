using IUSTConvocation.Api;
using IUSTConvocation.Application;
using IUSTConvocation.Infrastructure;
using IUSTConvocation.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);


builder.Services.AddApplicationServices(builder.Environment.WebRootPath)
        .AddInfrastructureServices(builder.Configuration)
        .AddPersistenceServices(builder.Configuration);



var app = builder.Build();
app.UseCors(option =>
{
    option.SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
