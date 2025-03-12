using Common.Repositories;

namespace ASP_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ajouter les services à l'application
            builder.Services.AddControllersWithViews();

            // Ajouter l'accès au HttpContext pour gérer les sessions
            builder.Services.AddHttpContextAccessor();

            // Ajouter les services BLL et DAL pour Jeu et Utilisateur
            builder.Services.AddScoped<IJeuRepository<BLL.Entities.Jeu>, BLL.Services.JeuService>();
            builder.Services.AddScoped<IJeuRepository<DAL.Entities.Jeu>, DAL.Services.JeuService>();

            builder.Services.AddScoped<IUtilisateurRepository<BLL.Entities.Utilisateur>, BLL.Services.UtilisateurService>();
            builder.Services.AddScoped<IUtilisateurRepository<DAL.Entities.Utilisateur>, DAL.Services.UtilisateurService>();

            // Ajouter l'enregistrement de IJeuxUtilisateurRepository et son implémentation
            builder.Services.AddScoped<IJeuxUtilisateurRepository<BLL.Entities.JeuxUtilisateur>, BLL.Services.JeuxUtilisateurService>();
            builder.Services.AddScoped<IJeuxUtilisateurRepository<DAL.Entities.Jeux_Utilisateur>, DAL.Services.JeuxUtilisateurService>();


            var app = builder.Build();

            // Configurer le pipeline de l'application
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
}
