namespace Tutorial3_apbd.model;

public abstract class Equipment
{
    private static int _idCounter = 1;
    public int Id { get; }
    public string Name  { get; set; }
    public bool IsAvailable  { get; set; }
    public bool IsOperational { get; set; }

    protected Equipment(string name)
    {
        Id = _idCounter++;
        Name = name;
        IsAvailable = true;
        IsOperational = true;
    }
    
    public override string ToString()
    {
        return $"{Id}: {Name} | Available: {IsAvailable} | Operational: {IsOperational}";
    }
}