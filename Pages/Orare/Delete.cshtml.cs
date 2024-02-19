using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Orare;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly Gym_webContext _context;

    public DeleteModel(Gym_webContext context)
    {
        _context = context;
    }

    [BindProperty] public Orar Orar { get; set; }

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Orar == null) return NotFound();
        var orar = await _context.Orar.FindAsync(id);

        if (orar != null)
        {
            Orar = orar;
            _context.Orar.Remove(Orar);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}