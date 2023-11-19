using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly CreateCarCommandHandler _createCarCommandHandler;
    private readonly UpdateCarCommandHandler _updateCarCommandHandler;
    private readonly RemoveCarCommandHandler _removeCarCommandHandler;

    public CarsController(GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler)
    {
        _getCarByIdQueryHandler = getCarByIdQueryHandler;
        _getCarQueryHandler = getCarQueryHandler;
        _createCarCommandHandler = createCarCommandHandler;
        _updateCarCommandHandler = updateCarCommandHandler;
        _removeCarCommandHandler = removeCarCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var datas = await _getCarQueryHandler.Handle();
        return Ok(datas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
        var data = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar(CreateCarCommand command)
    {
        await _createCarCommandHandler.Handle(command);
        return Ok("Araç Bilgisi Başarı ile Eklendi!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await _updateCarCommandHandler.Handle(command);
        return Ok("Araç Bilgisi Başarı ile Güncellendi!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Araç Bilgisi Başarı ile Silindi!");
    }
}