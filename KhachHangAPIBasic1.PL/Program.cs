using KhachHangAPIBasic1.BUS.Implement;
using KhachHangAPIBasic1.BUS.Interface;
using KhachHangAPIBasic1.DAL.Repositories.Implement;
using KhachHangAPIBasic1.DAL.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ??ng ký các d?ch v? c?a b?n
builder.Services.AddScoped<IKhachHangRepo, KhachHangRepo>();
builder.Services.AddScoped<IKhachHangService, KhachHangService>();

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
