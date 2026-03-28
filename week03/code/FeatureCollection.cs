public class FeatureCollection
{
    // The top-level JSON object has an array called "features"
    public Feature[] Features { get; set; }
}

public class Feature
{
    // Each feature has an object called "properties"
    public Properties Properties { get; set; }
}

public class Properties
{
    // Inside properties, we find the magnitude and the place name
    public double Mag { get; set; }
    public string Place { get; set; }
}