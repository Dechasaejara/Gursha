using Gursha.Api.Common.Errors;
using Gursha.Application;
using Gursha.Application.Services.Authentication;
using Gursha.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    // 
    builder.Services.AddSingleton<ProblemDetailsFactory, GurshaProblemDetailsFactory>();


}
// 
var app = builder.Build();
{
    // 
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}




