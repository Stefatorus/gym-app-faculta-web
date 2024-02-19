using System.ComponentModel.DataAnnotations;

namespace Gym_web.Models;

public class Trainer
{
    public int ID { get; set; }
    public string Nume { get; set; }
    public string Prenume { get; set; }
    [Display(Name = "Nume")] public string FullName => Prenume + " " + Nume;

    public ICollection<Serviciu>? Servicii { get; set; }
}