namespace CarBook.Domain.Entities;

public class Pricing
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<CarPricing> CarPricings { get; set; }
}