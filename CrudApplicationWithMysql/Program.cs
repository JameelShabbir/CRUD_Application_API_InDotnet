using CrudApplicationWithMysql.RepositoryLayer;
using CrudApplicationWithMysql.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register service and repository layers
builder.Services.AddScoped<ICrudApplicationRL, CrudApplicationRL>();
builder.Services.AddScoped<ICrudApplicationSL, CrudApplicationSL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
