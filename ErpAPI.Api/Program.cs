using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ErpAPI.Api.Middleware;
using ErpAPI.Busines.Abstract;
using ErpAPI.Busines.Concrete;
using ErpAPI.DAL.Abstract.DataManegment;
using ErpAPI.DAL.Concrete.EntityFramework.Context;
using ErpAPI.DAL.Concrete.EntityFramework.DataManegment;
using ErpAPI.Helper.Globals;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ErpContext>();
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IPositionService, PositionManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ISaleService, SaleManagar>();
builder.Services.AddScoped<IAuthorityService, AuthorityManager>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection("JWTExceptURLList"));


var app = builder.Build();


app.UseGlobalExceptionMiddleware();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApiAuthorizationMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
