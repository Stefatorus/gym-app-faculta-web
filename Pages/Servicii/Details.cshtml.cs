using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Servicii;

public class DetailsModel : PageModel
{
    private readonly Gym_webContext _context;

    public DetailsModel(Gym_webContext context)
    {
        _context = context;
    }

    public Serviciu Serviciu { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Serviciu == null) return NotFound();

        var serviciu = await _context.Serviciu.Include(b => b.Trainer).FirstOrDefaultAsync(m => m.ID == id);
        if (serviciu == null)
            return NotFound();
        else
            Serviciu = serviciu;
        return Page();
    }
}