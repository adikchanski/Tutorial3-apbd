namespace Tutorial3_apbd.model;

public class Student : User
{
    public override int RentalLimit => 2;

    public Student(int id, string firstName, string lastName) : base(id, firstName, lastName)
    {
        
    }
}