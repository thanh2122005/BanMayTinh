using BLL;
using DAL.Helper;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IDanhMucRepository, DanhMucRepository>();
builder.Services.AddTransient<IDanhMucBusiness, DanhMucBusiness>();

builder.Services.AddTransient<IDonHangRepository, DonHangRepository>();
builder.Services.AddTransient<IDonHangBusiness, DonHangBusiness>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
