
using System.Text;
using Comidas.Server;
using Comidas.Server.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
builder.Services.AddScoped<NotificacionesService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
                         ClockSkew = TimeSpan.Zero
                     });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{

//    endpoints.MapGet("/api/config/notificacionesllavepublica", async context =>
//    {
//        var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
//        var llavePublica = configuration.GetValue<string>("notificaciones:llave_publica");
//        await context.Response.WriteAsync(llavePublica);
//    });

//});

app.MapGet("/api/config/notificacionesllavepublica", async context =>
{
    var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
    var llavePublica = configuration.GetValue<string>("notificaciones:llave_publica");
    await context.Response.WriteAsync(llavePublica);
});
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
