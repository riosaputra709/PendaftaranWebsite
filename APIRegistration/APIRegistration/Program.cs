using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Mengonfigurasi batasan ukuran file upload
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 5242880; // 5MB
});

// Menambahkan layanan CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()         // Mengizinkan permintaan dari domain mana pun
              .AllowAnyMethod()         // Mengizinkan metode HTTP apa pun (GET, POST, PUT, dll)
              .AllowAnyHeader();        // Mengizinkan header apa pun
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Menambahkan middleware CORS
app.UseCors("AllowAllOrigins");

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
