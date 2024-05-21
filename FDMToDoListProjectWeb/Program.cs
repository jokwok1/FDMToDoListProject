
using FDMToDoListProject.DataAccess.Data;
using FDMToDoListProject.DataAccess.Repository.IRepository;
using FDMToDoListProject.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("ToDoListTracker"); // mention the db name using in memoery
});

//Add repo for dependency injection
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	context.Database.EnsureCreated(); // Ensure the database is created
	context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // allow static files to be accessible

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // ? means id can be defined or null

app.Run();
