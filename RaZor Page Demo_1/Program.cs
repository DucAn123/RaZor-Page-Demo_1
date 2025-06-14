using RazorPagesLabA1.Binding;
using RazorPagesLabA1.Validation;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add Razor Pages
builder.Services.AddRazorPages();

// 🔹 (Tuỳ chọn) Nếu có dịch vụ riêng thì đăng ký ở đây
// builder.Services.AddTransient<ICarService, CarService>();

// 🔹 Cho phép upload file và sử dụng model binding custom nếu có
builder.Services.AddSingleton<CheckNameBinding>();

var app = builder.Build();

// 🔹 Middleware cấu hình pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 🔹 Map Razor Pages
app.MapRazorPages();

app.Run();
