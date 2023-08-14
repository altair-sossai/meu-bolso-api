using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.QueryCommand;

// Classe respons�vel por definir um comando de consulta para filtrar e ordenar entidades de Carteira.
public class CarteiraQueryCommand
{
    // Representa a string de consulta que ser� usada para filtrar as entidades de Carteira por descri��o.
    public string? Query { get; set; }

    // Aplica os filtros e ordena��o na consulta de entidades de Carteira.
    public IQueryable<CarteiraEntity> Apply(IQueryable<CarteiraEntity> queryable)
    {
        // Verifica se a string de consulta n�o est� vazia ou nula.
        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Descricao!.Contains(Query)); // Filtra as entidades de Carteira cuja descri��o cont�m a string de consulta.

        // Ordena as entidades de Carteira com base na descri��o.
        return queryable.OrderBy(o => o.Descricao);
    }
}