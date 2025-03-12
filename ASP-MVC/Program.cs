using Common.Repositories;

namespace ASP_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Ajout des services pour la gestion des jeux
            builder.Services.AddScoped<IJeuRepository<BLL.Entities.Jeu>, BLL.Services.JeuService>();
            builder.Services.AddScoped<IJeuRepository<DAL.Entities.Jeu>, DAL.Services.JeuService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // Affiche la page d'erreur détaillée en mode développement
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
