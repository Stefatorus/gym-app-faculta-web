using System.ComponentModel.DataAnnotations;

namespace Gym_web.Models;

public class Programare
{
    public int ID { get; set; }
    [Display(Name = "Nume Client")] public int? ClientID { get; set; }
    public Client? Client { get; set; }

    [Display(Name = "Denumire Investigație")]
    public int? ServiciuID { get; set; }

    public Serviciu? Serviciu { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data programării")]
    public DateTime DataProgramare { get; set; }
}