using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Categoria> ListarCategorias();
        IIncludableQueryable<Leilao, Categoria> ListarLeiloes();
        Leilao ListarLeilaoPorId(int id);
        void IncluirLeilao(Leilao model);
        void AtualizarLeilao(Leilao model);
        void RemoverLeilao(Leilao model);
        IEnumerable<Leilao> PesquisarPorTermo(string termo);
    }
}
