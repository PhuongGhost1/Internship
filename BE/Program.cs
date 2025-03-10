using BE.Middlewares;
using BE.Models;
using BE.Repository.Implementations;
using BE.Repository.Interface;
using BE.Services.Implementations;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http.Features;
using BE.Helpers;
using DotNetEnv;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Configure CORS
Env.Load();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
      builder =>
      {
          builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
      });
    options.AddDefaultPolicy(
      builder =>
      {
          builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
      });
});
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
/*FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("config/firebase.json")
});*/


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<CourseOnlContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))),
    ServiceLifetime.Transient
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
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
.AddGoogle(option =>
{
    option.ClientId = builder.Configuration["Google:ClientId"];
    option.ClientSecret = builder.Configuration["Google:ClientSecret"];
    option.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.CallbackPath = "/signin-google";

    option.Events = new OAuthEvents
    {
        OnRemoteFailure = context =>
        {
            context.Response.WriteAsJsonAsync("Failed to login with google!!!");
            context.HandleResponse();
            return Task.CompletedTask;
        }
    };
})
.AddFacebook(option =>
{
    option.AppId = builder.Configuration["Facebook:AppId"];
    option.AppSecret = builder.Configuration["Facebook:AppSecret"];
    option.CallbackPath = "/signin-facebook";

    option.Events = new OAuthEvents
    {
        OnRemoteFailure = context =>
        {
            context.Response.WriteAsJsonAsync("Failed to login with facebook!!!");
            context.HandleResponse();
            return Task.CompletedTask;
        }
    };
}); ;

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });

    // options.SwaggerDoc("Email", new OpenApiInfo { Title = "Email APIs", Version = "v1" });
    // options.SwaggerDoc("User", new OpenApiInfo { Title = "User APIs", Version = "v1" });
    // options.SwaggerDoc("Course", new OpenApiInfo { Title = "Course APIs", Version = "v1" });
    // options.SwaggerDoc("Chapter", new OpenApiInfo { Title = "Chapter APIs", Version = "v1" });
    // options.SwaggerDoc("Category", new OpenApiInfo { Title = "Category APIs", Version = "v1" });

    // options.DocInclusionPredicate((docName, apiDesc) =>
    // {
    //     if (apiDesc.TryGetMethodInfo(out var methodInfo))
    //     {
    //         var groupName = methodInfo.DeclaringType.GetCustomAttributes(true)
    //                            .OfType<ApiExplorerSettingsAttribute>()
    //                            .FirstOrDefault()?.GroupName;
    //         return groupName == docName;
    //     }
    //     return false;
    // });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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


builder.Services.AddOptions();
var emailSetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(emailSetting);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

//Paypal
builder.Services.AddSingleton<PaypalClient>(sp =>
    {
        var configuration = sp.GetRequiredService<IConfiguration>();
        var clientId = configuration["PayPalSettings:ClientId"];
        var clientSecret = configuration["PayPalSettings:ClientSecret"];
        var url = configuration["PayPalSettings:Url"];
        return new PaypalClient(clientId, clientSecret, url);
    });


builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 52428800;
});

builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = 50 * 1024 * 1024);

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>(); builder.Services.AddScoped<ITokenRepository, TokenRepository>(); builder.Services.AddScoped<IRoleUserRepository, RoleUserRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>(); builder.Services.AddScoped<IQuestionRepository, QuestionRepository>(); builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>(); builder.Services.AddScoped<IEmailRepository, EmailRepository>(); builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>(); builder.Services.AddScoped<IChapterRepository, ChapterRepository>(); builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>(); builder.Services.AddScoped<IPermissonRepository, PermissonRepository>(); builder.Services.AddScoped<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<IUserCertificationRepository, UserCertificationRepository>(); builder.Services.AddScoped<ISaveCourseRepository, SaveCourseRepository>();
builder.Services.AddScoped<ICategoryCourseRepository, CategoryCourseRepository>(); builder.Services.AddScoped<IEnrollCourseRepository, EnrollCourseRepository>();
builder.Services.AddScoped<IResourcesRepository, ResourceRepository>(); builder.Services.AddScoped<IPaymentRepository, PaymentRepository>(); builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();



//Services
builder.Services.AddScoped<IUserService, UserService>(); builder.Services.AddScoped<IRoleUserService, RoleUserService>(); builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<IQuizService, QuizService>(); builder.Services.AddScoped<IQuestionService, QuestionService>(); builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<IEmailService, EmailService>(); builder.Services.AddScoped<ICourseService, CourseService>(); builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IChapterService, ChapterService>(); builder.Services.AddScoped<ICertificationService, CertificationService>(); builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IRoleService, RoleService>(); builder.Services.AddScoped<IPermissonService, PermissonService>(); builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<IUserCertificationService, UserCertificationService>(); builder.Services.AddScoped<ISaveCourseService, SaveCourseService>();
builder.Services.AddScoped<ICategoryCourseService, CategoryCourseService>(); builder.Services.AddScoped<IEnrollCourseService, EnrollCourseService>();
builder.Services.AddScoped<IResourceService, ResourceService>(); builder.Services.AddScoped<IPaymentService, PaymentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseRequestResponseLoggingMiddleware();
app.UseExceptionHandleMiddleware();
//app.UseAuthenticationMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();