namespace Tutorial3_apbd.model;

public abstract class Equipment
{
    private static int _idCounter = 1;
    protected int Id { get; }
    protected string Name  { get; set; }
    protected bool IsAvailable  { get; set; }
    protected bool IsOperational { get; set; }

    protected Equipment(string name)
    {
        Id = _idCounter++;
        Name = name;
        IsAvailable = true;
        IsOperational = false;
    }
    
    public override string ToString()
    {
        return $"{Id}: {Name} | Available: {IsAvailable} | Operational: {IsOperational}";
    }
}