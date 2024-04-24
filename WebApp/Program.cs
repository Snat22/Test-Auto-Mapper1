using AutoMapper;
using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Services.CourseServices;
using Infrastructure.Services.GroupServices;
using Infrastructure.Services.MentorServices;
using Infrastructure.Services.StudentServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options=>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IMentorService,MentorService>();
builder.Services.AddScoped<IGroupService,GroupService>();
builder.Services.AddScoped<ICourseService,CourseService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
