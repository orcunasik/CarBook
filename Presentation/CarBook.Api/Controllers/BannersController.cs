using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BannersController : ControllerBase
{
    private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
    private readonly GetBannerQueryHandler _getBannerQueryHandler;
    private readonly CreateBannerCommandHandler _createBannerCommandHandler;
    private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
    private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

    public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
    {
        _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        _getBannerQueryHandler = getBannerQueryHandler;
        _createBannerCommandHandler = createBannerCommandHandler;
        _updateBannerCommandHandler = updateBannerCommandHandler;
        _removeBannerCommandHandler = removeBannerCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
        var datas = await _getBannerQueryHandler.Handle();
        return Ok(datas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner(int id)
    {
        var data = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddBanner(CreateBannerCommand command)
    {
        await _createBannerCommandHandler.Handle(command);
        return Ok("Banner Bilgisi Başarı ile Eklendi!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
    {
        await _updateBannerCommandHandler.Handle(command);
        return Ok("Banner Bilgisi Başarı ile Güncellendi!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBanner(int id)
    {
        await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
        return Ok("Banner Bilgisi Başarı ile Silindi!");
    }
}