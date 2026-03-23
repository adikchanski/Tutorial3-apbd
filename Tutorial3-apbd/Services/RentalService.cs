using Tutorial3_apbd.model;

namespace Tutorial3_apbd.Services;

public class RentalService
{
    private List<Rental> _rentals = new();
    private List<User> _users = new();
    private List<Equipment> _equipment = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public void MarkUnavailable(Equipment equipment, string reason = "maintenance")
    {
        equipment.IsAvailable = false;
        equipment.IsOperational = false;
        Console.WriteLine($"Equipment '{equipment.Name}' marked unavailable ({reason}).");
    }
    
    public List<Equipment> GetAllEquipment() => _equipment;

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipment.Where(e => e.IsAvailable && e.IsOperational).ToList();
    }

    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable || !equipment.IsOperational)
            throw new Exception("Unavailable equipment");

        int activeRentals = _rentals.Count(r => r.User == user && !r.IsReturned);
        
        if (activeRentals >= user.RentalLimit)
            throw new InvalidOperationException(
                $"Rental limit exceeded. {user.GetType().Name}s may have at most {user.RentalLimit} active rentals.");
        
        _rentals.Add(new Rental
        {
            User = user,
            Equipment = equipment,
            RentDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(days),
        });
        
        equipment.IsAvailable = false;
    }

    public decimal ReturnEquipment(Equipment equipment)
    {
        Rental? foundRental = null;
        foreach (var rental in _rentals)
        {
            if (rental.Equipment == equipment && !rental.IsReturned)
            {
                foundRental = rental;
                break;
            }
        }
        if (foundRental == null)
            throw new Exception("Rental not found");

        foundRental.ReturnDate = DateTime.Now;
        equipment.IsAvailable = true;
        
        decimal penalty = foundRental.CalculatePenalty();
        if (penalty > 0)
            Console.WriteLine($"Late return! Penalty for '{equipment.Name}': {penalty} PLN");
        else
            Console.WriteLine($"'{equipment.Name}' returned on time. No penalty.");
 
        return penalty;
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => !r.IsReturned && r.DueDate < DateTime.Now).ToList();
    }

    public List<Rental> GetUserActiveRentals(User user)
    {
        return _rentals.Where(r => r.User == user && !r.IsReturned).ToList();
    }
    
    public List<Rental> GetAllRentals() => _rentals;
    
    public List<User> GetAllUsers() => _users;
}