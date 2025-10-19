using ProjetFinal_6223399.Models;

namespace ProjetFinal_6223399.ViewModels
{
	public class UnGroupeEtSesPersonnagesViewModel
	{
		public Groupe Groupe { get; set; } = null!;

		public List<Personnage> Personnages { get; set; } = new List<Personnage>();
	}
}
