namespace Tutorial3_apbd.model;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public bool HasOpticalZoom { get; set; }

    public Camera(string name, int megapixels, bool hasOpticalZoom) : base(name)
    {
        Megapixels = megapixels;
        HasOpticalZoom = hasOpticalZoom;
    }
    
    public override string ToString()
    {
        return base.ToString() + $" | MP: {Megapixels} | Zoom: {HasOpticalZoom}";
    }
}