using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Servicos
{
    public class ServicoInstituicaoFinanceira : IServicoInstituicaoFinanceira
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<InstituicaoFinanceiraEntity> _validator;

        public ServicoInstituicaoFinanceira(AppDbContext context, IMapper mapper, IValidator<InstituicaoFinanceiraEntity> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<InstituicaoFinanceiraEntity> AdicionarAsync(InstituicaoFinanceiraCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InstituicaoFinanceiraEntity>(command);

            await _validator.ValidateAndThrowAsync(entity, cancellationToken);
            await _context.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<InstituicaoFinanceiraEntity?> AtualizarAsync(InstituicaoFinanceiraCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Instituicoes.FindAsync(command.Id, cancellationToken);

            return entity;
        }

        public async Task ExcluirAsync(Guid Id, CancellationToken cancellationToken)
        {
            var entity = await _context.Instituicoes.FindAsync(Id, cancellationToken);
            if (entity == null)
                return;

            _context.Instituicoes.Remove(entity);
        }
    }
}
