using bloggingwebsiteproject.BloggingMicroservice.BusinessLayer.Services;
using bloggingwebsiteproject.BloggingMicroservice.DataAccessLayer.Repositories;
using bloggingwebsiteproject.BloggingMicroservice.Services;
using bloggingwebsiteproject.CommentingMicroservice.BusinessLayer.Services;
using bloggingwebsiteproject.CommentingMicroservice.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserAuthMicroservice.BusinessLayer.Services;
using bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Data;
using bloggingwebsiteproject.UserAuthMicroservice.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Data;
using bloggingwebsiteproject.UserManagement.DataAccessLayer.Repositories;
using bloggingwebsiteproject.UserManagementMicroservice.Business_Layer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlUsers")));
builder.Services.AddDbContext<UserAuthDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserAuth")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogginWebsite", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT <strong>Authorization</strong> header using the Bearer scheme. <br/> 
                      Enter your token in the text input below.
<br/>Example: <i>'12345abcdef'</i>",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{
new OpenApiSecurityScheme
{
Reference = new OpenApiReference
{
Type = ReferenceType.SecurityScheme,
Id = "Bearer"
}
},
Array.Empty<string>()
        }
    });
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options =>

{

    options.TokenValidationParameters = new TokenValidationParameters

    {

        ValidateIssuer = false,

        ValidateAudience = false,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };

});




builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IAuthUserRepository, AuthUserRepository>();
builder.Services.AddScoped<IAuthUserService, AuthUserService>();




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
