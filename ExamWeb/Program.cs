using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using ExamWeb.ValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddMvc();

        builder.Services.AddControllers()
                        .AddFluentValidation(options =>
                        {
                            // Validate child properties and root collection elements
                            options.ImplicitlyValidateChildProperties = true;
                            options.ImplicitlyValidateRootCollectionElements = true;

                            // Automatic registration of validators in assembly
                            options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                        });


        builder.Services.AddScoped<IStudentDal, StudentRepository>();
        builder.Services.AddScoped<IExamDal, ExamRepository>();
        builder.Services.AddScoped<ILessonDal, LessonRepository>();

        builder.Services.AddScoped<IStudentService, StudentManger>();
        builder.Services.AddScoped<IExamService, ExamManager>();
        builder.Services.AddScoped<ILessonService, LessonManager>();



        builder.Services.AddScoped<IValidator<Student>, StudentValidation>();
        builder.Services.AddScoped<IValidator<Lesson>, LessonValidation>();
        builder.Services.AddScoped<IValidator<Exam>, ExamValidation>();



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
    }
}