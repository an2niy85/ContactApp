using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API списка контактов",
    });
});

//builder.Services.AddScoped<InMemoryStorage>();
builder.Services.AddControllers();
builder.Services.AddSingleton<IStorage, SqliteStorage>();

builder.Services.AddCors(
    opt => opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins(args[0]);
    })
);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();