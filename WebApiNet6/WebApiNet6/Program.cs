using WebApiNet6;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AppDbContexts>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DifaultConnection")));

builder.Services.AddDependencyInjection(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
