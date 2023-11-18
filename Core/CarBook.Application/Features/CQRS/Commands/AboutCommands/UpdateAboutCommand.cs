namespace CarBook.Application.Features.CQRS.Commands.AboutCommands;

public class UpdateAboutCommand
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}