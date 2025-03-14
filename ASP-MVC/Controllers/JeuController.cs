using ASP_MVC.Mappers;
using ASP_MVC.Models.Jeu;
using ASP_MVC.Models.Jeux;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ASP_MVC.Controllers
{
    public class JeuController : Controller
    {
        private readonly IJeuRepository<Jeu> _jeuRepository;
        private readonly ILogger<JeuController> _logger;

        public JeuController(IJeuRepository<Jeu> jeuRepository, ILogger<JeuController> logger)
        {
            _jeuRepository = jeuRepository ?? throw new ArgumentNullException(nameof(jeuRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                _logger.LogError($"Erreur dans la méthode Index : {ex.Message}");
                return Content($"Erreur : {ex.Message}");
            }
        }

        // GET: Jeu/Detail/{id}
        public IActionResult Detail(Guid id)
        {
            try
            {
                var jeu = _jeuRepository.Get(id);
                if (jeu == null)
                {
                    _logger.LogWarning($"Le jeu avec l'ID {id} n'a pas été trouvé.");
                    return NotFound();
                }

                return View(jeu.ToListItem());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur lors de l'accès aux détails du jeu : {ex.Message}");
                return Content($"Erreur : {ex.Message}");
            }
        }

        // GET: Jeu/Create
        public IActionResult Create()
        {
            return View(new JeuCreateForm());
        }
        // Le jeu ne peux pas être créer car il faut d'abord être connecter pour faire le lien avec l'utilisateur je n'ai pas eu le temps de mettre en place l'authentification 
        // POST: JeuController/Create
        [HttpPost]
        public ActionResult Create(JeuCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Le formulaire de création du jeu est invalide.");
                    return View(form); // Retourne à la vue de création avec une erreur
                }

                // Log les valeurs reçues
                Console.WriteLine("Nom: " + form.Nom);
                Console.WriteLine("Description: " + form.Description);
                Console.WriteLine("MinAge: " + form.MinAge);
                // Convertir le formulaire en entité BLL
                Jeu jeuBLL = form.ToBLL();

                // Insérer le jeu dans la base de données et obtenir l'ID
                Guid id = _jeuRepository.Insert(jeuBLL);

                // Vérification si l'insertion a bien fonctionné
                if (id == Guid.Empty)
                {
                    _logger.LogError("L'insertion du jeu a échoué. L'ID retourné est invalide.");
                    ModelState.AddModelError("", "L'insertion a échoué.");
                    return View(form); // Retourner à la vue avec une erreur
                }

                _logger.LogInformation($"Jeu créé avec succès avec l'ID : {id}");
                return RedirectToAction(nameof(Detail), new { id }); // Rediriger vers la page de détail
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur lors de la création du jeu : {ex.Message}");
                ModelState.AddModelError("", $"Erreur : {ex.Message}");
                return View(form); // Retourner à la vue avec un message d'erreur
            }
        }
    }
}
