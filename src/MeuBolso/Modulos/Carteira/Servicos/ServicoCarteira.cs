using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Servicos;

public class ServicoCarteira : IServicoCarteira
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CarteiraEntity> _validator;

    public ServicoCarteira(AppDbContext context,
        IMapper mapper,
        IValidator<CarteiraEntity> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CarteiraEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Carteiras.FindAsync(id, cancellationToken);
    }

    public async Task<CarteiraEntity> AdicionarAsync(CarteiraCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CarteiraEntity>(command);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await _context.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<CarteiraEntity?> AtualizarAsync(CarteiraCommand command, CancellationToken cancellationToken)
    {
        var entity = await ObterPorIdAsync(command.Id, cancellationToken);
        if (entity == null)
            return null;

        _mapper.Map(command, entity);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);

        return entity;
    }

    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await ObterPorIdAsync(id, cancellationToken);
        if (entity == null)
            return;

        _context.Carteiras.Remove(entity);
    }
}