using AutoMapper;
using Microsoft.EntityFrameworkCore;
using InTechAPI.Lib;
using InTechCommon.Helpers;
using InTechDA;
using InTechService;

var builder = WebApplication.CreateBuilder(args);

AppSettings.Initialize(builder.Configuration);

IMapper mapper = DTOModelMapping.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<InTechDBContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("InTechDBConnection")));


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
// Add services to the container.
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;       
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options => options.ReportApiVersions = true);


var app = builder.Build();

// Apply migrations automatically at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<InTechDBContext>();
    dbContext.Database.Migrate();  // This will apply any pending migrations automatically
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();
