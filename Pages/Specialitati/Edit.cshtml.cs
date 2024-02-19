using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Specialitati;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly Gym_webContext _context;

    public EditModel(Gym_webContext context)
    {
        _context = context;
    }

    [BindProperty] public Specialitate Specialitate { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Specialitate == null) return NotFound();

        var specialitate = await _context.Specialitate.FirstOrDefaultAsync(m => m.ID == id);
        if (specialitate == null) return NotFound();
        Specialitate = specialitate;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Specialitate).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SpecialitateExists(Specialitate.ID))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool SpecialitateExists(int id)
    {
        return _context.Specialitate.Any(e => e.ID == id);
    }
}