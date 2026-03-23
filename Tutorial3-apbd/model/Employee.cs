namespace Tutorial3_apbd.model;

public class Employee : User
{
    public override int RentalLimit => 5;

    public Employee(int id, string firstName, string lastName) : base(id, firstName, lastName)
    {
        
    }
}