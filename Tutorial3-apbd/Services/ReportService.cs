using Tutorial3_apbd.model;

namespace Tutorial3_apbd.Services;

public class ReportService
{
    public void PrintEquipment(List<Equipment> equipment)
    {
        foreach (var item in equipment)
        {
            Console.WriteLine(item);
        }
    }
}