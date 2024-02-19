using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Programari;

public class IndexModel : PageModel
{
    private readonly Gym_webContext _context;

    public IndexModel(Gym_webContext context)
    {
        _context = context;
    }

    public IList<Programare> Programare { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Programare != null)
            Programare = await _context.Programare
                .Include(b => b.Serviciu)
                .ThenInclude(b => b.Trainer)
                .Include(b => b.Client).ToListAsync();
    }
}