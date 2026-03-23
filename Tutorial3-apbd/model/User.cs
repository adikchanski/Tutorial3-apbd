namespace Tutorial3_apbd.model;

public abstract class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int RentalLimit { get; }

    protected User(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{Id}: {FirstName} {LastName}";
    }
}