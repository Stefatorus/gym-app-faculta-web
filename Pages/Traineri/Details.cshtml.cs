using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Traineri;

public class DetailsModel : PageModel
{
    private readonly Gym_webContext _context;

    public DetailsModel(Gym_webContext context)
    {
        _context = context;
    }

    public Trainer Trainer { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Trainer == null) return NotFound();

        var Trainer = await _context.Trainer.FirstOrDefaultAsync(m => m.ID == id);
        if (Trainer == null)
            return NotFound();
        else
            Trainer = Trainer;
        return Page();
    }
}