using AutoMapper;
using FluentValidation;
using MeuBolso.Infraestrutura.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Infraestrutura.Services;

public abstract class BaseService<TEntity, TAddCommand, TUpdateCommand, TKey> : IBaseService<TEntity, TAddCommand, TUpdateCommand, TKey>
    where TEntity : class, IHasId<TKey>
    where TUpdateCommand : IHasId<TKey>
    where TKey : struct
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<TEntity> _validator;

    protected BaseService(DbContext context, IMapper mapper, IValidator<TEntity> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    private DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public virtual async Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TAddCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(command);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await _context.AddAsync(entity, cancellationToken);

        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync(TUpdateCommand updateCommand, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(updateCommand.Id, cancellationToken);
        if (entity == null)
            return null;

        _mapper.Map(updateCommand, entity);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);

        return entity;
    }

    public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(id, cancellationToken);
        if (entity == null)
            return;

        DbSet.Remove(entity);
    }
}

public abstract class BaseService<TEntity, TCommand, TKey> : BaseService<TEntity, TCommand, TCommand, TKey>, IBaseService<TEntity, TCommand, TKey>
    where TEntity : class, IHasId<TKey>
    where TCommand : IHasId<TKey>
    where TKey : struct
{
    protected BaseService(DbContext context, IMapper mapper, IValidator<TEntity> validator)
        : base(context, mapper, validator)
    {
    }
}

public abstract class BaseService<TEntity, TCommand> : BaseService<TEntity, TCommand, Guid>, IBaseService<TEntity, TCommand>
    where TEntity : class, IHasId<Guid>
    where TCommand : IHasId<Guid>
{
    protected BaseService(DbContext context, IMapper mapper, IValidator<TEntity> validator)
        : base(context, mapper, validator)
    {
    }
}