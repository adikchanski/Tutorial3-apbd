using Tutorial3_apbd.model;

namespace Tutorial3_apbd.Services;

public class RentalService
{
    private List<Rental> rentals = new();

    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable || !equipment.IsOperational)
            throw new Exception("Unavailable equipment");

        int activeRentals = rentals.Count(r => r.User == user && !r.IsReturned);
        
        if (activeRentals >= user.RentalLimit)
            throw new Exception("Rental limit exceeded");
        
        rentals.Add(new Rental
        {
            User = user,
            Equipment = equipment,
            RentDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(days),
        });
        
        equipment.IsAvailable = false;
    }

    public void ReturnEquipment(Equipment equipment)
    {
        Rental? foundRental = null;
        foreach (var rental in rentals)
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
        Console.WriteLine($"Penalty: {penalty}");
    }
}