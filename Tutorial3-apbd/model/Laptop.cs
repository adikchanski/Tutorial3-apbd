namespace Tutorial3_apbd.model;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string Processor { get; set;}

    public Laptop(string name, int ramGb, string processor) : base(name)
    {
        RamGb = ramGb;
        Processor = processor;
    }

    public override string ToString()
    {
        return base.ToString() + $" | RAM: {RamGb}GB | CPU: {Processor}";
    }
}