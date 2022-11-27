using Microsoft.EntityFrameworkCore;
using Repository_Layer;
using Services_Layer;
using VL_DataAccess;
using VL_DataManager.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VLContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddSingleton<IUserService, UserService>();
//builder.Services.AddTransient<IAuthorService, AuthorService>();
//builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookReviewService, BookReviewService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


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
