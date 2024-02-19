using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Specialitati;

public class DetailsModel : PageModel
{
    private readonly Gym_webContext _context;

    public DetailsModel(Gym_webContext context)
    {
        _context = context;
    }

    public Specialitate Specialitate { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Specialitate == null) return NotFound();

        var specialitate = await _context.Specialitate.FirstOrDefaultAsync(m => m.ID == id);
        if (specialitate == null)
            return NotFound();
        else
            Specialitate = specialitate;
        return Page();
    }
}