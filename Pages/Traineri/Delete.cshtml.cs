using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Traineri;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly Gym_webContext _context;

    public DeleteModel(Gym_webContext context)
    {
        _context = context;
    }

    [BindProperty] public Trainer Trainer { get; set; }

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Trainer == null) return NotFound();
        var Trainer = await _context.Trainer.FindAsync(id);

        if (Trainer != null)
        {
            Trainer = Trainer;
            _context.Trainer.Remove(Trainer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}