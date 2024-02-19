using Gym_web.Models;

namespace Gym_web.Pages.Specialitati;

public class SpecialitateIndexData
{
    public List<Specialitate> Specialitati { get; internal set; }
    public ICollection<SpecialitateServiciu>? SpecialitatiServiciu { get; internal set; }
}