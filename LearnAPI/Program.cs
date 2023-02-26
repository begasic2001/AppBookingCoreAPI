using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.AttributeFilters;
using LearnAPI.Interface;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using TourBooking.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(autofacConfigure =>
{
    autofacConfigure
        .RegisterType<UserRepository>().As<IUserRepository>()
        .WithMetadata("UserRepository", "UserRepository")
        .InstancePerLifetimeScope();
    //autofacConfigure
    //    .RegisterType<User2Repository>().As<UserRepository>()
    //    .WithMetadata("ServiceName2", "UserRepository2")
    //    .InstancePerLifetimeScope();
   
    autofacConfigure.RegisterType<User2Repository>().WithAttributeFiltering();

});
builder.Services.AddControllers();  
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);
builder.Services.AddDbContext<TourDatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
