using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
    private readonly GetContactQueryHandler _getContactQueryHandler;
    private readonly CreateContactCommandHandler _createContactCommandHandler;
    private readonly RemoveContactCommandHandler _removeContactCommandHandler;
    private readonly UpdateContactCommandHandler _updateContactCommandHandler;

    public ContactsController(GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, CreateContactCommandHandler createContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
    {
        _getContactByIdQueryHandler = getContactByIdQueryHandler;
        _getContactQueryHandler = getContactQueryHandler;
        _createContactCommandHandler = createContactCommandHandler;
        _removeContactCommandHandler = removeContactCommandHandler;
        _updateContactCommandHandler = updateContactCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        var datas = await _getContactQueryHandler.Handle();
        return Ok(datas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(int id)
    {
        var data = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddContact(CreateContactCommand command)
    {
        await _createContactCommandHandler.Handle(command);
        return Ok("İletişim Bilgisi Başarı ile Eklendi!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
    {
        await _updateContactCommandHandler.Handle(command);
        return Ok("İletişim Bilgisi Başarı ile Güncellendi!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(int id)
    {
        await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
        return Ok("İletişim Bilgisi Başarı ile Silindi!");
    }
}