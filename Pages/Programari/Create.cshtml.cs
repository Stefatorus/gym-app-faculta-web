using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Programari;

public class CreateModel : PageModel
{
    private readonly Gym_webContext _context;

    public CreateModel(Gym_webContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        var listaServiciu = _context.Serviciu
            .Include(b => b.Trainer)
            .Select(x => new
            {
                x.ID,
                ServiciuFullName = x.Titlu + " - " + x.Trainer.Prenume + " " +
                                   x.Trainer.Nume
            });
        ViewData["ServiciuID"] = new SelectList(listaServiciu, "ID", "ServiciuFullName");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
        return Page();
    }

    [BindProperty] public Programare Programare { get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Programare.Add(Programare);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}