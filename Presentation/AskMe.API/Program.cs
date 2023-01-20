using AskMe.Domain.Application.Options;
using AskMe.Domain.Application.Profiles;
using AskMe.Domain.Application.Registrations;
using AskMe.Infrastructure.Identity.Registrations;
using AskMe.Persistence.Context;
using AskMe.Persistence.Registrations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureIdentity();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<AppDbContext>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
var settings = new JwtSettings();
builder.Configuration.GetSection("Jwt").Bind(settings);

// Add customized Authentication to the services container.
builder.Services.AddCustomizedAuthentication(settings);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
