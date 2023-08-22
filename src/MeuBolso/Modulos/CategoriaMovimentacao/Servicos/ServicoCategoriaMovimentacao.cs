using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Modulos.CategoriaMovimentacao.Commands;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Servicos;

public class ServicoCategoriaMovimentacao : IServicoCategoriaMovimentacao
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CategoriaMovimentacaoEntity> _validator;

    public ServicoCategoriaMovimentacao(AppDbContext context, IMapper mapper, IValidator<CategoriaMovimentacaoEntity> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CategoriaMovimentacaoEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Categorias.FindAsync(id, cancellationToken);
    }

    public async Task<CategoriaMovimentacaoEntity> AdicionarAsync(CategoriaMovimentacaoCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CategoriaMovimentacaoEntity>(command);

        await _validator.ValidateAndThrowAsync(entity, cancellationToken);
        await _context.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task<CategoriaMovimentacaoEntity?> AtualizarAsync(CategoriaMovimentacaoCommand command, CancellationToken cancellationToken)
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

        _context.Categorias.Remove(entity);
    }
}