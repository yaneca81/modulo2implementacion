using caso_de_estudio_1_backend.Data;
using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Helpers;
using caso_de_estudio_1_backend.Models;
using caso_de_estudio_1_backend.Repository;
using caso_de_estudio_1_backend.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//conext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//reponsitory
builder.Services.AddScoped<ICommonRepository<Associate>, AssociateRepository>();
builder.Services.AddScoped<ICommonRepository<CurriculumVitae>, CurriculumVitaeRepository>();
builder.Services.AddScoped<ICommonRepository<Payment>, PaymentRepository>();

//service
builder.Services.AddKeyedScoped<ICommonService<AssociateDto, AssociateCreateDto, AssociateUpdateDto>, AssociateService>("AssociateService");
builder.Services.AddKeyedScoped<ICommonService<CurriculumVitaeDto, CurriculumVitaeCreateDto, CurriculumVitaeUpdateDto>, CurriculumVitaeService>("CurriculumVitaeService");
builder.Services.AddKeyedScoped<ICommonService<PaymentDto, PaymentCreateDto, PaymentUpdateDto>, PaymentService>("PaymentService");

//Files
builder.Services.AddTransient<LocalFileStorage>();
builder.Services.AddHttpContextAccessor();


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

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
