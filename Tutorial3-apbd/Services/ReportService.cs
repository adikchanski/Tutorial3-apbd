using Tutorial3_apbd.model;

namespace Tutorial3_apbd.Services;

public class ReportService
{
    private readonly RentalService _rentalService;

    public ReportService(RentalService rentalService)
    {
        _rentalService = rentalService;
    }

    public void PrintAllEquipment()
    {
        Console.WriteLine("\n=== All Equipment ===");
        var all = _rentalService.GetAllEquipment();
        if (!all.Any()) { Console.WriteLine("No equipment registered."); return; }
        foreach (var item in all)
            Console.WriteLine(item);
    }
    
    public void PrintAvailableEquipment()
    {
        Console.WriteLine("\n=== Available Equipment ===");
        var available = _rentalService.GetAvailableEquipment();
        if (!available.Any()) { Console.WriteLine("No equipment currently available."); return; }
        foreach (var item in available)
            Console.WriteLine(item);
    }

    public void PrintUserActiveRentals(User user)
    {
        Console.WriteLine($"\n=== Active Rentals for {user.FirstName} {user.LastName} ===");
        var rentals = _rentalService.GetUserActiveRentals(user);
        if (!rentals.Any()) { Console.WriteLine("No active rentals."); return; }
        foreach (var r in rentals)
            Console.WriteLine($"  {r.Equipment.Name} | Due: {r.DueDate:yyyy-MM-dd}");
    }
    
    public void PrintOverdueRentals()
    {
        Console.WriteLine("\n=== Overdue Rentals ===");
        var overdue = _rentalService.GetOverdueRentals();
        if (!overdue.Any()) { Console.WriteLine("No overdue rentals."); return; }
        foreach (var r in overdue)
            Console.WriteLine($"  {r.User.FirstName} {r.User.LastName} — {r.Equipment.Name} | Due: {r.DueDate:yyyy-MM-dd}");
    }
    
    public void PrintSummaryReport()
    {
        Console.WriteLine("\n========== SYSTEM SUMMARY REPORT ==========");
 
        var allEquipment = _rentalService.GetAllEquipment();
        var allRentals = _rentalService.GetAllRentals();
        var allUsers = _rentalService.GetAllUsers();
 
        Console.WriteLine($"Total users:          {allUsers.Count}");
        Console.WriteLine($"Total equipment:      {allEquipment.Count}");
        Console.WriteLine($"Available equipment:  {_rentalService.GetAvailableEquipment().Count}");
        Console.WriteLine($"Total rentals made:   {allRentals.Count}");
        Console.WriteLine($"Active rentals:       {allRentals.Count(r => !r.IsReturned)}");
        Console.WriteLine($"Overdue rentals:      {_rentalService.GetOverdueRentals().Count}");
 
        decimal totalPenalties = allRentals 
            .Where(r => r.IsReturned)
            .Sum(r => r.CalculatePenalty());
        Console.WriteLine($"Total penalties collected: {totalPenalties} PLN");
 
        Console.WriteLine("===========================================\n");
    }
}