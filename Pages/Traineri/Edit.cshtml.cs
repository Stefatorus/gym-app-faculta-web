using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Traineri;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly Gym_webContext _context;

    public EditModel(Gym_webContext context)
    {
        _context = context;
    }

    [BindProperty] public Trainer Trainer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Trainer == null) return NotFound();

        var Trainer = await _context.Trainer.FirstOrDefaultAsync(m => m.ID == id);
        if (Trainer == null) return NotFound();
        Trainer = Trainer;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Trainer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainerExists(Trainer.ID))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool TrainerExists(int id)
    {
        return _context.Trainer.Any(e => e.ID == id);
    }
}