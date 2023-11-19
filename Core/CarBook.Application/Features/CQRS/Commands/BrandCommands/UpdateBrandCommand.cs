namespace CarBook.Application.Features.CQRS.Commands.BrandCommands;

public class UpdateBrandCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
}