
using ASP_MVC.Mappers;
using ASP_MVC.Models.Jeu;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class JeuController : Controller
    {
        private readonly IJeuRepository<Jeu> _jeuRepository;

        public JeuController(IJeuRepository<Jeu> jeuRepository)
        {
            _jeuRepository = jeuRepository ?? throw new ArgumentNullException(nameof(jeuRepository));
        }

        // GET: JeuController
        public ActionResult Index()
        {
            try
            {
                if (_jeuRepository == null)
                {
                    throw new InvalidOperationException("Le repository des jeux n'est pas initialisé.");
                }

                // Récupère la liste des jeux et les transforme en JeuListItem pour affichage dans la vue
                IEnumerable<JeuListItem> model = _jeuRepository.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception ex)
            {
                // Affiche l'exception ou redirige vers une page d'erreur avec un message spécifique

                return Content($"Erreur : {ex.Message}"); 
            }
        }
    }
}