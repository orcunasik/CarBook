namespace CarBook.Domain.Entities;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Car> Cars { get; set; }
}