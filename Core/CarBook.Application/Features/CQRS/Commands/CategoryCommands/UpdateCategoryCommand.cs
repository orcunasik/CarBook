namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands;

public class UpdateCategoryCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
}