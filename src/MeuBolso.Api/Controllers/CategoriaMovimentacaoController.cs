using MeuBolso.Context;
using MeuBolso.Infraestrutura.Pagination;
using MeuBolso.Modulos.Carteira.Entidades;
using MeuBolso.Modulos.Carteira.QueryCommands;
using MeuBolso.Modulos.CategoriaMovimentacao.Commands;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;
using MeuBolso.Modulos.CategoriaMovimentacao.QueryCommands;
using MeuBolso.Modulos.CategoriaMovimentacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Api.Controllers;

[Route("categorias")]
[ApiController]
public class CategoriaMovimentacaoController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IServicoCategoriaMovimentacao _servicoCategoriaMovimentacao;

    public CategoriaMovimentacaoController(AppDbContext context, IServicoCategoriaMovimentacao servicoCategoriaMovimentacao)
    {
        _context = context;
        _servicoCategoriaMovimentacao = servicoCategoriaMovimentacao;
    }

    [HttpGet("{id}")]
    public async Task<CategoriaMovimentacaoEntity?> GetAsync([FromRoute] Guid id)
    {
        var entity = await _context.Categorias.FindAsync(id, CancellationToken.None);
        if (entity == null)
            return null;

        return entity;
    }

    [HttpGet]
    public virtual async Task<PaginationResult<CategoriaMovimentacaoEntity>> GetAsync([FromQuery] PaginationCommand<CategoriaMovimentacaoEntity, CategoriaMovimentacaoQueryCommand> queryCommand)
    {
        var queryable = _context.Categorias.AsNoTracking();
        var paginationResult = await queryCommand.GetPaginationResultAsync(queryable);

        return paginationResult;
    }

    [HttpPost]
    public async Task<CategoriaMovimentacaoEntity> PostAsync([FromBody] CategoriaMovimentacaoCommand command)
    {
        var entity = await _servicoCategoriaMovimentacao.AdicionarAsync(command, CancellationToken.None);

        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpPut]
    public async Task<CategoriaMovimentacaoEntity?> PutAsync([FromBody] CategoriaMovimentacaoCommand command)
    {
        var entity = await _servicoCategoriaMovimentacao.AtualizarAsync(command, CancellationToken.None);
        if (entity == null)
            return null;

        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _servicoCategoriaMovimentacao.ExcluirAsync(id, CancellationToken.None);

        await _context.SaveChangesAsync();

        return Ok();
    }
}