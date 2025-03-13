using ASP_MVC.Handlers;
using BLL.Entities;
using BLL.Services;
using Common.Repositories;
using DAL.Entities;
using DAL.Services;

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

            // Ajout d'implémentation des services nécessaires à l'utilisation de session :
            // AddDistributedMemoryCache : Pour le développment et debbugage
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(
                    options => {
                                options.Cookie.Name = "CookieWad24";
                                options.Cookie.HttpOnly = true;
                                options.Cookie.IsEssential = true;
                                options.IdleTimeout = TimeSpan.FromMinutes(10);
                                });
            builder.Services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
                                 });


            // Ajout du service de sessionManager
            builder.Services.AddScoped<SessionManager>();

            // Ajouter les services pour Jeu (BLL et DAL)
            builder.Services.AddScoped<IJeuRepository<BLL.Entities.Jeu>, BLL.Services.JeuService>();
            builder.Services.AddScoped<IJeuRepository<DAL.Entities.Jeu>, DAL.Services.JeuService>();  // Service DAL pour Jeu

            // Ajouter les services pour Utilisateur (BLL et DAL)
            builder.Services.AddScoped<IUtilisateurRepository<BLL.Entities.Utilisateur>, BLL.Services.UtilisateurService>();
            builder.Services.AddScoped<IUtilisateurRepository<DAL.Entities.Utilisateur>, DAL.Services.UtilisateurService>();  // Service DAL pour Utilisateur

            // Ajouter les services pour JeuxUtilisateur (BLL et DAL)
            builder.Services.AddScoped<IJeuxUtilisateurRepository<BLL.Entities.JeuxUtilisateur>, BLL.Services.JeuxUtilisateurService>();
            builder.Services.AddScoped<IJeuxUtilisateurRepository<DAL.Entities.Jeux_Utilisateur>, DAL.Services.JeuxUtilisateurService>();  
            // Service DAL pour JeuxUtilisateur
            builder.Services.AddScoped<ITagRepository<BLL.Entities.Tag>, BLL.Services.TagService>();
            builder.Services.AddScoped<ITagRepository<DAL.Entities.Tag>, DAL.Services.TagService>(); 
            // Service DAL pour Tag


            var app = builder.Build();

            // Configurer le pipeline de l'application
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseCookiePolicy();
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
