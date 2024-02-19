namespace Gym_web.Models;

public class SpecialitateServiciu
{
    public int ID { get; set; }
    public int ServiciuID { get; set; }
    public Serviciu Serviciu { get; set; }
    public int SpecialitateID { get; set; }
    public Specialitate Specialitate { get; set; }
}