using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.Concrete;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.EntityFramework;
using Blogy.EntityLayer.Concrete;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogyContext>();

builder.Services.AddScoped<ICategoryDal,EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();// Registration

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal,EFArticleDal>();

builder.Services.AddScoped<ICommentService,CommentManager>();
builder.Services.AddScoped<ICommentDal, EFCommentDal>();

builder.Services.AddScoped<INotificationDal, EFNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

builder.Services.AddScoped<IMessageDal, EFMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IWriterDal, EFWriterDal>();
builder.Services.AddScoped<IWriterService, WriterManager>();

builder.Services.AddScoped<IAppRoleDal, EFAppRoleDal>();
builder.Services.AddScoped<IAppRoleService, AppRoleManager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogyContext>().AddErrorDescriber<CustomIdentityValidator>(); //AddErrorDescriber<CustomIdentityValidator>(): Bu ifade, özelleştirilmiş hata açıklamaları sağlamak için kullanılır. CustomIdentityValidator, uygulamanızda tanımlanmış ve Identity Framework tarafından kullanılacak bir hata açıklama sınıfını temsil eder. Bu sınıf, Identity Framework'ün varsayılan hata mesajlarını değiştirerek veya özelleştirerek kullanıcıların daha iyi anlamalarını sağlar.

builder.Services.AddControllersWithViews();


builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Index", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Mutlaka Authorization() metodunun üstünde olmalı. Sıralama önemli!

app.UseAuthorization();

var supportedCultures = new[] { "en", "de", "fr", "gr", "tr", "es" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
