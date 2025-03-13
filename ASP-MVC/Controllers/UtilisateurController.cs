// Controllers/UtilisateurController.cs
using BLL.Services;
using ASP_MVC.Models.Utilisateur;
using Microsoft.AspNetCore.Mvc;
using ASP_MVC.Mappers;

namespace ASP_MVC.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly UtilisateurService _utilisateurService;

        public UtilisateurController(UtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        public IActionResult Index()
        {
            var utilisateurs = _utilisateurService.Get().Select(utilisateur => utilisateur.ToListItem()).ToList();
            return View(utilisateurs);
        }

        public IActionResult Details(Guid id)
        {
            var utilisateur = _utilisateurService.Get(id).ToListItem();
            return View(utilisateur);
        }
    }
}
