using Gym_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym_web.Data;

public class Gym_webContext : DbContext
{
    public Gym_webContext(DbContextOptions<Gym_webContext> options)
        : base(options)
    {
    }

    public DbSet<Serviciu> Serviciu { get; set; } = default!;

    public DbSet<Orar> Orar { get; set; }

    public DbSet<Trainer> Trainer { get; set; }

    public DbSet<Specialitate> Specialitate { get; set; }

    public DbSet<Client> Client { get; set; }

    public DbSet<Programare> Programare { get; set; }
}