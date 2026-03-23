namespace Tutorial3_apbd.model;

public class Projector : Equipment
{
    public int Brightness {get; set;}
    public string Resolution {get; set;}

    public Projector(string name, int brightness, string resolution) : base(name)
    {
        Brightness = brightness;
        Resolution = resolution;
    }
    
    public override string ToString()
    {
        return base.ToString() + $" | Brightness: {Brightness} | Resolution: {Resolution}";
    }
}