using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using ResourceBookingSystemAPI.DBData;
using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories;
using ResourceBookingSystemAPI.Repositories.ResourceManagement;
using ResourceBookingSystemAPI.Repositories.BookingManagement; 

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



//interfaces dependency injection
builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IResourceRepository, ResourceRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
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
