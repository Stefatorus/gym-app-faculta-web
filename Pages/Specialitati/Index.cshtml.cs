using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Specialitati;

public class IndexModel : PageModel
{
    private readonly Gym_webContext _context;

    public IndexModel(Gym_webContext context)
    {
        _context = context;
    }

    public IList<Specialitate> Specialitate { get; set; } = default!;
    public SpecialitateIndexData SpecialitateData { get; set; }
    public int SpecialitateID { get; set; }
    public int ServiciuID { get; set; }

    public async Task OnGetAsync(int? id, int? serviciuID)
    {
        SpecialitateData = new SpecialitateIndexData();
        SpecialitateData.Specialitati = await _context.Specialitate
            .Include(i => i.SpecialitatiServiciu)
            .ThenInclude(i => i.Serviciu)
            .ThenInclude(i => i.Trainer)
            .OrderBy(i => i.NumeSpecialitate)
            .ToListAsync();
        if (id != null)
        {
            SpecialitateID = id.Value;
            var specialitate = SpecialitateData.Specialitati
                .Where(i => i.ID == id.Value).Single();
            SpecialitateData.SpecialitatiServiciu = specialitate.SpecialitatiServiciu;
        }
    }
}