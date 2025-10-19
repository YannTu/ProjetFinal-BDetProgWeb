using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_6223399.Data;
using ProjetFinal_6223399.Models;
using ProjetFinal_6223399.ViewModels;
using System.Security.Claims;
using System.Security.Principal;

namespace ProjetFinal_6223399.Controllers
{
    public class SerieTVController : Controller
    {
        readonly ProjetFinal6223399Context _context;

        public SerieTVController(ProjetFinal6223399Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["utilisateur"] = "Visiteur";
            IIdentity? identite = HttpContext.User.Identity;
            if (identite != null && identite.IsAuthenticated)
            {
                string pseudo = HttpContext.User.FindFirstValue(ClaimTypes.Name);
                Utilisateur? utilisateur = _context.Utilisateurs.FirstOrDefault(u => u.Pseudo == pseudo);
				if (utilisateur != null)
				{
					ViewData["utilisateur"] = utilisateur.Pseudo;
				}
            }
			return View();
        }

        public async Task<IActionResult> DetailsGroupe()
        {
            return View(await _context.VwDetailsGroupes.ToListAsync());
        }

        [Authorize]
        public IActionResult SaisieDonnees()
		{
            ViewBag.Groupes = _context.Groupes.Select(g => g.Nom).ToList();
            return View();
		}

		[Authorize]
		public async Task<IActionResult> UnGroupeEtSesPersonnages(string groupeRecherche, string statut)
        {
			if (!GroupeExists(groupeRecherche))
			{
				ViewData["groupeNonTrouve"] = "Ce groupe n'existe pas.";
				return RedirectToAction("Index");
			}
			Groupe? groupe = await _context.Groupes.Where(x => x.Nom.ToUpper() == groupeRecherche.ToUpper()).FirstOrDefaultAsync();
			if (groupe == null)
			{
				ViewData["groupeNonTrouve"] = "Ce groupe n'existe pas.";
				return RedirectToAction("Index");
			}
			if (statut != "Vivant" && statut != "Mort" && statut != "Inconnu")
			{
				ViewData["statutIncorrect"] = "Ce statut est incorrect.";
				return RedirectToAction("Index");
			}

			List<Personnage> personnages = await _context.Personnages
			.FromSqlRaw("EXECUTE [Personnages].[usp_quantitePersonnagesGroupe] @GroupeID = {0}, @Statut = {1}", groupe.GroupeId, statut)
			.ToListAsync();

			ViewData["statut"] = statut;

			return View(new UnGroupeEtSesPersonnagesViewModel()
			{
				Groupe = groupe,
				Personnages = personnages
			});
		}

		public async Task<IActionResult> PersonnagesAvecImages()
		{
			List<Personnage> personnages = await _context.Personnages.Where(p => p.Image != null).ToListAsync();
			List<string> images = await _context.Personnages.Where(p => p.Image != null).Select(p => $"data:image/png;base64, {Convert.ToBase64String(p.Image)}").ToListAsync();

			return View(new PersonnagesAvecImages()
			{
				Personnages = personnages,
				Images = images
			});
		}

		private bool GroupeExists(string nomGroupe)
		{
			return _context.Groupes.Any(e => e.Nom.ToUpper() == nomGroupe.ToUpper());
		}
	}
}
