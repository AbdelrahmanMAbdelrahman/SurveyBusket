

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SurveyBasket.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<DatabaseContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}
app.MapIdentityApi<ApplicationUser>();
app.UseHttpsRedirection();//security

app.UseAuthorization();
app.UseCors("myPolicy");
app.MapControllers();

app.Run();


