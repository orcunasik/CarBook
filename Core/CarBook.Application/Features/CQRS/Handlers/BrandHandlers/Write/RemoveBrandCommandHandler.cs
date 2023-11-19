using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers;

public class RemoveBrandCommandHandler
{
    private readonly IRepository<Brand> _repository;

    public RemoveBrandCommandHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveBrandCommand command)
    {
        Brand data = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(data);
    }
}