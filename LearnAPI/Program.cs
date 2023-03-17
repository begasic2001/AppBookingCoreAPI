using NLog;
using LoggerService;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.AttributeFilters;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using TourBooking.Helpers;
using TourBooking.Services;
using System.Text.Json.Serialization;
using TourBooking.Interfaces;
using TourBooking.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(autofacConfigure =>
{
    autofacConfigure.
        RegisterType<LoggerServiceManage>().As<ILoggerService>();
    autofacConfigure
        .RegisterType<Repository<Country>>().As<IRepository<Country>>();
    autofacConfigure
        .RegisterType<Repository<City>>().As<IRepository<City>>();
    autofacConfigure
       .RegisterType<Repository<Sight>>().As<IRepository<Sight>>();
    autofacConfigure
       .RegisterType<Repository<Transport>>().As<IRepository<Transport>>();
    autofacConfigure
       .RegisterType<Repository<Tour>>().As<IRepository<Tour>>();
    autofacConfigure
       .RegisterType<Repository<User>>().As<IRepository<User>>();
    autofacConfigure
       .RegisterType<Repository<Order>>().As<IRepository<Order>>();
    autofacConfigure
   .RegisterType<Repository<OrderDetail>>().As<IRepository<OrderDetail>>();
    autofacConfigure
        .RegisterType<UnitOfWork>().As<IUnitOfWork>();
    autofacConfigure
      .RegisterType<CountryService>().As<ICountryService>();
    autofacConfigure
      .RegisterType<CityService>().As<ICityService>();
    autofacConfigure
      .RegisterType<SightService>().As<ISightService>();
    autofacConfigure
      .RegisterType<TransportService>().As<ITransportService>();
    autofacConfigure
      .RegisterType<TourService>().As<ITourService>();
        autofacConfigure
      .RegisterType<UserService>().As<IUserService>();
    //  autofacConfigure
    //.RegisterType<OrderService>().As<IOrderService>();
    //  autofacConfigure
    //.RegisterType<OrderDetailService>().As<IOrderDetailService>();


});
builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMvc()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<TourDatabaseContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<TourDatabaseContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
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
