using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Servicos;

// Classe responsável por fornecer serviços relacionados à entidade Carteira.
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

    // Adiciona uma nova entidade Carteira ao contexto.
    public async Task<CarteiraEntity> AdicionarAsync(CarteiraCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CarteiraEntity>(command);

        // Valida a entidade usando o validador antes de adicionar ao contexto.
        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await _context.AddAsync(entity, cancellationToken);

        return entity;
    }

    // Atualiza uma entidade Carteira existente no contexto.
    public async Task<CarteiraEntity?> AtualizarAsync(CarteiraCommand command, CancellationToken cancellationToken)
    {
        var entity = await _context.Carteiras.FindAsync(command.Id, cancellationToken);
        if (entity == null)
            return null;

        _mapper.Map(command, entity);

        // Valida a entidade usando o validador antes de atualizar no contexto.
        await _validator.ValidateAndThrowAsync(entity, cancellationToken);

        return entity;
    }

    // Exclui uma entidade Carteira do contexto.
    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Carteiras.FindAsync(id, cancellationToken);
        if (entity == null)
            return;

        _context.Carteiras.Remove(entity);
    }
}