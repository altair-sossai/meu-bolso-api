﻿using MeuBolso.Modulos.CategoriaMovimentacao.Enum;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Commands;

public class CategoriaMovimentacaoCommand
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Nome { get; set; }
    public Cores Cor { get; set; }
    public decimal PrevisaoGastoMes { get; set; }
}