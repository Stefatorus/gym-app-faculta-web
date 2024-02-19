using System.ComponentModel.DataAnnotations;

namespace Gym_web.Models;

public class Client
{
    public int ID { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$",
        ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau Ana-Maria")]
    [StringLength(30, MinimumLength = 3)]
    public string? Prenume { get; set; }

    [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
    [StringLength(30, MinimumLength = 3)]
    public string? Nume { get; set; }

    [StringLength(70)] public string? Localitate { get; set; }
    public string Email { get; set; }

    [RegularExpression(@"^([0]{1})[-. ]?([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
        ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
    public string? Telefon { get; set; }

    [Display(Name = "Nume")] public string? FullName => Prenume + " " + Nume;

    public ICollection<Programare>? Programari { get; set; }
}