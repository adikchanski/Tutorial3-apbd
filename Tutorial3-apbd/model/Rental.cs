namespace Tutorial3_apbd.model;

public class Rental
{
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public bool IsReturned => ReturnDate.HasValue;

    public decimal CalculatePenalty()
    {
        if (!ReturnDate.HasValue || ReturnDate < DueDate)
            return 0;
        int lateDays = (ReturnDate.Value - DueDate).Days;
        return lateDays * 10;
    }
}