using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_web.Pages.CLienti;

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

    [BindProperty] public Client Client { get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Client.Add(Client);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}