using Microsoft.EntityFrameworkCore;
using PsiraWebApi.Interfaces;
using Microsoft.Extensions.Configuration;
using AutoMapper;
//using PsiraWebApi.Repository;
using PsiraWebApi.Repositories.UserManagement;
using PsiraWebApi.Repositories.PostManagement;
using PsiraWebApi.Repositories.LookupManagement;
using ResourceBookingSystemAPI.DBData;
using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories;
using ResourceBookingSystemAPI.Repositories.ResourceManagement; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//mapper configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfiles());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Injecting DbContext before app build
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingDB"))
);


//services.AddDbContext<ISAPSFirearmsDBContext, AssetsDBContext>(options =>
//                          options.UseSqlServer(Configuration.GetConnectionString("SAPSFirearmsDBDev"), o => o.MigrationsAssembly("Assets.SmartZar.Persistance")));
//services.Configure<ApiIntegrationCircleModel>(Configuration.GetSection("IntegrationCircleAPI"));

//interfaces dependency injection
builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IResourceRepository, ResourceRepository>();
//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IPostRepository, PostRepository>();
//builder.Services.AddTransient<ILookupRepository, LookupRepository>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


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
