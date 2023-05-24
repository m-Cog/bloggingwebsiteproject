using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Data;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories;
using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Data;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Data;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("User")));
builder.Services.AddDbContext<BloggingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogPost")));
builder.Services.AddDbContext<CommentingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Comment")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();

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
