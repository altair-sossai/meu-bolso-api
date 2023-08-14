﻿using MeuBolso.Context;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;
using MeuBolso.Modulos.Carteira.QueryCommand;
using MeuBolso.Modulos.Carteira.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Api.Controllers;

// Controlador responsável por lidar com as requisições relacionadas à entidade Carteira.
[Route("carteiras")]
[ApiController]
public class CarteiraController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IServicoCarteira _servicoCarteira;

    public CarteiraController(AppDbContext context,
        IServicoCarteira servicoCarteira)
    {
        _context = context;
        _servicoCarteira = servicoCarteira;
    }

    [HttpGet("{id}")]
    public async Task<CarteiraEntity?> GetAsync([FromRoute] Guid id)
    {
        var entity = await _context.Carteiras.FindAsync(id, CancellationToken.None);
        if (entity == null)
            return null;

        return entity;
    }

    [HttpGet]
    public virtual async Task<List<CarteiraEntity>> GetAsync([FromQuery] CarteiraQueryCommand queryCommand)
    {
        var queryable = queryCommand.Apply(_context.Carteiras.AsNoTracking());
        var entities = await queryable.ToListAsync(CancellationToken.None);

        return entities;
    }

    [HttpPost]
    public async Task<CarteiraEntity> PostAsync([FromBody] CarteiraCommand command)
    {
        var entity = await _servicoCarteira.AdicionarAsync(command, CancellationToken.None);

        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpPut]
    public async Task<CarteiraEntity?> PutAsync([FromBody] CarteiraCommand command)
    {
        var entity = await _servicoCarteira.AtualizarAsync(command, CancellationToken.None);
        if (entity == null)
            return null;

        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _servicoCarteira.ExcluirAsync(id, CancellationToken.None);

        await _context.SaveChangesAsync();

        return Ok();
    }
}