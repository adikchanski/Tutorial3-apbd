using Tutorial3_apbd.model;

namespace Tutorial3_apbd.Services;

public class RentalService
{
    private List<Rental> rentals = new();

    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable || !equipment.IsOperational)
            throw new Exception("Unavailable equipment");
    }
}