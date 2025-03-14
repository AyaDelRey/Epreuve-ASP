using BLL.Services;
using ASP_MVC.Models.Utilisateur;
using Microsoft.AspNetCore.Mvc;
using ASP_MVC.Mappers;
using Common.Repositories;
using ASP_MVC.Handlers.ActionFilters;
using BLL.Entities;
using System;
using System.Linq;

namespace ASP_MVC.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly IUtilisateurRepository<BLL.Entities.Utilisateur> _utilisateurRepository;

        // Injection de la dépendance pour l'interface IUtilisateurRepository
        public UtilisateurController(IUtilisateurRepository<BLL.Entities.Utilisateur> utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        // Action pour afficher tous les utilisateurs
        public IActionResult Index()
        {
            var utilisateurs = _utilisateurRepository.Get()
                .Select(utilisateur => utilisateur.ToListItem())  // Mapping à une vue simplifiée
                .ToList();

            return View(utilisateurs);
        }

        // Action pour afficher les détails d'un utilisateur
        public IActionResult Details(Guid id)
        {
            var utilisateur = _utilisateurRepository.Get(id).ToListItem();
            return View(utilisateur);
        }

        // GET: UserController/Create
        [AnonymousNeeded]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousNeeded]
        public ActionResult Create(UtilisateurCreateForm form)
        {
            if (!ModelState.IsValid)
            {
                // Si le modèle n'est pas valide, nous renvoyons simplement la vue avec les erreurs
                return View(form);
            }

            try
            {
                // Vérification des conditions d'acceptation des CGU
                if (!form.Consent)
                {
                    ModelState.AddModelError(nameof(form.Consent), "Vous devez lire et accepter les conditions générales d'utilisation.");
                    return View(form);
                }

                // Conversion du modèle et insertion de l'utilisateur
                Guid id = _utilisateurRepository.Insert(form.ToBLL());

                // Redirection vers la vue des détails de l'utilisateur
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch (Exception ex)
            {
                // Ajout d'un message d'erreur générique à ModelState
                ModelState.AddModelError(string.Empty, "Une erreur est survenue lors de la création de l'utilisateur. Veuillez réessayer.");

                // Affichage du message d'exception dans les logs pour débogage (si en mode développement)
                
                
                    ModelState.AddModelError(string.Empty, $"Erreur détaillée : {ex.Message}");
                

                return View(form);
            }
        }
    }
}
