using Gym_web.Data;
using Gym_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Pages.Traineri;

public class IndexModel : PageModel
{
    private readonly Gym_webContext _context;

    public IndexModel(Gym_webContext context)
    {
        _context = context;
    }

    public IList<Trainer> Trainer { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Trainer != null) Trainer = await _context.Trainer.ToListAsync();
    }
}