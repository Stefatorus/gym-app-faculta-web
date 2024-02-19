using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_web.Pages.Specialitati;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly Gym_webContext _context;

    public CreateModel(Gym_webContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty] public Specialitate Specialitate { get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Specialitate.Add(Specialitate);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}