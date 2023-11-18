using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly CreateAboutCommandHandler _createAboutCommandHandler;
    private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
    private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
    private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
    private readonly GetAboutQueryHandler _getAboutQueryHandler;

    public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler)
    {
        _createAboutCommandHandler = createAboutCommandHandler;
        _updateAboutCommandHandler = updateAboutCommandHandler;
        _removeAboutCommandHandler = removeAboutCommandHandler;
        _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        _getAboutQueryHandler = getAboutQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var datas = await _getAboutQueryHandler.Handle();
        return Ok(datas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var data = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddAbout(CreateAboutCommand command)
    {
        await _createAboutCommandHandler.Handle(command);
        return Ok("Hakkımızda Bilgisi Başarı ile Eklendi!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
    {
        await _updateAboutCommandHandler.Handle(command);
        return Ok("Hakkımızda Bilgisi Başarı ile Güncellendi!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAbout(int id)
    {
        await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok("Hakkımızda Bilgisi Başarı ile Silindi!");
    }
}