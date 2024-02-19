using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.CLienti;

public class DetailsModel : PageModel
{
    private readonly Gym_webContext _context;

    public DetailsModel(Gym_webContext context)
    {
        _context = context;
    }

    public Client Client { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Client == null) return NotFound();

        var Client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);
        if (Client == null)
            return NotFound();
        else
            Client = Client;
        return Page();
    }
}