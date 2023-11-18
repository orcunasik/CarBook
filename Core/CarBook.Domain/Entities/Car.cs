namespace CarBook.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public string BigImageUrl { get; set; }
    public int Kilometers { get; set; }
    public byte Seat { get; set; }
    public byte Luggage { get; set; }
    public string Transmission { get; set; }
    public string Fuel { get; set; }
    public IList<CarFeature> CarFeatures { get; set; }
    public IList<CarDescription> CarDescriptions { get; set; }
    public IList<CarPricing> CarPricings { get; set; }
}