using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Services.ImplementServcies;
using Services.InterfaceServcies;
using Services.InterfaceServices;
using Services.ImplementServices;
using Services.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var key = Encoding.UTF8.GetBytes("billxhdsbfjhsavdfhjbvasfdgdhddgfddgndxgxgn");

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
        "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
        "Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\n" +
        "Example: \"Bearer 12345abdcef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,
        },
        new List<string>()
        }
    });
});

//start JWT
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
//end JWT
builder.Services.AddAuthorization();

builder.Services.AddScoped<IAccountServices, AccountServices>();

builder.Services.AddScoped<IStoreServices, StoreServices>();

builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddScoped<IProductTypeServices, ProductTypeServices>();

builder.Services.AddScoped<IShiftServices, ShiftServices>();

builder.Services.AddScoped<IShiftTypeServices, ShiftTypeServices>();

builder.Services.AddScoped<IRewardCardServices, RewardCardServices>();

builder.Services.AddScoped<IAttendanceCardServices, AttendanceCardServices>();

builder.Services.AddScoped<IUnitServices, UnitServices>();

builder.Services.AddScoped<IPriceSizeServices, PriceSizeServices>();

builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();

builder.Services.AddScoped<IOrderServices, OrderServices>();

builder.Services.AddScoped<IOrderDetailServices, OrderDetailServices>();

builder.Services.AddScoped<IFileService, FileService>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder =>
        {
            builder
            //.WithOrigins(GetDomain())
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();





// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthentication();//xác thực
app.UseAuthorization();//phân quyền

//cau hinh custom exception
app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");
app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.MapControllers();

app.Run();
