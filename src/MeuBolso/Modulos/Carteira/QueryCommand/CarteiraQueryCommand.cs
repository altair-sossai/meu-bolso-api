using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.QueryCommand;

// Classe responsável por definir um comando de consulta para filtrar e ordenar entidades de Carteira.
public class CarteiraQueryCommand
{
    // Representa a string de consulta que será usada para filtrar as entidades de Carteira por descrição.
    public string? Query { get; set; }

    // Aplica os filtros e ordenação na consulta de entidades de Carteira.
    public IQueryable<CarteiraEntity> Apply(IQueryable<CarteiraEntity> queryable)
    {
        // Verifica se a string de consulta não está vazia ou nula.
        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Descricao!.Contains(Query)); // Filtra as entidades de Carteira cuja descrição contém a string de consulta.

        // Ordena as entidades de Carteira com base na descrição.
        return queryable.OrderBy(o => o.Descricao);
    }
}