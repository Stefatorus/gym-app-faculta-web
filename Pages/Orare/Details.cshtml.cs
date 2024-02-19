using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Orare;

public class DetailsModel : PageModel
{
    private readonly Gym_webContext _context;

    public DetailsModel(Gym_webContext context)
    {
        _context = context;
    }

    public Orar Orar { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Orar == null) return NotFound();

        var orar = await _context.Orar.FirstOrDefaultAsync(m => m.ID == id);
        if (orar == null)
            return NotFound();
        else
            Orar = orar;
        return Page();
    }
}