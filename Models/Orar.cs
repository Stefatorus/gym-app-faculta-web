using System.ComponentModel.DataAnnotations;

namespace Gym_web.Models;

public class Orar
{
    public int ID { get; set; }
    [Display(Name = "Program")] public string Zi { get; set; }
    public ICollection<Serviciu>? Servicii { get; set; }
}