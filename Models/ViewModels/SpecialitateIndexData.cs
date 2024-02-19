namespace Gym_web.Models.ViewModels;

public class SpecialitateIndexData
{
    public IEnumerable<Specialitate> Specialitati { get; set; }
    public IEnumerable<SpecialitateServiciu> SpecialitatiServiciu { get; set; }

    public IEnumerable<Serviciu> Servicii { get; set; }
}