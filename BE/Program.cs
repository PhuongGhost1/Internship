using BE.Middlewares;
using BE.Models;
using BE.Repository;
using BE.Repository.Implementations;
using BE.Repository.Interface;
using BE.Services;
using BE.Services.Implementations;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<CourseOnlContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
);

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
    options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
        };
})
.AddGoogle(option => {
    option.ClientId = builder.Configuration["Google:ClientId"];
    option.ClientSecret = builder.Configuration["Google:ClientSecret"];
    option.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.CallbackPath = "/signin-google";

    option.Events = new OAuthEvents{
      OnRemoteFailure = context => {
        context.Response.WriteAsJsonAsync("Failed to login with google!!!");
        context.HandleResponse();
        return Task.CompletedTask;
      }  
    };
})
.AddFacebook(option => {
    option.AppId = builder.Configuration["Facebook:AppId"];
    option.AppSecret = builder.Configuration["Facebook:AppSecret"];
    option.CallbackPath = "/signin-facebook";

    option.Events = new OAuthEvents{
      OnRemoteFailure = context => {
        context.Response.WriteAsJsonAsync("Failed to login with facebook!!!");
        context.HandleResponse();
        return Task.CompletedTask;
      }  
    };
});;

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddOptions();
var emailSetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(emailSetting);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();builder.Services.AddScoped<ITokenRepository, TokenRepository>();builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();builder.Services.AddScoped<IImageRepository, ImageRepository>();builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();builder.Services.AddScoped<IChapterRepository, ChapterRepository>();builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Services
builder.Services.AddScoped<IUserService, UserService>();builder.Services.AddScoped<IEmailService, EmailService>();builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IChapterService, ChapterService>();builder.Services.AddScoped<ICategoryService, CategoryService>();builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<IQuizService, QuizService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRequestResponseLoggingMiddleware();
app.UseAuthenticationMiddleware();
app.UseExceptionHandleMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
