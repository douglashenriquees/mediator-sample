using System.Reflection;
using MediatorSample.CrossCutting.IoC;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddMediatR(typeof(MediatorSample.Application.Queries.GetAllCustomersQuery).GetTypeInfo().Assembly);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });
app.UseAuthorization();
app.MapControllers();

app.Run();