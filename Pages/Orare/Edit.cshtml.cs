using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Orare;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly Gym_webContext _context;

    public EditModel(Gym_webContext context)
    {
        _context = context;
    }

    [BindProperty] public Orar Orar { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Orar == null) return NotFound();

        var orar = await _context.Orar.FirstOrDefaultAsync(m => m.ID == id);
        if (orar == null) return NotFound();
        Orar = orar;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Orar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrarExists(Orar.ID))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool OrarExists(int id)
    {
        return _context.Orar.Any(e => e.ID == id);
    }
}