var builder = WebApplication.CreateBuilder(args);

// Add services to the container. configurations
//configure http client
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.services.AddHttpClient();
builder.services.AddHttpClient<ICouponService,CouponService>();
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];

//wehave registered serivces
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IBaseService, BaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
