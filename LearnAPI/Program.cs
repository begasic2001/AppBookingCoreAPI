using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.AttributeFilters;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using TourBooking.Helpers;
using TourBooking.Repositories;
using TourBooking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(autofacConfigure =>
{
    autofacConfigure
        .RegisterType<Repository<Country>>().As<IRepository<Country>>();

    autofacConfigure
        .RegisterType<UnitOfWork>().As<IUnitOfWork>();
    autofacConfigure
      .RegisterType<CountryService>().As<ICountryService>();

});
builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<TourDatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
