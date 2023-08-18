﻿using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.QueryCommands;

public class InstituicaoFinanceiraQueryCommand
{
    public string? Query { get; set; }

    public IQueryable<InstituicaoFinanceiraEntity> Aplly(IQueryable<InstituicaoFinanceiraEntity> queryable)
    {
        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Nome!.Contains(Query));

        return queryable.OrderBy(w => w.Nome);
    }
}