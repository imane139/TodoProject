
using WebApplication5.Filters;
using WebApplication5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISessionManagerService, SessionManagerService>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ThemeFilter>();
builder.Services.AddScoped<LogFilter>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<ThemeFilter>();
    options.Filters.AddService<LogFilter>();
});


//configure service dedie pour injection ede dependance

var app = builder.Build();


// ajouter les midellware configure 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}");

app.Run();
