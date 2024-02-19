using Gym_web.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_web.Models;

public class SpecialitatiServiciuPageModel : PageModel
{
    public List<DateSpecialitateAtribuite> ListaDateSpecialitateAtribuite;

    public void PopulareDateSpecialitateAtribuite(Gym_webContext context, Serviciu serviciu)
    {
        var toateSpecialitatile = context.Specialitate;
        var specialitatiServiciu = new HashSet<int>(
            serviciu.SpecialitatiServiciu.Select(c => c.SpecialitateID));
        ListaDateSpecialitateAtribuite = new List<DateSpecialitateAtribuite>();
        foreach (var sp in toateSpecialitatile)
            ListaDateSpecialitateAtribuite.Add(new DateSpecialitateAtribuite
            {
                SpecialitateID = sp.ID,
                Nume = sp.NumeSpecialitate,
                Atribuit = specialitatiServiciu.Contains(sp.ID)
            });
    }

    public void UpdateSpecialitatiServiciu(Gym_webContext context, string[] specialitatiSelectate,
        Serviciu serviciuToUpdate)
    {
        if (specialitatiSelectate == null)
        {
            serviciuToUpdate.SpecialitatiServiciu = new List<SpecialitateServiciu>();
            return;
        }

        var specialitatiSelectateHS = new HashSet<string>(specialitatiSelectate);
        var specialitatiServiciu = new HashSet<int>
            (serviciuToUpdate.SpecialitatiServiciu.Select(c => c.Specialitate.ID));
        foreach (var sp in context.Specialitate)
            if (specialitatiSelectateHS.Contains(sp.ID.ToString()))
            {
                if (!specialitatiServiciu.Contains(sp.ID))
                    serviciuToUpdate.SpecialitatiServiciu.Add(
                        new SpecialitateServiciu
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            SpecialitateID = sp.ID
                        });
            }
            else
            {
                if (specialitatiServiciu.Contains(sp.ID))
                {
                    var courseToRemove
                        = serviciuToUpdate
                            .SpecialitatiServiciu
                            .SingleOrDefault(i => i.SpecialitateID == sp.ID);
                    context.Remove(courseToRemove);
                }
            }
    }
}