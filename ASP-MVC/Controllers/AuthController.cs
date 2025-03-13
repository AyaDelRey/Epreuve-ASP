using ASP_MVC.Handlers;
using ASP_MVC.Handlers.ActionFilters;
using ASP_MVC.Models.Auth;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class AuthController : Controller
    {
        private IUtilisateurRepository<BLL.Entities.Utilisateur> _userService;
        private SessionManager _sessionManager;

        public AuthController(
            IUtilisateurRepository<Utilisateur> userService,
            SessionManager sessionManager
            )
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [AnonymousNeeded]
        public IActionResult Login()
        {
            /* Méthode compliquée de vérifier si l'utilisateur à le droit ou non d'accéder à la page...
            if(_sessionManager.ConnectedUser is not null)
            {
                return RedirectToAction("Index", "Home");
            }*/
            return View();
        }

        [HttpPost]
        [AnonymousNeeded]
        public IActionResult Login(AuthLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _userService.CheckPassword(form.Email, form.Password);
                //C'est ici que nous définirons la variable de session
                Utilisateur user = _userService.Get(id);

                ConnectedUser sessionUser = new ConnectedUser()
                {
                    User_Id = user.Utilisateur_Id,
                    Email = user.Email,
                    ConnectedAt = DateTime.Now,
                    Pseudo = user.Pseudo.ToString()
                };
                _sessionManager.Login(sessionUser);
                return RedirectToAction("Details", "User", new { id = id });
            }
            catch (Exception)
            {
                return View();
            }
        }

        [ConnectionNeeded]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [ConnectionNeeded]
        public IActionResult Logout(IFormCollection form)
        {
            try
            {
                _sessionManager.Logout();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
