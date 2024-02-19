using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Servicii;

public class IndexModel : PageModel
{
    private readonly Gym_webContext _context;

    public IndexModel(Gym_webContext context)
    {
        _context = context;
    }

    public IList<Serviciu> Serviciu { get; set; } = default!;
    public DateServiciu ServiciuD { get; set; }
    public int ServiciuID { get; set; }
    public int SpecialitateID { get; set; }
    public string SortareTitlu { get; set; }
    public string SortareTrainer { get; set; }
    public string SortarePret { get; set; }
    public string Filtru { get; set; }


    public async Task OnGetAsync(int? id, int? specialitateID, string sortOrder, string searchString)
    {
        ServiciuD = new DateServiciu();
        SortareTitlu = string.IsNullOrEmpty(sortOrder) ? "titlu_asc" : "";
        SortareTrainer = string.IsNullOrEmpty(sortOrder) ? "Trainer_asc" : "";
        SortarePret = string.IsNullOrEmpty(sortOrder) ? "pret_asc" : "";

        Filtru = searchString;

        ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Trainer)
            .Include(b => b.Orar)
            .Include(b => b.SpecialitatiServiciu)
            .ThenInclude(b => b.Specialitate)
            .AsNoTracking()
            .ToListAsync();

        if (!string.IsNullOrEmpty(searchString))
            ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Trainer.Prenume.Contains(searchString)
                                                               || s.Trainer.Nume.Contains(searchString) ||
                                                               s.Titlu.Contains(searchString));
        if (id != null)
        {
            ServiciuID = id.Value;
            var serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
            ServiciuD.Specialitati = serviciu.SpecialitatiServiciu.Select(s => s.Specialitate);
        }

        switch (sortOrder)
        {
            case "titlu_asc":
                ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s =>
                    s.Titlu);
                break;
            case "Trainer_asc":
                ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s =>
                    s.Trainer.FullName);
                break;
            case "pret_asc":
                ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s =>
                    s.Pret);
                break;
        }
    }
}