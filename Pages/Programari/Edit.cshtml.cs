using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Programari;

public class EditModel : PageModel
{
    private readonly Gym_webContext _context;

    public EditModel(Gym_webContext context)
    {
        _context = context;
    }

    [BindProperty] public Programare Programare { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Programare == null) return NotFound();

        var programare = await _context.Programare.FirstOrDefaultAsync(m => m.ID == id);
        if (programare == null) return NotFound();
        Programare = programare;
        var listaServiciu = _context.Serviciu
            .Include(b => b.Trainer)
            .Select(x => new
            {
                x.ID,
                SerivciuFullName = x.Titlu + " - " + x.Trainer.Nume + " " +
                                   x.Trainer.Prenume
            });
        ViewData["ServiciuID"] = new SelectList(listaServiciu, "ID", "SerivciuFullName");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Programare).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProgramareExists(Programare.ID))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ProgramareExists(int id)
    {
        return _context.Programare.Any(e => e.ID == id);
    }
}