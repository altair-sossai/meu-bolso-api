using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Infraestrutura.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Infraestrutura.Services;

public class BaseService<TEntity, TCommand, TUpdateCommand, TKey> : IBaseService<TEntity, TCommand, TUpdateCommand, TKey>
    where TEntity : class, IHasId<TKey>
    where TCommand : IHasId<TKey>
    where TUpdateCommand : IHasId<TKey>
    where TKey : struct
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<TEntity> _validator;
    protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public BaseService(AppDbContext context, IMapper mapper, IValidator<TEntity> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<TEntity?> ObterPorIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }
    public async Task<TEntity?> AdicionarAsync(TCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(command);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await _context.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<TEntity?> UpdateAsync(TUpdateCommand updateCommand, CancellationToken cancellationToken)
    {
        var entity = await ObterPorIdAsync(updateCommand.Id, cancellationToken);
        if (entity == null)
            return null;

        _mapper.Map(updateCommand, entity);

        return entity;
    }
    public async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await ObterPorIdAsync(id, cancellationToken);
        if (entity == null) 
            return;

        DbSet.Remove(entity);
    }
}
