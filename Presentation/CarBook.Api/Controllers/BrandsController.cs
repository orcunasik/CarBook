using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
    private readonly GetBrandQueryHandler _getBrandQueryHandler;
    private readonly CreateBrandCommandHandler _createBrandCommandHandler;
    private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
    private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;

    public BrandsController(GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler)
    {
        _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        _getBrandQueryHandler = getBrandQueryHandler;
        _createBrandCommandHandler = createBrandCommandHandler;
        _removeBrandCommandHandler = removeBrandCommandHandler;
        _updateBrandCommandHandler = updateBrandCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
        var datas = await _getBrandQueryHandler.Handle();
        return Ok(datas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand(int id)
    {
        var data = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand(CreateBrandCommand command)
    {
        await _createBrandCommandHandler.Handle(command);
        return Ok("Marka Bilgisi Başarı ile Eklendi!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
    {
        await _updateBrandCommandHandler.Handle(command);
        return Ok("Marka Bilgisi Başarı ile Güncellendi!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
        return Ok("Marka Bilgisi Başarı ile Silindi!");
    }
}