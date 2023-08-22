using MeuBolso.Context;
using MeuBolso.Infraestrutura.Pagination;
using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;
using MeuBolso.Modulos.InstituicaoFinanceira.QueryCommands;
using MeuBolso.Modulos.InstituicaoFinanceira.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Api.Controllers;

[Route("instituicoes-financeiras")]
[ApiController]
public class InstituicaoFinanceiraController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IServicoInstituicaoFinanceira _servicoInstituicaoFinanceira;

    public InstituicaoFinanceiraController(AppDbContext context, IServicoInstituicaoFinanceira servicoInstituicaoFinanceira)
    {
        _context = context;
        _servicoInstituicaoFinanceira = servicoInstituicaoFinanceira;
    }

    [HttpGet("{id}")]
    public async Task<InstituicaoFinanceiraEntity?> GetAsync([FromRoute] Guid id)
    {
        var entity = await _context.InstituicoesFinanceiras.FindAsync(id, CancellationToken.None);

        if (entity == null)
            return null;

        return entity;
    }

    [HttpGet]
    public virtual async Task<PaginationResult<InstituicaoFinanceiraEntity>> GetAsync([FromQuery] PaginationCommand<InstituicaoFinanceiraEntity, InstituicaoFinanceiraQueryCommand> queryCommand)
    {
        var queryable = _context.InstituicoesFinanceiras.AsNoTracking();
        var paginationResult = await queryCommand.GetPaginationResultAsync(queryable);

        return paginationResult;
    }

    [HttpPost]
    public async Task<InstituicaoFinanceiraEntity?> PostAsync([FromBody] InstituicaoFinanceiraCommand command)
    {
        var entity = await _servicoInstituicaoFinanceira.AdicionarAsync(command, CancellationToken.None);

        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpPut]
    public async Task<InstituicaoFinanceiraEntity?> PutAsync([FromBody] InstituicaoFinanceiraCommand command)
    {
        var entity = await _servicoInstituicaoFinanceira.AtualizarAsync(command, CancellationToken.None);
        if (entity == null)
            return null;

        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _servicoInstituicaoFinanceira.ExcluirAsync(id, CancellationToken.None);

        await _context.SaveChangesAsync();

        return Ok();
    }
}